namespace ProjetoFinalBackend.Application.Contracts.Dtos.Sistema;

public class NavbarItemCadastroDto
{
    public string Nome { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}