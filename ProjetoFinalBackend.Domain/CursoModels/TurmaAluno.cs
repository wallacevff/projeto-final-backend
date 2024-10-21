using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.CursoModels;

public class TurmaAluno
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AlunoId { get; set; }
    public Curso? Curso { get; set; }
    public Turma? Turma { get; set; }
    public Aluno? Aluno { get; set; }

    public int QuantidadeTarefasAtribuidas { get; set; }
    public int QuantidadeTarefasRealizadas { get; set; }
    public double PercentualConcluido { get; set; }

    public class Key(Guid cursoId, Guid turmaId, Guid alunoId)
    {
        public Guid CursoId { get; set; } = cursoId;
        public Guid TurmaId { get; set; } = turmaId;
        public Guid AlunoId { get; set; } = alunoId;

        public override bool Equals(object? obj)
        {
            if (obj is not Key key) return false;
            return CursoId == key.CursoId && TurmaId == key.TurmaId &&
                   AlunoId == key.AlunoId && AlunoId == key.AlunoId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(CursoId, TurmaId, AlunoId);
        }
    }

    public Key GetKey()
    {
        return new Key(CursoId, TurmaId, AlunoId);
    }
}