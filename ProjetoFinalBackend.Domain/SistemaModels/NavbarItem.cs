namespace ProjetoFinalBackend.Domain.SistemaModels;

public class NavbarItem : DefaultEntity<Guid>
{
    public string Url { get; set; } = string.Empty;
}