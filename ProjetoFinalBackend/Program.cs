using ProjetoFinalBackend.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseCorsAllowAll();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
