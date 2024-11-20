using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class TurmaAlunoCadastroDto
{
    public Guid CursoId { get; set; }
    public Guid TurmaId { get; set; }
    public Guid AlunoId { get; set; }
}