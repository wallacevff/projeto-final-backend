using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;

public class ComentarioVideoDto
{
    public string? Comentario { get; set; }
    public Guid ArquivoId { get; set; }
    public Video? Video { get; set; }
    public Guid ComentarioId { get; set; }
    public Guid UsuarioId { get; set; }
    public UsuarioDto? Usuario { get; set; }
    public short Hora { get; set; }
    public short Minuto { get; set; }
    public short Segundo { get; set; }
}