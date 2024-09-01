using ProjetoFinalBackend.Domain.Sistema;

namespace ProjetoFinalBackend.Domain.Usuario;

public class TipoUsuario : DefaultEntity<int>
{
    public IList<NavbarItem> Navbar { get; set; } = new List<NavbarItem>(); //Dono
}