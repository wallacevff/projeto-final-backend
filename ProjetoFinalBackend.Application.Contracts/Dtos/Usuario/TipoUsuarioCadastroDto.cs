using System.Security.Cryptography;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class TipoUsuarioCadastroDto
{
    public string Nome { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}