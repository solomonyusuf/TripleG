using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Triapp.Server;
using Triapp.Server.Controllers;
using Triapp.Server.Data;

namespace Triapp
{
    public static class Startup
    {
        public static IServiceProvider? Services { get; private set; }

        public static void Init()
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureServices(WireupServices)
                           .Build();
            Services = host.Services;
        }

        private static void WireupServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddWpfBlazorWebView();
            services.AddTransient<IntitializeDb>();
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlite("Filename=tgs.db"));
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

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif
        }
    }
}