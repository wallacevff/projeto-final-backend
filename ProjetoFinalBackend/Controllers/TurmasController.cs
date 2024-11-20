using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TurmasController(
    ILogger<TurmasController> logger,
    ITurmaService turmaService,
    ITurmaAlunoService turmaAlunoService
    ) : ControllerBase
{


    [HttpGet("Turmas")]
    public async Task<PagedResultDto<TurmaDto>> GetTurmasAsync([FromQuery] TurmaFilter filter)
    {
        return await turmaService.GetAllAsync(filter);
    }


    [HttpPost("Turmas")]
    public async Task AddTurmaAsync(TurmaCadastroDto cadastroDto)
    {
       await turmaService.AddAsync(cadastroDto).ConfigureAwait(false);
    }

    [HttpGet("{cursoId}/{turmaId}")]
    public async Task<TurmaDto> GetTurmaByIdAsync([FromRoute] Guid cursoId, [FromRoute] Guid turmaId)
    {
        return await turmaService.GetByIdAsync(new Turma.Key(cursoId, turmaId));
    }

    [HttpPut("{cursoId}/{turmaId}")]
    public async Task UpdateAsync([FromBody] TurmaCadastroDto dto,[FromRoute] Guid cursoId, [FromRoute] Guid turmaId)
    {
        await turmaService.UpdateAsync(dto, new Turma.Key(cursoId, turmaId));
    }

    [HttpGet("TurmasAlunos")]
    public async Task<PagedResultDto<TurmaAlunoDto>> GetTurmasAlunosAsyc([FromQuery] TurmaAlunoFilter turmaAlunoFilter)
    {
       var turmasAlunos =   await turmaAlunoService.GetAllAsync(turmaAlunoFilter);
       return turmasAlunos;
    }

    [HttpPost("TurmasAlunos")]
    public async Task<TurmaAlunoDto> AddTurmasAlunosAsync([FromBody] TurmaAlunoCadastroDto turmaAlunoCadastroDto)
    {
        var turmasAlunos = await turmaAlunoService.AddAsync(turmaAlunoCadastroDto);
        return turmasAlunos;
    }

    [HttpGet("TurmasAlunos/{cursoId}/{turmaId}/{alunoId}")]
    public async Task<TurmaAlunoDto> GetTurmaAlunoById(
        [FromRoute] Guid cursoId,
        [FromRoute] Guid turmaId,
        [FromRoute] Guid alunoId
        )
    {
        var turmaAluno = await turmaAlunoService.GetByIdAsync(new TurmaAluno.Key(cursoId, turmaId, alunoId));
        return turmaAluno;
    }

    [HttpDelete("TurmasAlunos/{cursoId}/{turmaId}/{alunoId}")]
    public async Task<TurmaAlunoDto> DeleteTurmaAlunoAsync(
        [FromRoute] Guid cursoId,
        [FromRoute] Guid turmaId,
        [FromRoute] Guid alunoId
    )
    {
        var turmaAluno = await turmaAlunoService.DeleteAsync(new TurmaAluno.Key(cursoId, turmaId, alunoId));
        return turmaAluno;
    }
}
