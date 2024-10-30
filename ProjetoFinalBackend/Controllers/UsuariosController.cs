using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;
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
    private readonly IUsuarioService _usuarioService;
    private readonly ITipoUsuarioService _tipoUsuarioService;

    public UsuariosController(ILogger<UsuariosController> logger
    , AppDbContext context, IUsuarioService usuarioService
    , ITipoUsuarioService tipoUsuarioService
    )
    {
        _logger = logger;
        _appDbContext = context;
        _usuarioService = usuarioService;
        _tipoUsuarioService = tipoUsuarioService;
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
