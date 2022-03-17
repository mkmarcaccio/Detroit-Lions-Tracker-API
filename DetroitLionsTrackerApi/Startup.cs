using DetroitLionsTrackerApi.Config;
using DetroitLionsTrackerApi.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

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
                .Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)))
                .AddControllers();


            //const string businessLayerAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(BusinessLayer);
            //const string businessLayerInterfacesAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(BusinessLayer) + ".Interfaces";
            //services.AddTransientsFromAssemblies(businessLayerInterfacesAssemblyName, businessLayerAssemblyName);

            //const string dataLayerAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(DataLayer);
            //const string dataLayerInterfacesAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(DataLayer) + ".Interfaces";
            //services.AddTransientsFromAssemblies(dataLayerInterfacesAssemblyName, dataLayerAssemblyName);

            //const string serviceLayerAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(ServiceLayer);
            //const string serviceLayerInterfacesAssemblyName = nameof(DetroitLionsTrackerApi) + "." + nameof(ServiceLayer) + ".Interfaces";
            //services.AddTransientsFromAssemblies(serviceLayerInterfacesAssemblyName, serviceLayerAssemblyName);

            var connectionStrings = new ConnectionStrings();
            Configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);

            services.AddDbContext<DetroitLionsTrackerDbContext>(options =>
                   options.UseMySql(connectionStrings.DetroitLionsTrackerDbContext, new MySqlServerVersion(new Version())));

            var appSettings = Configuration.GetSection("AppSettings");

            // services.AddHttpClient();

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

    //[ExcludeFromCodeCoverage]
    //internal static class ServiceCollectionExtensions
    //{
    //    public static void AddTransientsFromAssemblies(this IServiceCollection services, string interfaceAssemblyName, string implAssemblyName)
    //    {
    //        var possibleImpls = Assembly.Load(implAssemblyName).ExportedTypes.ToArray();

    //        foreach (var iface in GetInterfaces(interfaceAssemblyName))
    //        {
    //            if (Array.Find(possibleImpls, type => Implements(iface, type)) is Type implementor)
    //            {
    //                services.AddTransient(iface, implementor);
    //            }
    //        }
    //    }

    //    private static IEnumerable<Type> GetInterfaces(string assemblyName) =>
    //        Assembly.Load(assemblyName).ExportedTypes.Where(type => type.IsInterface);

    //    private static bool Implements(Type interfaceType, Type type) =>
    //        type.GetInterfaces().Any(iface => iface == interfaceType)
    //        || type.BaseType != null && Implements(interfaceType, type.BaseType);
    //}
}
