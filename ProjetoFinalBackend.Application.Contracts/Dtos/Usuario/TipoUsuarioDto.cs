using ProjetoFinalBackend.Application.Contracts.Dtos.Sistema;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class TipoUsuarioDto
{
    public TipoUsuarioEnum Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }

    public IList<NavbarItemDto> Navbar { get; set; } = new List<NavbarItemDto>();
}