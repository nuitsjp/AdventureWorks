using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;
using Castle.DynamicProxy;
using SimpleInjector;
using SimpleInjector.Extras.DynamicProxy;
using SimpleInjector.Integration.Wcf;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public static class Bootstrapper
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        private static readonly Func<Type, object, IInterceptor[], object> CreateProxy =
            (p, t, i) => Generator.CreateInterfaceProxyWithTarget(p, t, i);

        public static Container Container;

        static Bootstrapper()
        {
            InitMapper();
            BuildContainer();
        }

        private static void InitMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateTowayMap<ManagedEmployee, DatabaseAccesses.ManagedEmployee>();
                config.CreateMap<DatabaseAccesses.Gender, Gender>();
                config.CreateMap<DatabaseAccesses.MaritalStatu, MaritalStatus>();
            });
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

            container.Intercept<IAuthenticationService>(typeof(TransactionInterceptor));
            container.Intercept<IHumanResourcesService>(typeof(TransactionInterceptor), typeof(AuthenticationInterceptor));

            // Services
            TransactionContext.SetOpenConnection(OpenConnection);
            container.Register<ITransactionContext, TransactionContext>(Lifestyle.Scoped);
            container.Register<AuthContext>(Lifestyle.Scoped);
            container.Register<IAuthenticationService, AuthenticationService>(Lifestyle.Scoped);
            container.Register<IHumanResourcesService, HumanResourcesService>(Lifestyle.Scoped);

            // DatabaseAccesses
            container.Register<GenderDao>(Lifestyle.Scoped);
            container.Register<MaritalStatusDao>(Lifestyle.Scoped);
            container.Register<BusinessEntityDao>(Lifestyle.Scoped);
            container.Register<PersonDao>(Lifestyle.Scoped);
            container.Register<EmployeeDao>(Lifestyle.Scoped);
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


        private static void InterceptWith<TServiceInterface>(this Container c, params Type[] interceptorTypes)
            where TServiceInterface : class
        {
            c.ExpressionBuilt += (s, e) =>
            {
                if (e.RegisteredServiceType.GetInterfaces().Any(x => x == typeof(TServiceInterface)))
                {
                    var interceptorExpression = BuildInterceptorExpressions(c, interceptorTypes);

                    e.Expression = Expression.Convert(
                        Expression.Invoke(Expression.Constant(CreateProxy),
                            Expression.Constant(typeof(TServiceInterface), typeof(Type)),
                            e.Expression,
                            interceptorExpression),
                        typeof(TServiceInterface));
                }
            };
        }

        private static Expression BuildInterceptorExpressions(Container container, params Type[] interceptorTypes)
        {
            return Expression.NewArrayInit(
                typeof(IInterceptor),
                interceptorTypes.Select(x => BuildInterceptorExpression(container, x)).ToArray());
        }

        private static Expression BuildInterceptorExpression(Container container, Type interceptorType)
        {
            var interceptorRegistration = container.GetRegistration(interceptorType);

            if (interceptorRegistration == null)
            {
                // This will throw an ActivationException
                container.GetInstance(interceptorType);
            }

            return interceptorRegistration.BuildExpression();
        }
    }
}