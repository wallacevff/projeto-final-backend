using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ITurmaRepository : IDefaultRepository<Turma, TurmaFilter, Turma.Key>
{
    public Task<PagedResult<CursoModels.Turma>> GetAllTurmasPagedAsync(int pageNumber, int pageSize,params object[] cursoId);

    public Task<PagedResult<CursoModels.Turma>> GetAllTurmasCursoPagedAsync(int pageNumber, int pageSize, Guid cursoId);

    

    public Task<PagedResult<TurmaAluno>> GetTurma();
} 