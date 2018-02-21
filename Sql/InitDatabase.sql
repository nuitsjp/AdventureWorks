if exists (select 1 from sysobjects where id = object_id('EmployeePay'))
	drop view EmployeePay
GO

create view
	EmployeePay
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


if exists (select 1 from sysobjects where id = object_id('ManagedEmployee'))
	drop view ManagedEmployee
GO

create view
	ManagedEmployee
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
	inner join EmployeePay
		on	Employee.BusinessEntityID = EmployeePay.BusinessEntityID
	inner join HumanResources.EmployeeDepartmentHistory
		on	Employee.BusinessEntityID = EmployeeDepartmentHistory.BusinessEntityID
		and EmployeeDepartmentHistory.EndDate is null
	inner join HumanResources.Department
		on	EmployeeDepartmentHistory.DepartmentID = Department.DepartmentID
	inner join HumanResources.Shift
		on	EmployeeDepartmentHistory.ShiftID = Shift.ShiftID