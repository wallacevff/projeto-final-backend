using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Domain.CursoModels;

public class Turma : DefaultEntity<Guid>
{
    public short Numero { get; set; }
    public short Tamanho { get; set; }
    public short QtdAlunos { get; set; } //Ignorar no Database
    public Guid CursoId { get; set; }
    public Curso? Curso { get; set; }
    public IList<Atividade>? Atividades { get; set; }
    public IList<Forum>? Forums { get; set; } //Dono de Foruns
    public IList<Aluno>? Alunos { get; set; } //Contém Alunos
}