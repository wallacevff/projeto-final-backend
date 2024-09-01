using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public class Aluno
{
    public IList<Turma> Turmas { get; set; } = new List<Turma>(); //Está inscrito em turmas>
}