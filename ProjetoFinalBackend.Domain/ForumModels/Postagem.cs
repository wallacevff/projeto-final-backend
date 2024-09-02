using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ForumModels;

public class Postagem
{
    public Guid PostagemId { get; set; }
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid ForumId { get; set; }

    private DateTime _createdAt = DateTime.Now;

    public Curso? Curso { get; set; }
    public Turma? Turma { get; set; }
    public Forum? Forum { get; set; }
    
    public Guid? PostagemPrincipalCursoId { get; set; }
    public Guid? PostagemPrincipalTurmaId { get; set; }
    public Guid? PostagemPrincipalForumId { get; set; }
    public Guid? PostagemPrincipalPostagemId { get; set; }

    public Postagem? PostagemPrincipal { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public Usuario? Autor { get; set; }
    public IList<Arquivo>? Arquivos { get; set; }

    public IList<Postagem>? Respostas { get; set; }

    public DateTime DataCriacao
    {
        get => _createdAt;
        set => _createdAt = value;
    }
    public DateTime CreatedAt
    {
        get => _createdAt; set => _createdAt = value;
    }

    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public record Key(Guid ForumId, Guid PostagemId);

    public Key GetKey() => new Key(ForumId, PostagemId);
}