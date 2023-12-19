using System.Text;
using DescomplicaEventos.Application.Interfaces;
using DescomplicaEventos.Application.Mappings;
using DescomplicaEventos.Application.Services;
using DescomplicaEventos.Domain.Account;
using DescomplicaEventos.Domain.Interfaces;
using DescomplicaEventos.Infra.Data.Context;
using DescomplicaEventos.Infra.Data.Identity;
using DescomplicaEventos.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

            services.AddAuthentication(opt => 
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>{
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAutoMapper(typeof(DomainMapperProfile));
            
            //Services
            services.AddTransient<IAuthenticate, AuthenticateService>();
            services.AddTransient<IUserService, UserService>();

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            

            return services;
        }
    }
}