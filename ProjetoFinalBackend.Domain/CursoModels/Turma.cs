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

    public class Key(Guid cursoId, Guid turmaId)
    {
        public Guid CursoId { get; set; } = cursoId;
        public Guid TurmaId { get; set; } = turmaId;

        public override bool Equals(object? obj)
        {
            if(obj is not Key key) return false;
            return CursoId == key.CursoId && TurmaId == key.TurmaId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CursoId, TurmaId);
        }
    }

    public Key GetKey()
    {
        return new Key(CursoId, TurmaId);
    }
}