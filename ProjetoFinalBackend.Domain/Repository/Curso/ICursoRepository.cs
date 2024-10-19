using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ICursoRepository : IDefaultRepository<CursoModels.Curso, CursoFilter>
{
    public Task<CursoModels.Curso> GetCursoAsync(Guid cursoId);
    
    public Task<PagedResult<CursoModels.Curso>> QueryCursosPagedAsync(string nomeCurso, int pageNumber, int pageSize);
    
    public Task<PagedResult<CursoModels.Curso>> GetAllCursosPagedAsync(string nomeCurso, int pageNumber, int pageSize);
}