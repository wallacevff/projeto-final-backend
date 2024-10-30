using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.Shared.Filters;

namespace ProjetoFinalBackend.Application.Services.Usuario;

public class UsuarioService
    (IMapper mapper,
        IUsuarioRepository usuarioRepository)
: IUsuarioService
{
    public async Task<UsuarioDto> AddAsync(UsuarioCadastroDto dto)
    {
        var addedEntity = mapper.Map<UsuarioDto>(await usuarioRepository.AddAsync(mapper.Map<Domain.UsuarioModels.Usuario>(dto)));
        await usuarioRepository.SaveChangesAsync();
        return addedEntity;
    }

    public async Task<PagedResultDto<UsuarioDto>> GetAllAsync(UsuarioFilter filter)
    {
        return mapper.Map<PagedResultDto<UsuarioDto>>(await usuarioRepository.GetAllAsync(filter));
    }

    public async Task<UsuarioDto> GetByIdAsync(Guid id)
    {
        return mapper.Map<UsuarioDto>(await usuarioRepository.GetAsync(id));
    }

    public async Task UpdateAsync(UsuarioDto dto)
    {
        var usuario = await usuarioRepository.GetAsync(dto.Id);
        if (usuario is null)
            throw new ArgumentNullException("Tipo de usuário não encontrado");
        mapper.Map(dto, usuario);
        await usuarioRepository.UpdateAsync(usuario);
        await usuarioRepository.SaveChangesAsync();
    }

    public async Task<UsuarioDto> DeleteAsync(Guid id)
    {
        var usuario = await usuarioRepository.GetAsync(id);
        if (usuario is null)
            throw new ArgumentNullException("Tipo de usuário não encontrado");
        var deleted = await usuarioRepository.DeleteAsync(usuario);
        await usuarioRepository.SaveChangesAsync();
        return mapper.Map<UsuarioDto>(deleted);
    }
}