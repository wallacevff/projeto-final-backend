using System.Net;

namespace ProjetoFinalBackend.Domain.Shared;

public class UsuarioExisteException : Exception
{
    private HttpStatusCode _status;
    public HttpStatusCode Status { get => _status; }
    public UsuarioExisteException(string message, HttpStatusCode status) : base(message)
    {
        _status = status;
    }
}