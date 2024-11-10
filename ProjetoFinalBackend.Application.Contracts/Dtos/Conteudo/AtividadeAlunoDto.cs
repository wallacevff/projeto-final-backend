using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Conteudo;

public class AtividadeAlunoDto
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AtividadeId { get; set; }
    public AtividadeDto? Atividade { get; set; }
    public Guid AlunoId { get; set; }
    public AlunoDto? Aluno { get; set; }
    public bool Concluida { get; set; } = false;
    public DateTime? DataEntrega { get; set; }
    public double? Nota { get; set; }
}