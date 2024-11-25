using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Shared.CustomProperties;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class AtividadesController(
    ILogger<AtividadesController> logger
    ) : ControllerBase
{

    [HttpGet]
    public IActionResult GetAtividadesAsync([FromQuery] AtividadeFilter atividadeFilter)
    {
        
        return Ok(atividadeFilter);
    }
   

}
