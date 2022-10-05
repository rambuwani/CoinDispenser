using Coin.Dispenser.Configurations;
using Coin.Dispenser.DataAccess;
using Coin.Dispenser.Services.Implementation;
using Coin.Dispenser.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Coin.Dispenser.DTO;
using Coin.Dispenser.DataAccess.Models;
using FluentValidation.AspNetCore;

namespace Coin.Dispenser
{
    public class Startup
    {
        private const string AllowSpecificOrigins = "AllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews()
           .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
           .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());


            InitialiseCors(services);
            InitialiseConfiguration(services);
            InitialiseAuthentication(services);
            InitialiseSwagger(services);
            services.AddScoped<IDispenserService, DispenserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<IPasswordHasher<UserDetailsDto>, PasswordHasher<UserDetailsDto>>();
            services.AddDbContext<CoinDispenserDataContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDb")));

        }
        private static void InitialiseSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Coin.Dispenser",
                        Version = "v1"
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        System.Array.Empty<string>()
                    }
                });
            });
        }
        private void InitialiseCors(IServiceCollection services)
        {

            var corsOpts = Configuration
                         .GetSection("Cors")
                         .Get<CorsOptions>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                    builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(corsOpts.GetAllowedOriginsAsArray()));
            });
        }

        private void InitialiseConfiguration(IServiceCollection services)
        {
            services.Configure<JwtOptions>(Configuration.GetSection("Jwt"));

        }

        private void InitialiseAuthentication(IServiceCollection services)
        {
            var jwtOpt = Configuration
                         .GetSection("Jwt")
                         .Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtOpt.Audience,
                    ValidIssuer = jwtOpt.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt.Key))
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coin.Dispenser v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
