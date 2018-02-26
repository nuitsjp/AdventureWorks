using System;

namespace AdventureWorks.EmployeeManager
{
    /// <summary>
    /// 管理対象の従業員
    /// </summary>
    public class ManagedEmployee
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int BusinessEntityID { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public virtual string LastName { get; set; }
        public virtual int EmailPromotion { get; set; }
        public virtual string NationalIDNumber { get; set; }
        public virtual string LoginID { get; set; }
        public virtual string JobTitle { get; set; }
        /// <summary>
        /// 生年月日
        /// </summary>
        public virtual DateTime BirthDate { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual bool SalariedFlag { get; set; }
        public virtual short VacationHours { get; set; }
        public virtual short SickLeaveHours { get; set; }
        public virtual bool CurrentFlag { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual byte PayFrequency { get; set; }
        public virtual string GroupName { get; set; }
        public virtual string DepartmentName { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual string ShiftName { get; set; }
        public virtual DateTime BusinessEntityModifiedDate { get; set; }
    }
}