namespace ProjetoFinalBackend.Domain;

public abstract class DefaultEntity<TId> where TId : struct
{
    public TId Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; } = DateTime.Now;
    public virtual DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public virtual DateTime? DeletedAt { get; set; }
}