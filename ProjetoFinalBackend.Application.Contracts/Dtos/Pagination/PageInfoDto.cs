namespace ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;

public class PageInfoDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}