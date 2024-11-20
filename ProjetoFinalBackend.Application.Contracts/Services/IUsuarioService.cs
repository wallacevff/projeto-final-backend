using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Contracts.Services;

public interface IUsuarioService : IDefaultService
    <UsuarioDto, UsuarioCadastroDto,UsuarioFilter, Guid>, IApplicationServiceContracts
{
    public Task<bool> Login(string usuario, string senha);
}

