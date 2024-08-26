using ProjetoFinalBackend.Extensions;
using ProjetoFinalBackend.Factories;

var builder = WebApplicationBuilderFactory.CreateApp(args);

var app = builder.Build();

app.UseCorsAllowAll();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
