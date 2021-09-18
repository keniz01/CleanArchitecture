using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.WebApi
{
    /// <summary>
    /// Swagger extension methods.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Wires up custom swagger configuration to the IServiceCollection instance.
        /// </summary>
        /// <param name="services">IServiceCollection instance.</param>
        /// <returns>IServiceCollection instance.</returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Description = "Demo Company API Service",
                    Title = "Demo Company API Service",
                    TermsOfService = new Uri("https://www.demo-company.com/terms-conditions/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Demo Company",
                        Email = string.Empty,
                        Url = new Uri("https://www.demo-company.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "The MIT License",
                        Url = new Uri("https://www.demo-company.com/license"),
                    }
                });
                //options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                //{
                //    Name = "x-api-key",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Description = "Authorization by x-api-key inside request's header",
                //    Scheme = "ApiKeyScheme"
                //});

                //var key = new OpenApiSecurityScheme()
                //{
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "ApiKey"
                //    },
                //    In = ParameterLocation.Header
                //};

                //var requirement = new OpenApiSecurityRequirement
                //{
                //    { key, new List<string>() }
                //};

                //options.AddSecurityRequirement(requirement);

                var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
                options.IncludeXmlComments(xmlCommentsFilePath);
            });

            return services;
        }

        /// <summary>
        /// Wires up swagger to IApplicationBuilder instance.
        /// </summary>
        /// <param name="app">IApplicationBuilder instance.</param>
        /// <returns>IApplicationBuilder instance.</returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Service");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}