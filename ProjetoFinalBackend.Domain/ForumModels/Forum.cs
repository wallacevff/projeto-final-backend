using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ForumModels;

public class Forum
{
    private DateTime _createdAt = DateTime.Now;

    public Guid TurmaId { get; set; }
    public Guid ForumId { get; set; }
    
    public string Titulo { get; set; }
    public Usuario Criador { get; set; }
    public IList<Postagem>? Postagens { get; set; } //Dono de Postagens
    
    public Turma? Turma { get; set; }

    public DateTime DataCriacao
    {
        get => _createdAt; set => _createdAt = value;
    }

    public override DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
}