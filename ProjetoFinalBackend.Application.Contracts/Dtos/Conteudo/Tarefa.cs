namespace ProjetoFinalBackend.Application.Contracts.Dtos.Conteudo;

public class Tarefa : AtividadeDto
{

    public bool Avaliacao { get; set; }
    public DateTime? PrazoDeEntrega { get; set; }
}