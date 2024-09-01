using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ForumModels;

public class Postagem
{
    private DateTime _createdAt = DateTime.Now;
    public Guid ForumId { get; set; }
    public Forum? Forum { get; set; }
    public Guid PostagemId { get; set; }
    public Guid? PostagemPrincipalId { get; set; }
    public Postagem? PostagemPrincipal { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public Usuario? Autor { get; set; }
    public IList<Arquivo>? Arquivos { get; set; }

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