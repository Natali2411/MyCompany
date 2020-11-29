using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCompany.Service;

namespace MyCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            // підключаємо конфіг із appsettings.json
            Configuration.Bind("Project", new Config());
            // add supporting of controllers and views (MVC)
            services.AddControllersWithViews()
                // set compatibility with asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // !!! порядок реєстрації middleware(services) дуже важливий
            // в процесі розробки нам важливо бачити інформацію про помилки
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // підключаємо підтримку статичних файлів (css, js, etc.)
            app.UseStaticFiles();

            // реєструємо потрібні нам маршрути (ендпоінти)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
