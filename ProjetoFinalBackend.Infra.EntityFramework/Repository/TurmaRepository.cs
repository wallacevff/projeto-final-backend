using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Repository.Curso;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class TurmaRepository(AppDbContext context) : DefaultRepository<
    Turma,
    TurmaFilter,
    Turma.Key
>(context), ITurmaRepository
{
    
}