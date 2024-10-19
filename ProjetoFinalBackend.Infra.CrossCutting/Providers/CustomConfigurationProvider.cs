using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ProjetoFinalBackend.Infra.CrossCutting.Providers;

public static class CustomConfigurationProvider
{
    public static IConfiguration GetConfiguration()
    {
        string path = Path.Combine("ConfigurationJsonFiles", "appsettings.json");
        return new ConfigurationBuilder().AddJsonFile(path).Build();
    }

    public static IConfiguration GetConfiguration(IHostEnvironment environmentName)
    {
        string path;
        if (environmentName.IsDevelopment())
        {
            path = Path.Combine("ConfigurationJsonFiles", "appsettings.Development.json");
            return new ConfigurationBuilder().AddJsonFile(path).Build();
        }
        path = Path.Combine("ConfigurationJsonFiles", "appsettings.json");
        return new ConfigurationBuilder().AddJsonFile(path).Build();
    }

    public static IConfiguration GetConfiguration(string environmentName)
    {
        string path;
        switch (environmentName)
        {
            case "Development": 
                path = Path.Combine("ConfigurationJsonFiles", $"appsettings.{Environments.Development}.json");
                return new ConfigurationBuilder().AddJsonFile(path).Build();
            case "Staging":
                path = Path.Combine("ConfigurationJsonFiles", $"appsettings.{Environments.Staging}.json");
                return new ConfigurationBuilder().AddJsonFile(path).Build();
            default:
                path = Path.Combine("ConfigurationJsonFiles", "appsettings.json");
                return new ConfigurationBuilder().AddJsonFile(path).Build();
        }
    }
}
