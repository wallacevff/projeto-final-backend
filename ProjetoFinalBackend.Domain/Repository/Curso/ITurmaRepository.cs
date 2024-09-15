using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ITurmaRepository : IDefaultRepository<CursoModels.Turma>
{
    public Task<PagedResult<CursoModels.Turma>> GetAllTurmasPagedAsync(int pageNumber, int pageSize,params object[] cursoId);

    public Task<PagedResult<CursoModels.Turma>> GetAllTurmasCursoPagedAsync(int pageNumber, int pageSize, Guid cursoId);

    

    public Task<PagedResult<TurmaAluno>> GetTurma();
} 