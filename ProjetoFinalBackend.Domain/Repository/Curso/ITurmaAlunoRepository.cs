using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Domain.Repository.Curso;

public interface ITurmaAlunoRepository : IDefaultRepository<CursoModels.TurmaAluno, TurmaAlunoFilter, TurmaAluno.Key>
{

} 