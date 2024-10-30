using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.Shared.Enums;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Application.Services.Usuario;

public class TipoUsuarioService
    (IMapper mapper,
        ITipoUsuarioRepository tipoUsuarioRepository)
: ITipoUsuarioService
{
    public async Task<TipoUsuarioDto> AddAsync(TipoUsuarioCadastroDto dto)
    {
        var addedEntity = mapper.Map<TipoUsuarioDto>(await tipoUsuarioRepository.AddAsync(mapper.Map<TipoUsuario>(dto)));
        await tipoUsuarioRepository.SaveChangesAsync();
        return addedEntity;
    }

    public async Task<PagedResultDto<TipoUsuarioDto>> GetAllAsync(TipoUsuarioFilter filter)
    {
        return mapper.Map<PagedResultDto<TipoUsuarioDto>>(await tipoUsuarioRepository.GetAllAsync(filter));
    }

    public async Task<TipoUsuarioDto> GetByIdAsync(TipoUsuarioEnum id)
    {
        return mapper.Map<TipoUsuarioDto>(await tipoUsuarioRepository.GetAsync(id));
    }

    public async Task UpdateAsync(TipoUsuarioDto dto)
    {
        var tipoUsuario = await tipoUsuarioRepository.GetAsync(dto.Id);
        if(tipoUsuario is null)
            throw new ArgumentNullException("Tipo de usuário não encontrado");
        mapper.Map(dto, tipoUsuario);
        await tipoUsuarioRepository.UpdateAsync(tipoUsuario);
        await tipoUsuarioRepository.SaveChangesAsync();
    }

    public async Task<TipoUsuarioDto> DeleteAsync(TipoUsuarioEnum id)
    {
        var tipoUsuario = await tipoUsuarioRepository.GetAsync(id);
        if (tipoUsuario is null)
            throw new ArgumentNullException("Tipo de usuário não encontrado");
        var deleted = await tipoUsuarioRepository.DeleteAsync(tipoUsuario);
        await tipoUsuarioRepository.SaveChangesAsync();
        return mapper.Map<TipoUsuarioDto>(deleted);
    }
}