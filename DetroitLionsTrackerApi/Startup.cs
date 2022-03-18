using DetroitLionsTrackerApi.BusinessLayer;
using DetroitLionsTrackerApi.BusinessLayer.Interfaces;
using DetroitLionsTrackerApi.Config;
using DetroitLionsTrackerApi.DataLayer;
using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace DetroitLionsTrackerApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string SwaggerVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .AddResponseCompression()
                .Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)))
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());

                    options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            // Add Business, Data, and Service Layers
            services.AddTransient<ISeasonBusinessLayer, SeasonBusinessLayer>();
            services.AddTransient<ISeasonDataLayer, SeasonDataLayer>();
            services.AddTransient<IGameBusinessLayer, GameBusinessLayer>();
            services.AddTransient<IGameDataLayer, GameDataLayer>();

            var connectionStrings = new ConnectionStrings();
            Configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);

            services.AddDbContext<DetroitLionsTrackerDbContext>(options =>
                   options.UseMySql(connectionStrings.DetroitLionsTrackerDbContext, new MySqlServerVersion(new Version())));

            services.AddHttpClient();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion,
                    new OpenApiInfo { Title = nameof(DetroitLionsTrackerApi), Version = SwaggerVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{SwaggerVersion}/swagger.json", $"{nameof(DetroitLionsTrackerApi)} {SwaggerVersion}");
            });

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
