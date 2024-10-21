using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class TipoUsuarioRepository(AppDbContext dbContext) : DefaultRepository<TipoUsuario, TipoUsuarioFilter, TipoUsuarioEnum>(dbContext)
{
    
}