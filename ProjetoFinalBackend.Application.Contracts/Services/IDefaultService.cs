using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface IDefaultService<TDto, TCadastroDto, TFilter, Tkey>
where TDto : class
where TCadastroDto : class
where TFilter : Filter
{
    public Task<TDto> AddAsync(TCadastroDto dto);
    public Task<PagedResultDto<TDto>> GetAllAsync(TFilter filter);
}