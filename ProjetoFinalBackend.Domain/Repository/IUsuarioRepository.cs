using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository;

public interface IUsuarioRepository : IDefaultRepository<Usuario, UsuarioFilter, Guid>, IDomainRepository
{
    
}