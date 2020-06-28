using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiCosmosDbSample.Data;
using WebApiCosmosDbSample.Infrastructure;
using WebApiCosmosDbSample.Services;

namespace WebApiCosmosDbSample
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
            //Bind the application settings
            var cosmosDbSettingsConfiguration = Configuration.GetSection("CosmosDb");
            services.Configure<CosmosDbSettings>(cosmosDbSettingsConfiguration);
            var cosmosDbSettings = cosmosDbSettingsConfiguration.Get<CosmosDbSettings>();

            //Add EntityFramework
            services.AddEntityFrameworkCosmos();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseCosmos(
                    cosmosDbSettings.Endpoint,
                    cosmosDbSettings.Key,
                    cosmosDbSettings.DatabaseName);
            });
            services.AddScoped<INewsService, NewsService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
