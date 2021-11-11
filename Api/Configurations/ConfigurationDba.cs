using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configurations
{
    public static class ConfigurationDba
    {
        public static IServiceCollection AddConfigurationDba(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("Libreria"), builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }));
            return services;
        }
    }
}
