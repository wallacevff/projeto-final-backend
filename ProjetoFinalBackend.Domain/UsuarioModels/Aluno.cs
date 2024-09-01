using ProjetoFinalBackend.Domain.Curso;

namespace ProjetoFinalBackend.Domain.Usuario;

public class Aluno
{
    public IList<Turma> Turmas { get; set; } = new List<Turma>(); //Está inscrito em turmas>
}