using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public class AtividadeAluno
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AtividadeId { get; set; }
    public Atividade? Atividade { get; set; }
    public Guid AlunoId { get; set; }
    public Aluno? Aluno { get; set; }
    public bool Concluida { get; set; } = false;
    public DateTime? DataEntrega { get; set; }
    public double? Nota { get; set; }

    public class Key(Guid cursoId, Guid turmaId, Guid alunoId, Guid atividadeId)
    {
        public Guid CursoId = cursoId;
        public Guid TurmaId = turmaId;
        public Guid AlunoId = alunoId;
        public Guid AtividadeId = atividadeId;

        public override bool Equals(object? obj)
        {
            if (obj is not Key key) return false;
            return CursoId == key.CursoId &&
                   TurmaId == key.TurmaId &&
                   AlunoId == key.AlunoId &&
                   AtividadeId == key.AtividadeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CursoId, TurmaId, AlunoId, AtividadeId);
        }
    }

    public Key GetKey()
    {
        return new Key(CursoId, TurmaId, AlunoId, AtividadeId);
    }
}