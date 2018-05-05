using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PechShop.Data;
using PechShop.Models;

namespace PechShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddDbContext<PechShopContext>(options =>
            //        options.UseSqlite("Data Source=pech_shop.db"));

            // services.AddDbContext<PechShopContext>(options =>
            //     options.UseInMemoryDatabase("database"));

            services.AddDbContext<PechShopContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("PechShopContext")));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			
			var defaultCulture = new CultureInfo("es-UY");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);
			
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //app.UseFileServer(new FileServerOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(env.ContentRootPath, "wwwroot/node_modules")
            //    ),
            //    RequestPath = "/node_modules",
            //    EnableDirectoryBrowsing = false
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
