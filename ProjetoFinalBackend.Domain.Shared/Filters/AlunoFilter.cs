using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class AlunoFilter : Filter
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public Guid? ImagemId { get; set; }
    public TipoUsuarioEnum TipoUsuarioCod { get; set; } = TipoUsuarioEnum.Aluno;
}
