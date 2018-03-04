using System;
using System.Collections.Generic;
using System.Linq;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class HumanResourcesService : IHumanResourcesService
    {
        private readonly ManagedEmployeeDao _managedEmployeeDao;

        private readonly GenderDao _genderDao;

        private readonly MaritalStatusDao _maritalStatusDao;

        private readonly BusinessEntityDao _businessEntityDao;

        private readonly PersonDao _personDao;

        private readonly EmployeeDao _employeeDao;

        public HumanResourcesService(ManagedEmployeeDao managedEmployeeDao, GenderDao genderDao, MaritalStatusDao maritalStatusDao, PersonDao personDao, EmployeeDao employeeDao, BusinessEntityDao businessEntityDao)
        {
            _managedEmployeeDao = managedEmployeeDao;
            _genderDao = genderDao;
            _maritalStatusDao = maritalStatusDao;
            _personDao = personDao;
            _employeeDao = employeeDao;
            _businessEntityDao = businessEntityDao;
        }

        public virtual IList<ManagedEmployee> GetManagedEmployees()
        {
            var result = new List<ManagedEmployee>();
            foreach (var managedEmployee in _managedEmployeeDao.GetManagedEmployees())
            {
                result.Add(Mapper.Map<ManagedEmployee>(managedEmployee));
            }
            return result;
        }

        public IList<Gender> GetGenders()
            => _genderDao.GetGenders().Select(Mapper.Map<Gender>).ToList();

        public IList<MaritalStatus> GetMaritalStatuses()
            => _maritalStatusDao.GetMaritalStatuses().Select(Mapper.Map<MaritalStatus>).ToList();

        public void ModifyManagedEmployees(IList<ManagedEmployee> updatedEmployees, IList<ManagedEmployee> newEmployees)
        {
            foreach (var updatedEmployee in updatedEmployees)
            {
                var person = _personDao.FindById(updatedEmployee.BusinessEntityID);
                person.FirstName = updatedEmployee.FirstName;
                person.LastName = updatedEmployee.LastName;
                person.EmailPromotion = updatedEmployee.EmailPromotion;
                person.ModifiedDate = DateTime.Now;
                _personDao.Update(person);

                var employee = _employeeDao.FindById(updatedEmployee.BusinessEntityID);
                employee.NationalIDNumber = updatedEmployee.NationalIDNumber;
                employee.LoginID = updatedEmployee.LoginID;
                employee.JobTitle = updatedEmployee.JobTitle;
                employee.BirthDate = updatedEmployee.BirthDate;
                employee.MaritalStatus = updatedEmployee.MaritalStatus;
                employee.Gender = updatedEmployee.Gender;
                employee.HireDate = updatedEmployee.HireDate;
                employee.SalariedFlag = updatedEmployee.SalariedFlag;
                employee.VacationHours = updatedEmployee.VacationHours;
                employee.SickLeaveHours = updatedEmployee.SickLeaveHours;
                employee.CurrentFlag = updatedEmployee.CurrentFlag;
                employee.ModifiedDate = DateTime.Now;
                _employeeDao.Update(employee);
            }

            foreach (var newEmployee in newEmployees)
            {
                var businessEntity = _businessEntityDao.Insert();

                var person = new Person
                {
                    BusinessEntityID = businessEntity.BusinessEntityID,
                    PersonType = "EM",
                    FirstName = newEmployee.FirstName,
                    LastName = newEmployee.LastName,
                    EmailPromotion = newEmployee.EmailPromotion,
                    ModifiedDate = DateTime.Now
                };
                _personDao.Insert(person);

                var employee = new Employee
                {
                    BusinessEntityID = businessEntity.BusinessEntityID,
                    NationalIDNumber = newEmployee.NationalIDNumber,
                    LoginID = newEmployee.LoginID,
                    JobTitle = newEmployee.JobTitle,
                    BirthDate = newEmployee.BirthDate,
                    MaritalStatus = newEmployee.MaritalStatus,
                    Gender = newEmployee.Gender,
                    HireDate = newEmployee.HireDate,
                    SalariedFlag = newEmployee.SalariedFlag,
                    VacationHours = newEmployee.VacationHours,
                    SickLeaveHours = newEmployee.SickLeaveHours,
                    CurrentFlag = newEmployee.CurrentFlag,
                    ModifiedDate = DateTime.Now
                };
                _employeeDao.Insert(employee);
            }

        }
    }
}