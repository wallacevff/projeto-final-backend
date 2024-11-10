using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.Repository.Usuario;

public interface IProfessorRepository : IDefaultRepository<Professor, ProfessorFilter, Guid>
{
    
}