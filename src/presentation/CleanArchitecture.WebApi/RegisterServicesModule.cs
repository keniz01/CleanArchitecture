using System;
using System.IO;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace CleanArchitecture.WebApi
{
    public class RegisterServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Handlers services
            //builder.RegisterAssemblyTypes(typeof(Repository).Assembly)
            //    .Where(t => t.Name.EndsWith("Handler"))
            //    .AsImplementedInterfaces();

            // Register Mediatr.
            builder.RegisterMediatR(typeof(IRequestHandler<,>).Assembly);

            var logPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.log");

            // Register serilog.
            //builder.RegisterSerilog(logPath);

            base.Load(builder);
        }
    }
}