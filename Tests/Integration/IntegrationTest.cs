using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;

namespace Tests.Integration;

public class IntegrationTest
{
    private HttpClient _httpClient;
    public IntegrationTest()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task DefaultIntegrationTest()
    {
        var response = await _httpClient.GetAsync("");
        var stringResult = await response.Content.ReadAsStringAsync();

        Assert.Equal("Hello World!", stringResult);
    }

    [Fact]
    public void SQLIte_Database_Created()
    {
        var sqliteDbPath = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), searchPattern: "*.db").SingleOrDefault();
        string expectedFilename = "diathesea.db";

        var file = new FileInfo(sqliteDbPath);

        Assert.Equal(expectedFilename, file.Name);
    }
}