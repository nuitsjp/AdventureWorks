using AdventureWorks.EmployeeManager.Services.Models;
using AutoMapper;
using DA = AdventureWorks.EmployeeManager.DatabaseAccesses;

namespace AdventureWorks.EmployeeManager.Services
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.CreateTowayMap<Employee, DA.Employee>();
            });
        }

        private static void CreateTowayMap<TLeft, TRight>(this IProfileExpression config)
        {
            config.CreateMap<TLeft, TRight>();
            config.CreateMap<TRight, TLeft>();
        }
    }
}