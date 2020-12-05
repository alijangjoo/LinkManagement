namespace Dotin.URLManagement.EndPoints.URLShortenerAPI
{
    using Dotin.URLManagement.Core.ApplicationServices.URLShortener;
    using Dotin.URLManagement.Core.Contracts.URLShortener;
    using Dotin.URLManagement.Infra.DAL.URLShortener.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Configuration;
    using Dotin.URLManagement.Infra.DAL.DatabaseContexts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Dotin.URLManagement.Core.URLGenerator;

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

            services.AddScoped<IURLShortenerRepository, URLShortenerRepository>();
            services.AddScoped<IURLGenerator<Guid>, GuidGenerator>();
            services.AddScoped<IURLShortenerService, URLShortenerService>();
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
