using System;
using System.Collections.Generic;
using AdventureWorks.EmployeeManager.Services;

namespace AdventureWorks.EmployeeManager.Usecases
{
    public class ManageEmployees : IManageEmployees
    {
        private readonly IHumanResourcesService _humanResourcesService;

        public ManageEmployees(IHumanResourcesService humanResourcesService)
        {
            _humanResourcesService = humanResourcesService;
        }

        public IEnumerable<Gender> GetGenders() => _humanResourcesService.GetGenders();

        public IEnumerable<MaritalStatus> GetMaritalStatuses() => _humanResourcesService.GetMaritalStatuses();

        public IEnumerable<ManagedEmployee> GetManagedEmployees() => _humanResourcesService.GetManagedEmployees();

        public void ModifyManagedEmployees(IList<ManagedEmployee> updatedEmployees, IList<ManagedEmployee> newEmployees)
            => _humanResourcesService.ModifyManagedEmployees(updatedEmployees, newEmployees);
    }
}