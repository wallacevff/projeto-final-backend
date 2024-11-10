using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface IProfessorService
    : IDefaultService<
        ProfessorDto,
        ProfessorCadastroDto,
        ProfessorFilter,
        Guid
    >
{
    
}