using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface ITurmaService : IDefaultService<
    TurmaDto,
    TurmaCadastroDto,
    TurmaFilter,
    Turma.Key
>
{
    
}