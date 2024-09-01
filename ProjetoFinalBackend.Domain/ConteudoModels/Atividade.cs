using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public abstract class Atividade
{
    public Guid AtividadeId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Guid TurmaId { get; set; }
    public Turma? Turma { get; set; }
    public IList<Arquivo>? Anexos { get; set; }
    private DateTime _createdAt = DateTime.Now();
    public DateTime DataCriacao
    {
        get => _createdAt;
        set => _createdAt = value;
    }

    public virtual DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }

    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }


    public record Key(Guid AtividadeId, Guid TurmaId);

    public Key GetKey()
    {
        return new Key(AtividadeId, TurmaId);
    }
}