namespace Dotin.URLManagement.EndPoints.URLViewerAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Configuration;
    using Dotin.URLManagement.Infra.DAL.DatabaseContexts;
    using Microsoft.EntityFrameworkCore;
    using Dotin.URLManagement.Infra.DAL.URLViewer.Repositories;
    using Dotin.URLManagement.Core.Contracts.URLViewer;
    using Dotin.URLManagement.Core.ApplicationServices.URLViewer;

    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<URLManagementDbContext>(opt => {
                opt.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
            });

            services.AddScoped<IURLViewerRepository, URLViewerRepository>();            
            services.AddScoped<IURLViewerService, URLViewerService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<URLManagementDbContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
