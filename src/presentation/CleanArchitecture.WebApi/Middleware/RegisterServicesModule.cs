using Autofac;
using CleanArchitecture.Application.Continent;
using CleanArchitecture.Persistence.Repositories;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace CleanArchitecture.WebApi.Middleware
{
    public class RegisterServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return serviceType => componentContext.Resolve(serviceType);
            });

            builder.RegisterAssemblyTypes(typeof(ContinentRepository).Assembly)
                .Where(serviceType => serviceType.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // Register Mediator.
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetContinentCountriesRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            base.Load(builder);
        }
    }
}