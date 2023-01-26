
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Payments.Core.CustomEntities;
using Payments.Core.Interfaces.Repository;
using Payments.Core.Interfaces.Services;
using Payments.Core.Services;
using Payments.Infra.Repositories;
using System;
using System.Text;

namespace Payments.Infra.Extenssions
{
    public static class ServicesExtenssions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers().AddNewtonsoftJson(optons => { optons.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; });
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<TokenConfigure>(Configuration.GetSection("tokenManagement"));
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));

            services.AddAuthentication(x =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("tokenManagement:secret").ToString())),
                    ValidIssuer = Configuration.GetValue<string>("tokenManagement:issuer").ToString(),
                    ValidAudience = Configuration.GetValue<string>("tokenManagement:audience").ToString(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddTransient<DbContext>();
          
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, PaymentService>();

            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IAuthService, AuthServcie>();

            services.AddTransient<ICatalogRespository, CatalogRespository>();
            services.AddTransient<ICatalogService, CatalogService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}

