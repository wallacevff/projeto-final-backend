using ProjetoFinalBackend.Domain.SistemaModels;

namespace ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

public class Video : Arquivo
{
    IList<ComentarioVideo>? Comentarios { get; set; } //Dono
}