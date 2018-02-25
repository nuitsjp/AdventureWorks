using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AdventureWorks.EmployeeManager.Transaction;
using AutoMapper;
using Castle.DynamicProxy;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public static class Bootstrapper
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        private static readonly Func<Type, object, IInterceptor, object> CreateProxy =
            (p, t, i) => Generator.CreateInterfaceProxyWithTarget(p, t, i);

        public static Container Container;

        static Bootstrapper()
        {
            InitMapper();
            BuildContainer();
        }

        private static void InitMapper()
        {
            Mapper.Initialize(config => config.CreateTowayMap<ManagedEmployee, DatabaseAccesses.ManagedEmployee>());
        }

        private static void CreateTowayMap<TLeft, TRight>(this IProfileExpression config)
        {
            config.CreateMap<TLeft, TRight>();
            config.CreateMap<TRight, TLeft>();
        }

        private static void BuildContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            container.InterceptWith<ServiceInterceptor>();

            // Services
            TransactionContext.SetOpenConnection(OpenConnection);
            container.Register<ITransactionContext, TransactionContext>(Lifestyle.Scoped);
            container.Register<AuthContext>(Lifestyle.Scoped);
            container.Register<EmployeeService>(Lifestyle.Scoped);

            // DatabaseAccesses
            container.Register<ManagedEmployeeDao>(Lifestyle.Scoped);

            container.Verify();
            Container = container;
        }

        private static IDbConnection OpenConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            connection.Open();

            return connection;
        }



        private static void InterceptWith<TInterceptor>(this Container c)
            where TInterceptor : class, IInterceptor
        {
            c.ExpressionBuilt += (s, e) =>
            {
                if (e.RegisteredServiceType == typeof(EmployeeService))
                {
                    var interceptorExpression =
                        c.GetRegistration(typeof(TInterceptor), true).BuildExpression();

                    e.Expression = Expression.Convert(
                        Expression.Invoke(Expression.Constant(CreateProxy),
                            Expression.Constant(typeof(IEmployeeService), typeof(Type)),
                            e.Expression,
                            interceptorExpression),
                        typeof(IEmployeeService));
                }
            };
        }
    }
}