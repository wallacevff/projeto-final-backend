namespace ProjetoFinalBackend.Domain.Usuario;

public class Usuario: DefaultEntity<Guid>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid TipoUsuarioId { get; set; }
    public TipoUsuario? TipoUsuario { get; set; }
}