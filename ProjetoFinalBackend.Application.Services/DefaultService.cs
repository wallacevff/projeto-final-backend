﻿using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Dtos.Pagination;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Repository;
using ProjetoFinalBackend.Domain.Shared.Filters;
using System.Reflection;

namespace ProjetoFinalBackend.Application.Services;

public abstract class DefaultService<TEntity, TDto, TCadastroDto, TFilter, TKey> (
    IDefaultRepository<TEntity, TFilter, TKey> repository,
    IAutomapApi mapper) : IDefaultService<TDto, TCadastroDto, TFilter, TKey>
    where TEntity : class
    where TDto : class
    where TCadastroDto : class
    where TFilter : Filter, new()
{
    public virtual async Task<TDto> AddAsync(TCadastroDto dto)
    {
        var createdEntity = mapper.MapFrom<TDto>(await repository.AddAsync(mapper.MapFrom<TEntity>(dto)));
        await repository.SaveChangesAsync().ConfigureAwait(false);
        return createdEntity;
    }

    public virtual Task AddRangeAsync(IList<TCadastroDto> dto)
    {
        repository.AddRangeAync(mapper.MapFrom<List<TEntity>>(dto));
        repository.SaveChangesAsync().ConfigureAwait(false);
        return Task.CompletedTask;
    }

    public virtual async Task<PagedResultDto<TDto>> GetAllAsync(TFilter filter)
    {
        var entities = await repository.GetAllAsync(filter);
        var dtos = mapper.MapFrom<PagedResultDto<TDto>>(entities);
        return dtos;
    }

    public virtual async Task<TDto> GetByIdAsync(TKey id)
    {
        var foundEntity = await repository.GetAsync(id);
        if (foundEntity is null)
            throw new ArgumentNullException("Entidade não encontrada");
        return mapper.MapFrom<TDto>(foundEntity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        PropertyInfo? props = (dto.GetType()).GetProperty("Id");
        TEntity? foundEntity = await repository.GetAsync((TKey)props?.GetValue(dto)!);
        if (foundEntity is null)
            throw new ArgumentNullException("Entidade não encontrada");
        mapper.MapTo(dto, foundEntity);
        await repository.UpdateAsync(foundEntity);
        await repository.SaveChangesAsync();
    }

    public async Task<TDto> DeleteAsync(TKey id)
    {
        TEntity? foundEntity = await repository.GetAsync(id);
        if (foundEntity is null)
            throw new ArgumentNullException("Entidade não encontrada");
        var deleted = await repository.DeleteAsync(foundEntity);
        await repository.SaveChangesAsync();
        return mapper.MapFrom<TDto>(deleted);
    }

    public Task<bool> HasAnyAsync()
    {
        return repository.HasAnyAsync();
    }
}