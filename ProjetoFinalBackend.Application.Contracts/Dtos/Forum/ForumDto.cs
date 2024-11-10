using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Forum;

public class ForumDto
{
    public Guid TurmaId { get; set; }
    public Guid CursoId { get; set; }
    public Guid ForumId { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public UsuarioDto? Criador { get; set; }
    public IList<PostagemDto>? Postagens { get; set; } //Dono de Postagens

    public CursoDto? Curso { get; set; }
    public TurmaDto? Turma { get; set; }

}