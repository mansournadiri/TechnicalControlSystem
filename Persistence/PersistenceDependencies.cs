using Application.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Model;
using Application.Persistence.Interface.IEntity;
using Persistence.Repo.EntityService;
namespace Persistence
{
    public static class PersistenceDependencies
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("BaseConnectionString");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(ConnectionString));
            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(o =>
             {
                 o.RequireHttpsMetadata = false;
                 o.SaveToken = true;
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidIssuer = configuration["JwtSettings:Issuer"],
                     ValidAudience = configuration["JwtSettings:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                 };
             });
            return services;
        }
    }
}
