namespace ProjetoFinalBackend.Api.Factories;

public static class WebApplicationBuilderFactory
{
    public static WebApplicationBuilder CreateApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();

        return builder;
    }
}