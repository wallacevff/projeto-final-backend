using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public class RespostaAluno
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AtividadeId { get; set; }
    public Guid AlunoId { get; set; }
    public Guid RespostaId { get; set; }
    public IList<Arquivo>? Anexo { get; set; }
    public string? Resposta { get; set; }
}