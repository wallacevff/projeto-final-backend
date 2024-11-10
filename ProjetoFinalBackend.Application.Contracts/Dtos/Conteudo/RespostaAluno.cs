using ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Conteudo;

public class RespostaAlunoDto
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AtividadeId { get; set; }
    public Guid AlunoId { get; set; }
    public Guid RespostaId { get; set; }
    public IList<ArquivoDto>? Anexo { get; set; }
    public string? Resposta { get; set; }
}