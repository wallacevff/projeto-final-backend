using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.Shared.Pagination;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class TipoUsuarioRepository(AppDbContext dbContext) : DefaultRepository<TipoUsuario, TipoUsuarioFilter, TipoUsuarioEnum>(dbContext), ITipoUsuarioRepository
{
    //public override async Task<PagedResult<TipoUsuario>> GetAllAsync(TipoUsuarioFilter filter)
    //{
    //  ;
    //    var result = await DbSet.Include(tu => tu.Navbar)
    //            .Where(GetFilters(filter))
    //            .Skip((filter.PageNumber - 1) * filter.PageSize)
    //            .Take(filter.PageSize).ToListAsync()
    //        ;
    //    return await GeneratePagedResult(
    //        result,
    //        filter
    //    );
    //}

    protected override IQueryable<TipoUsuario> ApplyIncludes(IQueryable<TipoUsuario> query)
    {
        return query.Include(tu => tu.Navbar);
    }
}