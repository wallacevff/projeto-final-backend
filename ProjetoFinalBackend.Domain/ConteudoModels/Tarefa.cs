using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.ConteudoModels;

public class Tarefa : Atividade
{

    public bool Avaliacao { get; set; }
    public DateTime? PrazoDeEntrega { get; set; }
}