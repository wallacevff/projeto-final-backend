using ProjetoFinalBackend.Domain.Sistema;

namespace ProjetoFinalBackend.Domain.Usuario;

public class TipoUsuario : DefaultEntity<Guid>
{
    public string Descricao { get; set; } = string.Empty;
    public IList<NavbarItem> Navbar { get; set; } = new List<NavbarItem>();
}