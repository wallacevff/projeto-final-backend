using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface IForumRepository : IDefaultRepository<Forum, ForumFilter, Forum.Key>
{
    public Task<PagedResult<Forum>> GetAllTurmasPagedAsync(int pageNumber, int pageSize, params object[] turmaId);

} 