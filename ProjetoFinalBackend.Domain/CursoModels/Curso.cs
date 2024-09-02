using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.CursoModels;

public class Curso : DefaultEntity<Guid>
{
    public string? Descricao { get; set; }
    public Guid ProfessorId { get; set; }
    public Professor? Professor { get; set; }
    public Modalidade Modalidade { get; set; }
    public IList<Turma>? Turmas { get; set; } //Dono de Turmas
}