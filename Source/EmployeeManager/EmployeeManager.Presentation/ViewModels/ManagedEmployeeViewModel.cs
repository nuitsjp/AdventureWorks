using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public class ManagedEmployeeViewModel : MonitorPropertyUpdatedObject
    {
        public ManagedEmployee ManagedEmployee { get; }

        public ManagedEmployeeViewModel()
        {
            ManagedEmployee = new ManagedEmployee();
            SetEditStatus(EditStatus.Created);
        }

        public ManagedEmployeeViewModel(ManagedEmployee managedEmployee)
        {
            ManagedEmployee = managedEmployee;
            Mapper.Map(ManagedEmployee, this);
            SetEditStatus(EditStatus.UnUpdated);
        }

        [MonitorProperties]
        public virtual int BusinessEntityID { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string FirstName { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string LastName { get; set; }

        [MonitorProperties]
        [Required]
        public virtual int EmailPromotion { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string NationalIDNumber { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string LoginID { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string JobTitle { get; set; }

        [MonitorProperties]
        [Required]
        public virtual DateTime? BirthDate { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string MaritalStatus { get; set; }

        [MonitorProperties]
        [Required]
        public virtual string Gender { get; set; }

        [MonitorProperties]
        [Required]
        public virtual DateTime? HireDate { get; set; }

        [MonitorProperties]
        [Required]
        public virtual bool SalariedFlag { get; set; }

        [MonitorProperties]
        [Required]
        public virtual short VacationHours { get; set; }

        [MonitorProperties]
        [Required]
        public virtual short SickLeaveHours { get; set; }

        [MonitorProperties]
        [Required]
        public virtual bool CurrentFlag { get; set; }

        [MonitorProperties]
        [Required]
        public virtual short DepartmentID { get; set; }

        [MonitorProperties]
        [Required]
        public virtual byte ShiftID { get; set; }

        public void Commit()
        {
            Mapper.Map(this, ManagedEmployee);
        }
    }
}
