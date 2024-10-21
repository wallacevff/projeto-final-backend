using ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class UsuarioCadastroDto
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid? ImagemId { get; set; }
    public ImagemDto? Imagem { get; set; }
    public TipoUsuarioEnum TipoUsuarioCod { get; set; }
    public TipoUsuarioDto? TipoUsuario { get; set; }
}