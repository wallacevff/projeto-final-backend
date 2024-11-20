using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class CursoFilter : Filter
{
    public Guid? Id { get; set; }
    public string? Descricao { get; set; }
    public Guid? ProfessorId { get; set; }
    public string? ProfessorNome { get; set; }
    public Modalidade? Modalidade { get; set; }
}