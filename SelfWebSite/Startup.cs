using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SelfWebSite.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfWebSite.Services;

namespace SelfWebSite
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options =>
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                    options.SignIn.RequireConfirmedAccount = true;
                    //добавление своего кастомного ключа для на хранение токенов по времени
                    options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                        new TokenProviderDescriptor(
                            typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)));
                    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                    ////////////////////////////////////////////////////////
                })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //добавление своего кастомного ключа для на хранение токенов по времени
            services.AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();
            //////////////////////////////////////////////////////////
            //установка хранения кук с токеном на восстановление пароля  5 дней
            services.ConfigureApplicationCookie(o => {
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
            });
            //The following code changes all data protection tokens timeout period to 3 hours:
            services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));

            //services.AddDefaultIdentity<IdentityUser>(
            //        options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            //подключение сервиса отсылки писем с подтверждением через SenderGreed
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
