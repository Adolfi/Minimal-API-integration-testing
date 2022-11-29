using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Minimal.Api;
using Newtonsoft.Json;
using System.Reflection;

namespace Minimal.IntegrationTests
{
    public class ProductsTests
    {
        [Test]
        public async Task When_GetProducts_Then_ResponseShouldBeExpectedProducts()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            var client = factory.CreateClient();
            var data = this.ReadFromFile("expected.json");
            var expected = JsonConvert.DeserializeObject<Product[]>(data);

            // Act
            var response = await client.GetAsync("/products");
            var actual = JsonConvert.DeserializeObject<Product[]>(await response.Content.ReadAsStringAsync());

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        public string ReadFromFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"Minimal.IntegrationTests.{fileName}"))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}


