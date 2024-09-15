namespace ProjetoFinalBackend.Domain.SistemaModels;

public class PagedResult<TEntity> where TEntity : class
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public required IList<TEntity> DataEntity { get; set; }
}