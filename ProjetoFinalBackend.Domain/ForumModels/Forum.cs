using System.Globalization;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ForumModels;

public class Forum
{
    private DateTime _createdAt = DateTime.Now;

    public Guid TurmaId { get; set; }
    public Guid CursoId { get; set; }
    public Guid ForumId { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public Usuario? Criador { get; set; }
    public IList<Postagem>? Postagens { get; set; } //Dono de Postagens

    public Curso? Curso { get; set; }
    public Turma? Turma { get; set; }

    public DateTime DataCriacao
    {
        get => _createdAt; set => _createdAt = value;
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }

    public class Key(Guid turmaId, Guid forumId)
    {
        Guid TurmaId = turmaId;
        Guid ForumId = forumId;
    }

    public Key GetKey()
    {
        return new Key(TurmaId, ForumId);
    }
}