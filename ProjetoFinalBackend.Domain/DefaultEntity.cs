namespace ProjetoFinalBackend.Domain;

public abstract class DefaultEntity<TId> where TId : struct
{
    public TId Id { get; set; } = new TId();
    public string Nome { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}