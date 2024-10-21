using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface ITipoUsuarioService : IDefaultService
    <TipoUsuarioDto, TipoUsuarioCadastroDto,TipoUsuarioFilter, TipoUsuarioEnum>, IApplicationServiceContracts
{
    
}

