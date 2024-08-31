namespace ProjetoFinalBackend.Domain;

public abstract class DefaultEntity<TId> where TId : struct
{
    public TId Id { get; set; } = new TId();
}