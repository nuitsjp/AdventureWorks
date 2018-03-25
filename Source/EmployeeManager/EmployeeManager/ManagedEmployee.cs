using System;

namespace AdventureWorks.EmployeeManager
{
    /// <summary>
    /// 管理対象の従業員
    /// </summary>
    public class ManagedEmployee
    {
        public virtual int BusinessEntityID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int EmailPromotion { get; set; }
        public virtual string NationalIDNumber { get; set; }
        public virtual string LoginID { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual bool SalariedFlag { get; set; }
        public virtual short VacationHours { get; set; }
        public virtual short SickLeaveHours { get; set; }
        public virtual bool CurrentFlag { get; set; }
    }
}