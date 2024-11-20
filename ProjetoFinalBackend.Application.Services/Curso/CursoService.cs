using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Curso;

public class CursoService(ICursoRepository repository, IAutomapApi mapper) : DefaultService<
    Domain.CursoModels.Curso,
    CursoDto,
    CursoCadastroDto,
    CursoFilter,
    Guid
>(repository, mapper), ICursoService
{
    
}