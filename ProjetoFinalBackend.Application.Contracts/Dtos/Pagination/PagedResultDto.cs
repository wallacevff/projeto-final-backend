namespace ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;

public class PagedResultDto<TEntity> where TEntity : class
{
    public required IList<TEntity> Dados { get; set; }
    public PageInfoDto PageInfo { get; set; } = new PageInfoDto();
}