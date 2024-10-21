using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ITurmaAlunoRepository : IDefaultRepository<CursoModels.TurmaAluno, TurmaAlunoFilter, TurmaAluno.Key>
{
    public Task<PagedResult<CursoModels.TurmaAluno>> GetAllTurmasPagedAsync(int pageNumber, int pageSize, Guid alunoId);

} 