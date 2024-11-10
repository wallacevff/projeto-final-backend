using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Repository.Usuario;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class ProfessorRepository : 
    DefaultRepository<Professor, ProfessorFilter, Guid>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context) { }


    protected override IQueryable<Professor> ApplyOrderBy(IQueryable<Professor> query)
    {
        return query.OrderBy(u => u.Nome);
    }

    protected override IQueryable<Professor> ApplyIncludes(IQueryable<Professor> query)
    {
        return query.Include(p => p.Cursos);
    }
}