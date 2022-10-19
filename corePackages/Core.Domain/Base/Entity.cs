namespace Core.Domain.Base;

public abstract class Entity<T> : IEntity
{
    public T Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}