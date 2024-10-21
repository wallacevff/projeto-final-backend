using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Enums;
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


    public class Key(Guid turmaId, Guid atividadeId)
    {
        public Guid TurmaId { get; set; } = turmaId;
        public Guid AtividadeId { get; set; } = atividadeId;

        public override bool Equals(object? obj)
        {
            if (obj is not Key key) return false;
            return TurmaId == key.TurmaId &&
                   AtividadeId == key.AtividadeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TurmaId, AtividadeId);
        }
    }

    public Key GetKey()
    {
        return new Key(AtividadeId, TurmaId);
    }
}