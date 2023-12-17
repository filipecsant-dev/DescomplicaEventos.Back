using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.Mappings;
using DescomplicaEventos.Application.Services;
using DescomplicaEventos.Domain.Interfaces;
using DescomplicaEventos.Infra.Data.Context;
using DescomplicaEventos.Infra.Data.Repositories;
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


            services.AddAutoMapper(typeof(DomainMapperProfile));
            
            //Services
            services.AddTransient<IUserService, UserService>();

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            

            return services;
        }
    }
}