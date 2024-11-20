namespace ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;

public class LoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}