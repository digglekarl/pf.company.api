using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Config;
using api.Middleware;
using api.Repositories;
using api.Repositories.Helper;
using api.Repositories.Interfaces;
using api.Services;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                    ClockSkew = Debugger.IsAttached ? TimeSpan.Zero : TimeSpan.FromSeconds(int.Parse(Configuration["Jwt:ExpirationTime"]))
                };
            });

            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
            });

            services.Configure<Jwt>(Configuration.GetSection("Jwt"));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDividendService, DividendService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IBaseRepository, DividendRepository>();
            services.AddTransient<IBaseRepository, InvoiceRepository>();
            services.AddTransient<IBaseRepository, ExpenseRepository>();
            services.AddTransient<IBaseRepository, CompanyRepository>();
            services.AddTransient<IBaseRepository, DocumentRepository>();
            services.AddTransient<IBaseRepository, FileRepository>();

            services.AddTransient<IDapperExecutor, DapperExecutor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
