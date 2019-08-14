using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Database;
using FidgetPro.Fidgetmaster.Business.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FidgetPro.Fidgetmaster.Web
{
    public class Startup
    {
        public const string JwtKey = "kevinisanamazingprogrammer";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(config => { config.RootPath = "wwwroot"; });

            services.AddDbContext<FidgetContext>(options =>
            {
                var connectionString = "Server=.;Database=fidgetmaster3000;Trusted_Connection=True;";
                options.UseSqlServer(connectionString);
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<FidgetContext>()
                .AddDefaultTokenProviders();

            var key = Encoding.ASCII.GetBytes(JwtKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            // TODO: remove at go-live
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });

            // TODO: add authorization
            services.AddAuthorization(options =>
            {
                var authBuilder =
                    new AuthorizationPolicyBuilder(
                            new List<string>()
                            {
                                JwtBearerDefaults.AuthenticationScheme
                            }.ToArray())
                        .RequireAuthenticatedUser().Build();

                options.AddPolicy("Bearer", authBuilder);
                options.DefaultPolicy = authBuilder;
            });

            services.AddMvc();

            services.AddTransient<IFidgetTypeRepository, SqlFidgetTypeRepository>();
            services.AddTransient<IFidgetRepository, SqlFidgetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSpa(config =>
            {
                config.UseProxyToSpaDevelopmentServer("http://localhost:8080");
            });
        }
    }
}
