using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository.Usuario;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Usuario;

public class UsuarioService(
    IAutomapApi mapper,
    IUsuarioRepository usuarioRepository) : 
    DefaultService<
        Domain.UsuarioModels.Usuario,
        UsuarioDto,
        UsuarioCadastroDto,
        UsuarioFilter,
        Guid
    >(usuarioRepository, mapper), IUsuarioService

{
    
}