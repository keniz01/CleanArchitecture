using System;
using Microsoft.Extensions.DependencyInjection;

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