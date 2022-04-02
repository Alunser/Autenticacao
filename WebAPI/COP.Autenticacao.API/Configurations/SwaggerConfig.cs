using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace COP.Autenticacao.API.Configurations
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Autenticacao - V1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Description = "Insira o token desta maneira: Basic {seu token}",
                    Name = "Authorization",
                    Scheme = "Basic",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new string[] {}
                    }
                });

                var filePath = Path.Combine(@"Documentation/COP.Autenticacao.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(sw =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(sw.RoutePrefix) ? "." : "..";
                sw.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Autenticacao - V1");
                sw.RoutePrefix = string.Empty;
            });
        }
    }
}
