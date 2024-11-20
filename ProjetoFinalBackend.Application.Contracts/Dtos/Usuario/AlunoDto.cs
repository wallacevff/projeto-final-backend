namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class AlunoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}