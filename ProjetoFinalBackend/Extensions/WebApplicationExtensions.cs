namespace ProjetoFinalBackend.Api.Extensions;

public static class WebApplicationExtensions
{

    public static WebApplication UseSwaggerIfEnvIsDev(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }

    public static WebApplication UseSwaggerAllEnvs(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }

    public static WebApplication UseCorsAllowAll(this WebApplication app)
    {
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        return app;
    }


}