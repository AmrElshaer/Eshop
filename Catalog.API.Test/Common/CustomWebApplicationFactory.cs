using Catalog.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.API.Test.Common
{
    public class CustomWebApplicationFactory: WebApplicationFactory<Program> 
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // Create a new service provider.
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    // Add a database context using an in-memory 
                    // database for testing.
                    services.AddDbContext<CatalogDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database
                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<CatalogDbContext>();
                    // Ensure the database is created.
                    context.Database.EnsureCreated();
                   
                })
                .UseEnvironment("Test");
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }

      

        
    }
}
