using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class CursoCadastroDto
{
    public string? Descricao { get; set; }
    public Guid ProfessorId { get; set; }
    public ProfessorDto? Professor { get; set; }
    public Modalidade Modalidade { get; set; }
}