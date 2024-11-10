using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class TurmaAlunoDto
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AlunoId { get; set; }
    public CursoDto? Curso { get; set; }
    public TurmaDto? Turma { get; set; }
    public AlunoDto? Aluno { get; set; }

    public int QuantidadeTarefasAtribuidas { get; set; }
    public int QuantidadeTarefasRealizadas { get; set; }
    public double PercentualConcluido { get; set; }
}