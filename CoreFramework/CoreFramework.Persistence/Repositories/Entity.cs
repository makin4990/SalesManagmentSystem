namespace CoreFramework.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }

    public Entity(int id, DateTime startedAt, DateTime? endedAt): this()
    {
        Id = id;
        CreatedAt = startedAt;
        UpdatedAt = endedAt;
    }
}