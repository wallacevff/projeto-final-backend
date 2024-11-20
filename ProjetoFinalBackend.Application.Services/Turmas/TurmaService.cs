using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Turmas;

public class TurmaService(ITurmaRepository turmaRepository, IAutomapApi mapper) : DefaultService<
    Turma,
    TurmaDto,
    TurmaCadastroDto,
    TurmaFilter,
    Turma.Key
>(turmaRepository, mapper), ITurmaService
{
    
}