using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class TipoUsuarioFilter : Filter
{
    public TipoUsuarioEnum? Id { get; set; }

}