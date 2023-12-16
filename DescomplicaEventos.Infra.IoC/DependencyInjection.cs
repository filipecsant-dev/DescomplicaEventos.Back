using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DescomplicaEventos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DescomplicaEventos.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConexao = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            return services;
        }
    }
}