using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CursosController(
    ILogger<CursosController> logger,
    ICursoService cursoService
    ) : ControllerBase
{


    [HttpGet("Cursos")]
    public async Task<PagedResultDto<CursoDto>> GetCursos([FromQuery] CursoFilter filter)
    {
        return await cursoService.GetAllAsync(filter);
    }


    [HttpPost("Cursos")]
    public async Task CriarCurso(CursoCadastroDto cadastroDto)
    {
       await cursoService.AddAsync(cadastroDto).ConfigureAwait(false);
    }

    [HttpGet("{id}")]
    public async Task<CursoDto> GetCursoById(Guid id)
    {
        return await cursoService.GetByIdAsync(id);
    }

    [HttpPut("{id}")]
    public async Task Update(CursoCadastroDto dto, Guid id)
    {
        await cursoService.UpdateAsync(dto, id);
    }

}
