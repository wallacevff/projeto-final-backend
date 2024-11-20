using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class CursoRepository(AppDbContext context) : DefaultRepository<
        Curso,
        CursoFilter,
        Guid
    >(context)
    , ICursoRepository
{
    public override async Task<Curso?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(c => c.Turmas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    protected override IQueryable<Curso> ApplyOrderBy(IQueryable<Curso> query)
    {
        return query.OrderBy(c => c.Id).ThenBy(c => c.Nome).ThenBy(c => c.CreatedAt);
    }

    protected override IQueryable<Curso> ApplyIncludes(IQueryable<Curso> query)
    {
        return query.Include(c => c.Professor);
    }
}