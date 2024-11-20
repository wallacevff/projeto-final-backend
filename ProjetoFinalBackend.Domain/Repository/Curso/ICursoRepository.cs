using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ICursoRepository : IDefaultRepository<CursoModels.Curso, CursoFilter, Guid>
{
}