namespace ProjetoFinalBackend.Domain.Shared.Pagination;

public class PagedResult<TEntity> where TEntity : class
{
    public required IList<TEntity> Dados { get; set; }
    public PageInfo PageInfo { get; set; } = new PageInfo();
}
