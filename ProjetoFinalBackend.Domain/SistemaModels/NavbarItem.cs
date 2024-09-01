namespace ProjetoFinalBackend.Domain.Sistema;

public class NavbarItem : DefaultEntity<Guid>
{
    public string Url { get; set; } = string.Empty;
}