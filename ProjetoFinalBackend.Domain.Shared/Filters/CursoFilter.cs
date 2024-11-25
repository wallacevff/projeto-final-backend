using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalBackend.Domain.Shared.CustomProperties;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class CursoFilter : Filter
{
    [FromQuery(Name = "CursoId")]
    public Guid? Id { get; set; }
    [FromQuery(Name = "CursoNome")]
    public string? Nome { get; set; }
    [FromQuery(Name = "CursoDescricao")]
    public string? Descricao { get; set; }
    public Guid? ProfessorId { get; set; }
    public string? ProfessorNome { get; set; }
    [FromQuery(Name = "CursoModalidade")]
    public Modalidade? Modalidade { get; set; }
}