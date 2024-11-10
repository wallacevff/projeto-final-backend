using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;

public class ArquivoDto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? RepositorioArquivoId { get; set; } 
    public string? Extensao { get; set; }
    public string? Url { get; set; }
    public TipoArquivo TipoArquivo { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}