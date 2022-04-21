using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
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
           .ConfigureServices(s => {
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