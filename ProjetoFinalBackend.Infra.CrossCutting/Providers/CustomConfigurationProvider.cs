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
        if (environmentName == Environments.Development)
        {
            path = Path.Combine("ConfigurationJsonFiles", "appsettings.Development.json");
            return new ConfigurationBuilder().AddJsonFile(path).Build();
        }
        path = Path.Combine("ConfigurationJsonFiles", "appsettings.json");
        return new ConfigurationBuilder().AddJsonFile(path).Build();
    }
}
