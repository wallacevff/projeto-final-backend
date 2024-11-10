using ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Forum;

public class PostagemDto
{
    public Guid PostagemId { get; set; }
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid ForumId { get; set; }

    public CursoDto? Curso { get; set; }
    public TurmaDto? Turma { get; set; }
    public ForumDto? Forum { get; set; }
    
    public Guid? PostagemPrincipalCursoId { get; set; }
    public Guid? PostagemPrincipalTurmaId { get; set; }
    public Guid? PostagemPrincipalForumId { get; set; }
    public Guid? PostagemPrincipalPostagemId { get; set; }

    public PostagemDto? PostagemPrincipal { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public UsuarioDto? Autor { get; set; }
    public IList<ArquivoDto>? Arquivos { get; set; }
    public IList<PostagemDto>? Respostas { get; set; }
}