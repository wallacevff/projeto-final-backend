using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public class Professor : Usuario
{
    public IList<Curso> Cursos { get; set; } = new List<Curso>(); //Dono de Curso
}