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

}