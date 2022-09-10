using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TripleG.Areas.Identity;
using TripleG.Server;
using TripleG.Server.Controllers;
using TripleG.Server.Data;
using TripleG.Server.Models;

namespace TripleG
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=tgs.db"));
            services.AddIdentity<IdentityUser, Role>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddScoped<StudentController>();
            services.AddScoped<StaffsController>();
            services.AddScoped<AuthenticationController>();
            services.AddScoped<ContactController>();
            services.AddScoped<ParentController>();
            services.AddScoped<ResultController>();
            services.AddScoped<RoleController>();
            services.AddScoped<StudentHubController>();
            services.AddScoped<StudentResultController>();
            services.AddScoped<SubjectController>();
            services.AddScoped<UploadController>();
            services.AddScoped<UserRole>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager,
        RoleManager<Role> roleManager)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
            env.EnvironmentName = "ASPNETCORE_ENVIRONMENT";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // IntitializeDb.SeedData(userManager, roleManager);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles")
            //});
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
