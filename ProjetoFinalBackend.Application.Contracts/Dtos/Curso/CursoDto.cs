using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class CursoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public Guid ProfessorId { get; set; }
    public ProfessorDto? Professor { get; set; }
    public Modalidade Modalidade { get; set; }
    //public IList<TurmaDto>? Turmas { get; set; } //Dono de Turmas
}