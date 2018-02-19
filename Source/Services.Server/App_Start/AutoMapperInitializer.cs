using System;
using AdventureWorks.EmployeeManager.Services.Server.Models;
using AutoMapper;
using Da = AdventureWorks.EmployeeManager.DatabaseAccesses;

namespace AdventureWorks.EmployeeManager.Services.Server
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateTowayMap<SalesOrderDetail, Da.SalesOrderDetail>();
            });
        }

        private static void CreateTowayMap<TLeft, TRight>(this IMapperConfigurationExpression config)
        {
            config.CreateMap<TLeft, TRight>();
            config.CreateMap<TRight, TLeft>();
        }
    }
}