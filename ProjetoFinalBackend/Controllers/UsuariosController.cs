using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
 
    private readonly ILogger<UsuariosController> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly IUsuarioService _usuarioService;
    private readonly ITipoUsuarioService _tipoUsuarioService;
    private readonly IProfessorService _professorService;

    public UsuariosController(ILogger<UsuariosController> logger
    , AppDbContext context, IUsuarioService usuarioService
    , ITipoUsuarioService tipoUsuarioService
    , IProfessorService professorService

    )
    {
        _logger = logger;
        _appDbContext = context;
        _usuarioService = usuarioService;
        _tipoUsuarioService = tipoUsuarioService;
        _professorService = professorService;
    }

    [HttpGet("Professores")]
    public async Task<PagedResultDto<ProfessorDto>> Getusuarios([FromQuery] ProfessorFilter filter)
    {
        return await _professorService.GetAllAsync(filter);
    }




    [HttpGet("Usuarios")]
    public async Task<PagedResultDto<UsuarioDto>> Getusuarios([FromQuery] UsuarioFilter filter)
    {
        return await _usuarioService.GetAllAsync(filter);
    }

    [HttpPost("Usuarios")]
    public async Task CriarUsuario(UsuarioCadastroDto usuario)
    {
       await _usuarioService.AddAsync(usuario).ConfigureAwait(false);
    }

    [HttpPost("Login")]
    public async Task<bool> Login([FromBody] LoginDto usuario)
    {
        return await _usuarioService.Login(usuario.Email, usuario.Password).ConfigureAwait(false);
    }


    [HttpGet("TipoUsuarios")]
    public async Task<PagedResultDto<TipoUsuarioDto>> GetTipoUsuarios([FromQuery] TipoUsuarioFilter filter)
    {
        return await _tipoUsuarioService.GetAllAsync(filter);
    }

    [HttpPost("TipoUsuarios")]
    public async Task<TipoUsuarioDto> AddTipoUsuarios([FromBody] TipoUsuarioCadastroDto cadastro)
    {
        return await _tipoUsuarioService.AddAsync(cadastro);
    }
}
