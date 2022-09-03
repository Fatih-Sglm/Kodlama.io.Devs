namespace Core.Persistence.Repositories;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}