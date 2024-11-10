using ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;
using ProjetoFinalBackend.Application.Contracts.Dtos.Curso;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Conteudo;

public abstract class AtividadeDto
{
    public Guid AtividadeId { get; set; }
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
    public Guid CursoId { get; set; }
    public CursoDto? Curso { get; set; }
    public Guid TurmaId { get; set; }
    public TurmaDto? Turma { get; set; }
    public IList<ArquivoDto>? Anexos { get; set; }
    public TipoAtividade TipoAtividade  { get; set; }
    private DateTime _createdAt;
}