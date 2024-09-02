using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
 
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AppDbContext _appDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger
    , AppDbContext context)
    {
        _logger = logger;
        _appDbContext = context;
    }

    [HttpGet]
    public IList<Turma> GetTurmaAluno()
    {
        return _appDbContext.Turmas.Include(t => t.Alunos!)
            .ThenInclude(t => t.Aluno).ToList();
    }

    [HttpPost("Aluno")]
    public Aluno AddAluno(Aluno aluno)
    {
         var a = (Aluno)_appDbContext.Usuarios.Add(aluno).Entity;
         _appDbContext.SaveChanges();
         return a;
    }
}
