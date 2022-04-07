using Catalog.API.Entities;
using Catalog.API.Test.Common;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace Catalog.API.Test.Controllers.Catalogs
{
    public class GetAllProducts :IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public GetAllProducts(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client =  _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/v1/Catalog");

            response.EnsureSuccessStatusCode();
            var res=await Utilities.GetResponseContent<IEnumerable<Product>>(response);
            res.Should().NotBeNullOrEmpty();
            res.Should().HaveCount(6);
        }
    }
}
