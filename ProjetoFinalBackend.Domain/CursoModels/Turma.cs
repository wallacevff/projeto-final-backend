using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.CursoModels;

public class Turma
{
    public Guid TurmaId { get; set; }
    public Guid CursoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public short Numero { get; set; }
    public short Tamanho { get; set; }
    public short QtdAlunos { get; set; } //Ignorar no Database
    
    public Curso? Curso { get; set; }
    public IList<Atividade>? Atividades { get; set; }
    public IList<Forum>? Forums { get; set; } //Dono de Foruns
    public IList<TurmaAluno>? Alunos { get; set; } //Contém Alunos
}