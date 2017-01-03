namespace ReminderAPIApplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;
    using Swashbuckle.Swagger.Model;
    using Models;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
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

            // Inject an implementation of ISwaggerProvider with default settings applied
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
              options.SingleApiVersion(new Info
              {
                Version = "v1",
                Title = "Todo API",
                Description = "A tryout to see if this works",
                TermsOfService = "None",
                Contact = new Contact { Name = "Gerben Heinen", Email = "", Url = "" },
                License = new License { Name = "User under LICX", Url = "http://url.com" }
              });

              // Determine base path for the application
              var basePath = PlatformServices.Default.Application.ApplicationBasePath;

              // Set the comments path for the swagger json and ui
              var xmlPath = Path.Combine(basePath,"ReminderAPIApplication.xml");
              options.IncludeXmlComments(xmlPath);
              options.DescribeAllEnumsAsStrings();
            });

            services.AddSingleton<IReminderRepository,ReminderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
        }
    }
}
