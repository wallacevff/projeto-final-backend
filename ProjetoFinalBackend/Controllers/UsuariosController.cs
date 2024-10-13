using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;
using ProjetoFinalBackend.Infra.EntityFramework.Repository;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
 
    private readonly ILogger<UsuariosController> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly UsuarioRepository _usuarioRepository;

    public UsuariosController(ILogger<UsuariosController> logger
    , AppDbContext context, UsuarioRepository usuarioRepository)
    {
        _logger = logger;
        _appDbContext = context;
        _usuarioRepository = usuarioRepository;
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

    [HttpPost("Criar")]
    public async Task Criar([FromBody] Professor usuario)
    {
        var usuarioCriado = await _appDbContext.Professores.AddAsync(usuario); //await _usuarioRepository.CreateUser(usuario);
        await _appDbContext.SaveChangesAsync();
        
    }
}
