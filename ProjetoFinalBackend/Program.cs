using ProjetoFinalBackend.Api.Extensions;
using ProjetoFinalBackend.Api.Factories;

var builder = WebApplicationBuilderFactory.CreateApp(args);

var app = builder.Build();

app.UseCorsAllowAll();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwaggerAllEnvs();
app.Run();
