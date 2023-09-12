using Domain.Utils;

namespace Domain.Entities;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now.FormatDateTimeToBr();
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
}
