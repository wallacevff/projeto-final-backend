using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ITurmaAlunoRepository : IDefaultRepository<CursoModels.TurmaAluno>
{
    public Task<PagedResult<CursoModels.TurmaAluno>> GetAllTurmasPagedAsync(int pageNumber, int pageSize, Guid alunoId);

} 