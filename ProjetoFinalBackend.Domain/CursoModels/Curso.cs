using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.CursoModels;

public class Curso : DefaultEntity<Guid>
{
    public string? Descricao { get; set; }
    public Guid CategoriaId { get; set; }
    public Guid ProfessorId { get; set; }
    public Professor Professor { get; set; } = new Professor();
    public Modalidade Modalidade { get; set; }
    public IList<Turma> Turmas { get; set; } = new List<Turma>(); //Dono de Turmas
}