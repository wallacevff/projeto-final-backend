using ProjetoFinalBackend.Application.Contracts.Dtos.Conteudo;
using ProjetoFinalBackend.Application.Contracts.Dtos.Forum;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Curso;

public class TurmaCadastroDto
{
    //public Guid TurmaId { get; set; }
    public Guid CursoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public short Numero { get; set; }
    public short Tamanho { get; set; }
    public short QtdAlunos { get; set; }
}