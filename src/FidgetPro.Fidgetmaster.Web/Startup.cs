using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Database;
using FidgetPro.Fidgetmaster.Business.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FidgetPro.Fidgetmaster.Web
{
    public class Startup
    {
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
            services.AddMvc();

            services.AddTransient<IFidgetTypeRepository, SqlFidgetTypeRepository>();
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
