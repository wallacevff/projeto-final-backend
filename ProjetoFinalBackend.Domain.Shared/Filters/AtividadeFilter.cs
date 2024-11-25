using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Domain.Shared.CustomProperties;

namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class AtividadeFilter : Filter
{
    public Guid? AtividadeId { get; set; }
    [FromQuery(Name = "AtividadeTitulo")]
    public string? Titulo { get; set; }
    [FromQuery(Name = "AtividadeDescricao")]
    public string? Descricao { get; set; }
    public Guid? CursoId { get; set; }

    public string? AtividadeCursoNome { get; set; }
    public Guid? TurmaId { get; set; }
}