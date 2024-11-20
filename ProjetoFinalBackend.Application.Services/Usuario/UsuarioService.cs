using System.Net;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository.Usuario;
using ProjetoFinalBackend.Domain.Shared;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Usuario;

public class UsuarioService(
    IAutomapApi mapper,
    IUsuarioRepository usuarioRepository,
    ILogger<UsuarioService> logger) : 
    DefaultService<
        Domain.UsuarioModels.Usuario,
        UsuarioDto,
        UsuarioCadastroDto,
        UsuarioFilter,
        Guid
    >(usuarioRepository, mapper), IUsuarioService

{
    public async Task<bool> Login(string usuario, string senha)
    {
       var usuarioLogado = await usuarioRepository.Login(usuario, senha);
       if (usuarioLogado is null)
           return false;
       return true;
    }

    public override async Task<UsuarioDto> AddAsync(UsuarioCadastroDto dto)
    {
        var usuarioExiste = await usuarioRepository.HasAnyAsync(u => u.Email == dto.Email);
        if (usuarioExiste)
            throw new UsuarioExisteException("Usuário já existe", HttpStatusCode.Conflict);
        return await base.AddAsync(dto);
    }
}