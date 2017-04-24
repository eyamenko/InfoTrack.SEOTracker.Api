using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InfoTrack.SEOTracker.Api.Data;
using InfoTrack.SEOTracker.Api.Contracts.Data;
using InfoTrack.SEOTracker.Api.Contracts.Services;
using InfoTrack.SEOTracker.Api.Services;

namespace InfoTrack.SEOTracker.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            #region Data

            services.AddSingleton<IConnectionFactory, ConnectionFactory>(_ => new ConnectionFactory(Configuration.GetConnectionString("mongodb")));
            services.AddSingleton<ISearchResultDbContext, SearchResultDbContext>();

            #endregion

            #region Services

            services.AddSingleton<ISearchResultService, SearchResultService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
        }
    }
}