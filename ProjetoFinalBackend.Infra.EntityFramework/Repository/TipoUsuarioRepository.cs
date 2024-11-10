using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Repository.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class TipoUsuarioRepository(AppDbContext dbContext) : DefaultRepository<TipoUsuario, TipoUsuarioFilter, TipoUsuarioEnum>(dbContext), ITipoUsuarioRepository
{
    protected override IQueryable<TipoUsuario> ApplyIncludes(IQueryable<TipoUsuario> query)
    {
        return query.Include(tu => tu.Navbar);
    }

    protected override IQueryable<TipoUsuario> ApplyOrderBy(IQueryable<TipoUsuario> query)
    {
        return query.OrderBy(tu => tu.Id);
    }
}