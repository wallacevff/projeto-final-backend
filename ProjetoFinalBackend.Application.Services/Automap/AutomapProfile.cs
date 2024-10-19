using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Domain.Shared.Pagination;

namespace ProjetoFinalBackend.Application.Services.Automap;

public partial class AutomapProfile : Profile
{
    public AutomapProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResultDto<>)).ReverseMap();
        CreateMap<PageInfo, PageInfoDto>().ReverseMap();
    }
}