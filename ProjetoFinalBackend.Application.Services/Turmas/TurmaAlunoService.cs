using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Turmas;

public class TurmaAlunoService(ITurmaAlunoRepository turmaAlunoRepository, IAutomapApi mapper) : DefaultService<
    TurmaAluno,
    TurmaAlunoDto,
    TurmaAlunoCadastroDto,
    TurmaAlunoFilter,
    TurmaAluno.Key
>(turmaAlunoRepository, mapper), ITurmaAlunoService
{
    
}