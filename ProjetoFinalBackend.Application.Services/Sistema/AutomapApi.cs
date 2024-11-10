using AutoMapper;
using ProjetoFinalBackend.Application.Contracts.Services;

namespace ProjetoFinalBackend.Application.Services.Sistema;

public class AutomapApi(IMapper mapper) : IAutomapApi
{
    public TDestination MapFrom<TDestination>(object source)
        where TDestination : class
    {
        return mapper.Map<TDestination>(source);
    }



    public void MapTo<TDestination, TSource>(TSource source, TDestination destination)
        where TDestination : class
        where TSource : class
    {
        mapper.Map(source, destination);
    }

}