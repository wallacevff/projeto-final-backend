using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

public abstract class Arquivo : DefaultEntity<Guid>
{
    public string? RepositorioArquivoId { get; set; } 
    public string? Extensao { get; set; }
    public string? Url { get; set; }
    public TipoArquivo TipoArquivo { get; set; } //Discriminator
}