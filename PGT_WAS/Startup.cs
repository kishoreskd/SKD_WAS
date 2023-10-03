using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WAS.Interface;
using WAS.Context.Admin;
using WAS.Context.Manager;
using WAS.Context.Login;
using WAS.Context;

using WAS.JWTToken;
using WAS.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using WAS.Context.Repository;

//using Newtonsoft.Json;

namespace PGT_WAS
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
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(Configuration.GetConnectionString("connection")));

            services.AddSession(option =>
            {
                option.IdleTimeout = System.TimeSpan.FromDays(6);
                option.Cookie.Name = ".pgt_was";
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                };
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddScoped<IJWTRepository, JWTTokenRepository>();
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped<IDesignationContext, DesignationContext>();
            services.AddScoped<IDepartmentContext, DepartmentContext>();
            services.AddScoped<ILocationContext, LocationContext>();
            services.AddScoped<IHolidayContext, HolidayContext>();
            services.AddScoped<IRoleContext, RoleContext>();

            services.AddScoped<IProjectContext, ProjectContext>();
            services.AddScoped<IProjectEstimationContext, ProjectEstimationContext>();
            services.AddScoped<ILoginContext, LoginContext>();

            services.AddScoped<IUnitOfWork, UnitOfWorkContext>();

            //Handling selef referencing entity json creation 
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};

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

            app.UseSession();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                string token = context.Session.GetString("token");

                if (!COM.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", $"Bearer {token}");
                }

                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            #region Vital

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{area=Employees}/{controller=Home}/{action=Index}/{id?}");

            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute
            //    (
            //        name: "default",
            //        pattern: "{area=Admin}/{controller=Admin}/{action=Index}/{id?}"
            //    );
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{area=Manager}/{controller=Dashbord}/{action=Index}/{id?}");

            //});

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Login}/{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
