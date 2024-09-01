using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.SistemaModels;

public class ComentarioVideo
{
    public string Comentario { get; set; }
    public Guid ArquivoId { get; set; }
    public Video Video { get; set; } = new Video();
    public Guid ComentarioId { get; set; }
    public Guid UsuarioId { get; set; }
    public UsuarioModels.Usuario? Usuario { get; set; }
    public short Hora { get; set; }
    public short Minuto { get; set; }
    public short Segundo { get; set; }

    public record Key(Guid arquivoId, Guid comentarioId);

    public Key GetKey()
    {
        return new Key(ArquivoId, ComentarioId);
    }
}