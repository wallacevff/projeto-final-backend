using Microsoft.Extensions.Configuration;

namespace ProjetoFinalBackend.Infra.CrossCutting.Configurations;

public class DbContextConfiguration
{
    public const string ConnectionStrings = "ConnectionStrings";

    [ConfigurationKeyName("DefaultConnection")]
    public string DefaultConnection { get; set; } = string.Empty;
}