using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface ITurmaAlunoService : IDefaultService<
    TurmaAlunoDto,
    TurmaAlunoCadastroDto,
    TurmaAlunoFilter,
    TurmaAluno.Key
>
{
    
}