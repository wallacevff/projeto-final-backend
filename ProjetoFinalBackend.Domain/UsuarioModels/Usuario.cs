using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public abstract class  Usuario : DefaultEntity<Guid>
{

    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid? ImagemId { get; set; }
    public Imagem? Imagem { get; set; }
    public TipoUsuarioEnum TipoUsuarioCod { get; set; }
    public TipoUsuario? TipoUsuario { get; set; }

    public Usuario()
    {
        
    }
}

public class UsuarioModel : Usuario{}