using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Application.Services.Automap;

public partial class AutomapProfile : Profile
{
    public AutomapProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResultDto<>)).ReverseMap();
        CreateMap<PageInfo, PageInfoDto>().ReverseMap();
        CreateMap<UsuarioCadastroDto, Usuario>().ReverseMap();
        CreateMap<UsuarioDto, Usuario>().ReverseMap();
        CreateMap<AlunoCadastroDto, Aluno>().ReverseMap();
        CreateMap<AlunoDto, Aluno>().ReverseMap();
        CreateMap<TipoUsuarioDto, TipoUsuario>().ReverseMap();
    }
}