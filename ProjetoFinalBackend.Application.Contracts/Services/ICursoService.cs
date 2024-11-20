using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface ICursoService :IDefaultService<
    CursoDto,
    CursoCadastroDto,
    CursoFilter,
    Guid
>
{
    
}