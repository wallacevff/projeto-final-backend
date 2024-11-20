using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Sistema;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Application.Services.Automap;

public partial class AutomapProfile : Profile
{
    public AutomapProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResultDto<>)).ReverseMap();
        CreateMap<PageInfo, PageInfoDto>().ReverseMap();
        CreateMap<UsuarioCadastroDto, Domain.UsuarioModels.Professor>()
            .ReverseMap();
        CreateMap<UsuarioCadastroDto, Domain.UsuarioModels.Aluno>()
            .ReverseMap();

        CreateMap<UsuarioCadastroDto, Domain.UsuarioModels.Usuario>()
            .ConstructUsing((src, context) => src.TipoUsuarioCod == TipoUsuarioEnum.Professor
                ? context.Mapper.Map<Professor>(src)
                : context.Mapper.Map<Aluno>(src)
            );

        CreateMap<Domain.CursoModels.Curso, CursoDto>().ReverseMap();
        CreateMap<Domain.CursoModels.Curso, CursoCadastroDto>().ReverseMap();

        CreateMap<UsuarioDto, Domain.UsuarioModels.Usuario>()
           
            .ReverseMap();
        CreateMap<AlunoCadastroDto, Aluno>().ReverseMap();
        CreateMap<ProfessorCadastroDto, Professor>().ReverseMap();
        CreateMap<ProfessorDto, Professor>().ReverseMap();
        CreateMap<AlunoDto, Aluno>().ReverseMap();
        CreateMap<TipoUsuarioDto, TipoUsuario>().ReverseMap();
        CreateMap<TipoUsuarioCadastroDto, TipoUsuario>().ReverseMap();
        CreateMap<NavbarItemCadastroDto, NavbarItem>().ReverseMap();
        CreateMap<NavbarItemDto, NavbarItem>().ReverseMap();
        CreateMap<TurmaDto, Turma>().ReverseMap();
        CreateMap<TurmaCadastroDto, Turma>().ReverseMap();
        CreateMap<TurmaAlunoCadastroDto, TurmaAluno>().ReverseMap();
        CreateMap<TurmaAlunoDto, TurmaAluno>().ReverseMap();
    }
}