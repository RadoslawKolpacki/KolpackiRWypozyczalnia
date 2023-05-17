using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Models;

namespace KolpackiRWypozyczalnia
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
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<IdentityAppContext>();
            services.AddControllersWithViews();

            /// builder.Services.AddDbContext<FilmsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

            /// dodawanie Contextu
            services.AddDbContext<FilmsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDB")));
            services.AddDbContext<IdentityAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDB")));

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Kategorie",
                    pattern: "Category/{categoryName}",
                    defaults: new { controller = "Films", action = "FilmsList"}
                    );

                endpoints.MapControllerRoute(
                    name: "StronyStatyczne",
                    pattern: "Info/{nazwa}",
                    defaults: new { controller="Home", action="StronyStatyczne" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
