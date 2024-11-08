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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IPartyService, PartyService>();
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
                     ValidateLifetime = true,
                     RequireExpirationTime = true,
                     ValidateIssuer = true,
                     ValidIssuer = configuration["JwtSettings:Issuer"],
                     ValidateAudience = true,
                     ValidAudience = configuration["JwtSettings:Audience"],
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new JwtSettings().Key)),
                     TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new JwtSettings().EncryptionKey)),
                 };
                 o.Events = new JwtBearerEvents
                 {
                     OnMessageReceived = async (context) =>
                     {
                         await Task.CompletedTask;
                     },
                     OnTokenValidated = async (context) =>
                     {
                         var _claims = context.Principal.Claims;
                         Guid userGuid = Guid.Parse(_claims.Where(x => x.Type == "guid").FirstOrDefault().Value);
                        //context.Fail(userGuid.ToString());
                         //await Task.CompletedTask;
                     }
                 };
             });
            return services;
        }
    }
}
