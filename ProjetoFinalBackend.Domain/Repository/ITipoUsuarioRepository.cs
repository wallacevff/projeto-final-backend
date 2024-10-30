using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository;

public interface ITipoUsuarioRepository
: IDefaultRepository<TipoUsuario, TipoUsuarioFilter, TipoUsuarioEnum>, IDomainRepository
{
    
}