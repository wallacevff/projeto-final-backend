using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface IAlunoRepository : IDefaultRepository<Aluno, AlunoFilter, Guid>
{
    public Task<PagedResult<Aluno>> GetAllTurmaAlunoPagedAsync(int pageNumber, int pageSize, params object[] turmaId);

}