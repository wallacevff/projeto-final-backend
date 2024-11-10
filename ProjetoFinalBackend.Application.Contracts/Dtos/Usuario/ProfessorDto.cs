using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class ProfessorDto : UsuarioDto
{
    public IList<CursoDto>? Cursos { get; set; } 
}