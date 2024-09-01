using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public class AtividadeAluno
{
    public Guid AtividadeId { get; set; }
    public Atividade? Atividade { get; set; }
    public Guid AlunoId { get; set; }
    public Aluno? Aluno { get; set; }
    public bool Concluida { get; set; } = false;
    public DateTime? DataEntrega { get; set; }
    public double? Nota { get; set; }

    public record Key(Guid atividadeId, Guid alunoId);

    public Key GetKey()
    {
        return new Key(AtividadeId, AlunoId);
    }
}