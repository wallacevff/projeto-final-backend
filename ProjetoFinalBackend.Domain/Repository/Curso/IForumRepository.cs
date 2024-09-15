using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface IForumRepository : IDefaultRepository<Forum>
{
    public Task<PagedResult<Forum>> GetAllTurmasPagedAsync(int pageNumber, int pageSize, params object[] turmaId);

} 