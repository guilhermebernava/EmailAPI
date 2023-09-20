using Domain.Utils;

namespace Domain.Entities;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime? DeletedAt { get;  set; }
}
