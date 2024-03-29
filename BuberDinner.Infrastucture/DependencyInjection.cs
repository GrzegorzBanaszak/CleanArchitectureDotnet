﻿using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastucture.Authentication;
using BuberDinner.Infrastucture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastucture.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;

namespace BuberDinner.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuth(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
            return services;
        }

    }
}
