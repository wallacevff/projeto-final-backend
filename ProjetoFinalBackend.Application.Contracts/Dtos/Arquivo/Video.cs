using ProjetoFinalBackend.Application.Contracts.Dtos.Arquivo;
using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

public class Video : ArquivoDto
{
    IList<ComentarioVideoDto>? Comentarios { get; set; } //Dono
}