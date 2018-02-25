DECLARE @LoginID nvarchar(max) = 'YOUR_ACCOUNT'

update
	HumanResources.Employee
set
	LoginID = @LoginID
where
	BusinessEntityID = 235
GO

if exists (select 1 from sysobjects where id = object_id('HumanResources.EmployeePay'))
	drop view HumanResources.EmployeePay
GO

create view
	HumanResources.EmployeePay
as select
	EmployeePayHistory.BusinessEntityID,
	EmployeePayHistory.Rate,
	EmployeePayHistory.PayFrequency
from
	HumanResources.EmployeePayHistory
	inner join (
		select
			BusinessEntityID,
			max(RateChangeDate) as LastRateChangeDate
		from
			HumanResources.EmployeePayHistory
		group by
			EmployeePayHistory.BusinessEntityID
	) as LastEmployeePayHistory
		on	EmployeePayHistory.BusinessEntityID = LastEmployeePayHistory.BusinessEntityID
		and	EmployeePayHistory.RateChangeDate = LastEmployeePayHistory.LastRateChangeDate
GO


if exists (select 1 from sysobjects where id = object_id('HumanResources.ManagedEmployee'))
	drop view HumanResources.ManagedEmployee
GO

create view
	HumanResources.ManagedEmployee
as select
	Employee.BusinessEntityID,
	Person.FirstName,
	Person.LastName,
	Person.EmailPromotion,
	Employee.NationalIDNumber,
	Employee.LoginID,
	Employee.JobTitle,
	Employee.BirthDate,
	Employee.MaritalStatus,
	Employee.Gender,
	Employee.HireDate,
	Employee.SalariedFlag,
	Employee.VacationHours,
	Employee.SickLeaveHours,
	Employee.CurrentFlag,
	EmployeePay.Rate,
	EmployeePay.PayFrequency,
	Department.GroupName,
	Department.Name as DepartmentName,
	EmployeeDepartmentHistory.StartDate,
	Shift.Name as ShiftName,
	BusinessEntity.ModifiedDate as BusinessEntityModifiedDate
from
	HumanResources.Employee
	inner join Person.BusinessEntity
		on	Employee.BusinessEntityID = BusinessEntity.BusinessEntityID
	inner join Person.Person
		on	Employee.BusinessEntityID = Person.BusinessEntityID
	inner join HumanResources.EmployeePay
		on	Employee.BusinessEntityID = EmployeePay.BusinessEntityID
	inner join HumanResources.EmployeeDepartmentHistory
		on	Employee.BusinessEntityID = EmployeeDepartmentHistory.BusinessEntityID
		and EmployeeDepartmentHistory.EndDate is null
	inner join HumanResources.Department
		on	EmployeeDepartmentHistory.DepartmentID = Department.DepartmentID
	inner join HumanResources.Shift
		on	EmployeeDepartmentHistory.ShiftID = Shift.ShiftID