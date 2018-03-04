DECLARE @LoginID nvarchar(max) = 'YOUR_ACCOUNT'

update
	HumanResources.Employee
set
	LoginID = @LoginID
where
	BusinessEntityID = 235
GO

if exists (SELECT 1 FROM sys.indexes WHERE name = 'IX_Employee_OrganizationLevel_OrganizationNode' and  object_id = object_id(N'[HumanResources].[Employee]'))
	DROP INDEX IX_Employee_OrganizationLevel_OrganizationNode ON [HumanResources].[Employee];
GO

if exists (SELECT 1 FROM sys.columns WHERE name = 'OrganizationLevel' and  object_id = object_id(N'[HumanResources].[Employee]'))
	ALTER TABLE [HumanResources].[Employee] DROP COLUMN [OrganizationLevel]
GO

if exists (SELECT 1 FROM sys.indexes WHERE name = 'IX_Employee_OrganizationNode' and  object_id = object_id(N'[HumanResources].[Employee]'))
	DROP INDEX IX_Employee_OrganizationNode ON [HumanResources].[Employee];
GO

if exists (SELECT 1 FROM sys.columns WHERE name = 'OrganizationNode' and  object_id = object_id(N'[HumanResources].[Employee]'))
	ALTER TABLE [HumanResources].[Employee] DROP COLUMN [OrganizationNode]
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
	EmployeeDepartmentHistory.DepartmentID,
	EmployeeDepartmentHistory.ShiftID
from
	HumanResources.Employee
	inner join Person.BusinessEntity
		on	Employee.BusinessEntityID = BusinessEntity.BusinessEntityID
	inner join Person.Person
		on	Employee.BusinessEntityID = Person.BusinessEntityID
	inner join HumanResources.EmployeeDepartmentHistory
		on	Employee.BusinessEntityID = EmployeeDepartmentHistory.BusinessEntityID
		and EmployeeDepartmentHistory.EndDate is null
	inner join HumanResources.Shift
		on	EmployeeDepartmentHistory.ShiftID = Shift.ShiftID
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[HumanResources].[Gender]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [HumanResources].[Gender]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[HumanResources].[MaritalStatus]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [HumanResources].[MaritalStatus]
GO

/* Create Tables */

CREATE TABLE [HumanResources].[Gender]
(
	[Code] nchar(1) NOT NULL,
	[Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [HumanResources].[MaritalStatus]
(
	[Code] nchar(1) NOT NULL,
	[Name] nvarchar(50) NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [HumanResources].[Gender] 
 ADD CONSTRAINT [PK_Gender]
	PRIMARY KEY CLUSTERED ([Code] ASC)
GO

ALTER TABLE [HumanResources].[MaritalStatus] 
 ADD CONSTRAINT [PK_MaritalStatus]
	PRIMARY KEY CLUSTERED ([Code] ASC)
GO

INSERT INTO HumanResources.Gender VALUES
	('M', 'Male'),
	('F', 'Female')
GO

INSERT INTO HumanResources.MaritalStatus VALUES
	('M', 'Married'),
	('S', 'Single')
GO

