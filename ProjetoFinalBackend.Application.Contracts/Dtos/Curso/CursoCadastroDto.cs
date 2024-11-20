using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class CursoCadastroDto
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public Guid ProfessorId { get; set; }
    public ProfessorCadastroDto? Professor { get; set; }
    public Modalidade Modalidade { get; set; }
}