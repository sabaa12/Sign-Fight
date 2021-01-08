
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sign2FightApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Models.Data;
using Service.Identity;
using Domain.Models.Data.Interfaces.Repositories;
using Domain.Interfaces.Repositories;
using Service.Causes;
using Microsoft.AspNetCore.Http;

namespace Sign2FightApi.infrastructure
{
    public static class ServiceCollectionExtencions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
              .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,ApplicationSetings setings)
        {
            var key = Encoding.ASCII.GetBytes(setings.secret);

            services.
               AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
            .AddScoped(typeof(IIdentityRepository), typeof(IdentityRepository))
            .AddTransient<IIdentityService, IdentityService>()
            .AddScoped(typeof(ICauseRepository), typeof(CauseRepository))
            .AddTransient<ICausesService, CausesService>()
            .AddScoped(typeof(ISubScribesRepository), typeof(SubScribesRepository))
            .AddTransient<ISubscribesService, SubscribesService>();


    }
}
