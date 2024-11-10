using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Usuario;

public interface IUsuarioRepository : IDefaultRepository<UsuarioModels.Usuario, UsuarioFilter, Guid>, IDomainRepository
{

}