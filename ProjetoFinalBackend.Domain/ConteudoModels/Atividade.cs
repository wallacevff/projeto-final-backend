using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public abstract class Atividade
{
    public Guid AtividadeId { get; set; }
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
    public Guid CursoId { get; set; }
    public Curso? Curso { get; set; }
    public Guid TurmaId { get; set; }
    public Turma? Turma { get; set; }
    public IList<Arquivo>? Anexos { get; set; }
    public TipoAtividade TipoAtividade  { get; set; }
    private DateTime _createdAt;
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