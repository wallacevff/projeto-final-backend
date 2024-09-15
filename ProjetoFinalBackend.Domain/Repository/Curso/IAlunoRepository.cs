using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface IAlunoRepository : IDefaultRepository<Aluno>
{
    public Task<PagedResult<Aluno>> GetAllTurmaAlunoPagedAsync(int pageNumber, int pageSize, params object[] turmaId);

}