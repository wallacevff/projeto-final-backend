using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class TurmaAlunoRepository(AppDbContext context) : DefaultRepository<
    TurmaAluno,
    TurmaAlunoFilter,
    TurmaAluno.Key
>(context), ITurmaAlunoRepository
{
    protected override IQueryable<TurmaAluno> ApplyOrderBy(IQueryable<TurmaAluno> query)
    {
        return base.ApplyOrderBy(query)
            .OrderBy(ta => ta.CursoId)
            .ThenBy(ta => ta.TurmaId)
            .ThenBy(ta => ta.AlunoId);
    }

    protected override IQueryable<TurmaAluno> ApplyIncludes(IQueryable<TurmaAluno> query)
    {
        return base.ApplyIncludes(query)
            .Include(ta => ta.Aluno)
            .Include(t => t.Turma!.Curso!.Professor);
    }
}