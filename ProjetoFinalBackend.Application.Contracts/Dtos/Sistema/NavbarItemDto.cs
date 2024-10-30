using System.Security.Cryptography;

namespace ProjetoFinalBackend.Application.Contracts.Dtos.Sistema;

public class NavbarItemDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}