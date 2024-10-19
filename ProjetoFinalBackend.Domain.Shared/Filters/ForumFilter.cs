namespace ProjetoFinalBackend.Domain.Shared.Filters;

public class ForumFilter : Filter
{
    public Guid? TurmaId { get; set; }
    public Guid? CursoId { get; set; }
    public Guid? ForumId { get; set; }

    public string? Titulo { get; set; }
    public Guid? UsuarioId { get; set; }
    public string? Criador { get; set; }
}