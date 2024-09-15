using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ICursoRepository : IDefaultRepository<CursoModels.Curso>
{
    public Task<CursoModels.Curso> GetCursoAsync(Guid cursoId);
    
    public Task<PagedResult<CursoModels.Curso>> QueryCursosPagedAsync(string nomeCurso, int pageNumber, int pageSize);
    
    public Task<PagedResult<CursoModels.Curso>> GetAllCursosPagedAsync(string nomeCurso, int pageNumber, int pageSize);
}