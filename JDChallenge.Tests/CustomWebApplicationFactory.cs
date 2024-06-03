using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace JDChallenge.Tests;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("CONNECTION_STRING", "Server=localhost,1433;Database=JDChallenge;User=sa;Password=Pass123$;TrustServerCertificate=true;");
        Environment.SetEnvironmentVariable("ELASTICSEARCH_SERVER", "http://localhost:9200");
        Environment.SetEnvironmentVariable("KAFKA_SERVER", "localhost:9092");
    }
}