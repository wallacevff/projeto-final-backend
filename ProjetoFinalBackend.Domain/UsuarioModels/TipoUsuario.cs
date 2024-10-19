using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public class TipoUsuario : DefaultEntity<TipoUsuarioEnum>
{
    public IList<NavbarItem> Navbar { get; set; } = new List<NavbarItem>(); //Dono
}