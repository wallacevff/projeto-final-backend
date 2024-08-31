namespace ProjetoFinalBackend.Domain.Sistema;

public class NavbarItem : DefaultEntity<Guid>
{
    public string Titulo { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}