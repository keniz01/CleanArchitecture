using Autofac;

namespace CleanArchitecture.WebApi
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterModule<RegisterServicesModule>();
            return builder;
        }
    }
}