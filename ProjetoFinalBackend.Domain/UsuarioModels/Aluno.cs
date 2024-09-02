using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public class Aluno : Usuario
{
    public IList<TurmaAluno>? Turmas { get; set; } //Está inscrito em turmas>
}