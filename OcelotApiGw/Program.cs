using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

new WebHostBuilder()
           .UseKestrel()
           .UseContentRoot(Directory.GetCurrentDirectory())
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               config
                   .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                   .AddJsonFile("appsettings.json", true, true)
                   .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                   .AddJsonFile("ocelot.json")
                   .AddEnvironmentVariables();
           })
           .ConfigureServices(s =>
           {
               s.AddOpenTelemetryTracing(config => config
               .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Gateway"))
               .AddOtlpExporter(c =>
               {
                   c.Endpoint = new Uri("http://localhost:4317");
               })
               .AddSqlClientInstrumentation(opt => opt.SetDbStatementForText = true)
               .AddAspNetCoreInstrumentation());
               var authenticationProviderKey = "IdentityApiKey";
               s.AddAuthentication()
               .AddJwtBearer(authenticationProviderKey, x =>
               {
                   x.Authority = "https://localhost:7036";//identity server
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false
                   };
               });
               s.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
           })
           .ConfigureLogging((hostingContext, logging) =>
           {
               //add your logging
           })
           .UseIISIntegration()
           .Configure(app =>
           {

               app.UseOcelot().Wait();
           })
           .Build()
           .Run();