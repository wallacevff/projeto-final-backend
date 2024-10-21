using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services;

public class DefaultService<TDto, TCadastroDto, TFilter, TKey> : IDefaultService<TDto, TCadastroDto, TFilter, TKey>
    where TDto : class
    where TCadastroDto : class
    where TFilter : Filter
    
{
    public Task<TDto> AddAsync(TCadastroDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<TDto>> GetAllAsync(TFilter filter)
    {
        throw new NotImplementedException();
    }
}