using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitecture.WebApi.Middleware
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}