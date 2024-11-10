using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository.Usuario;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Application.Services.Usuario;

public class ProfessorService(
        IAutomapApi mapper,
        IProfessorRepository professorRepository
    ) 
    : DefaultService<
        Professor,
        ProfessorDto,
        ProfessorCadastroDto,
        ProfessorFilter,
        Guid
        >(professorRepository, mapper),
        IProfessorService
{
    
}