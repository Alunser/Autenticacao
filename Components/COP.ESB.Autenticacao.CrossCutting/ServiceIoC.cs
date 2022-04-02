using COP.Autenticacao.Domain.Logins.Handlers;
using COP.Autenticacao.Domain.Logins.Interfaces.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace COP.ESB.Autenticacao.CrossCutting
{
    public static class ServiceIoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            #region Handlers
            services.AddScoped<IValidarPasswordHandler, ValidarPasswordHandler>();
            #endregion

            return services;
        }
    }
}
