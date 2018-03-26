using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using PropertyChanged;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ManagedEmployeeViewModel : INotifyPropertyChanged
    {
        private readonly ManagedEmployee _managedEmployee;

        public EditStatus EditStatus { get; private set; }

        public virtual int BusinessEntityID { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual int EmailPromotion { get; set; }

        [Required]
        public virtual string NationalIDNumber { get; set; }

        [Required]
        public virtual string LoginID { get; set; }

        [Required]
        public virtual string JobTitle { get; set; }

        [Required]
        public virtual DateTime? BirthDate { get; set; }

        [Required]
        public virtual string MaritalStatus { get; set; }

        [Required]
        public virtual string Gender { get; set; }

        [Required]
        public virtual DateTime? HireDate { get; set; }

        [Required]
        public virtual bool SalariedFlag { get; set; }

        [Required]
        public virtual short VacationHours { get; set; }

        [Required]
        public virtual short SickLeaveHours { get; set; }

        [Required]
        public virtual bool CurrentFlag { get; set; }

        public ManagedEmployeeViewModel()
        {
            _managedEmployee = new ManagedEmployee();
            EditStatus = EditStatus.New;
        }

        public ManagedEmployeeViewModel(ManagedEmployee managedEmployee)
        {
            _managedEmployee = managedEmployee;
            EditStatus = EditStatus.UnModified;
            Mapper.Map(managedEmployee, this);
            PropertyChanged += ChangedProperty;
        }

        private void ChangedProperty(object sender, PropertyChangedEventArgs e)
        {
            if (EditStatus == EditStatus.UnModified 
                && e.PropertyName != nameof(EditStatus))
            {
                EditStatus = EditStatus.Modified;
            }
        }

        public ManagedEmployee Commit()
        {
            Mapper.Map(this, _managedEmployee);
            EditStatus = EditStatus.UnModified;
            return _managedEmployee;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
