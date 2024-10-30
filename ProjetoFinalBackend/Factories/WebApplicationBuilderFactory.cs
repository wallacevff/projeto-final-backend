using ProjetoFinalBackend.Infra.CrossCutting.Providers;
using ProjetoFinalBackend.Infra.IoC;

namespace ProjetoFinalBackend.Api.Factories;

public static class WebApplicationBuilderFactory
{
    public static WebApplicationBuilder CreateApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = CustomConfigurationProvider.GetConfiguration(builder.Environment.EnvironmentName);
        builder.Configuration.AddConfiguration(configuration);
        builder.Services.ConfigureByIoC(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();

        return builder;
    }
}