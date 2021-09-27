using Autofac;
using CleanArchitecture.Application;
using CleanArchitecture.Persistence.Repositories;
using MediatR;
using System.Reflection;
using CleanArchitecture.Application.Continent;
using Module = Autofac.Module;

namespace CleanArchitecture.WebApi.Middleware
{
    public class RegisterServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(ContinentRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            // Register Mediatr.
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetContinentCountriesRequestHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            base.Load(builder);
        }
    }
}