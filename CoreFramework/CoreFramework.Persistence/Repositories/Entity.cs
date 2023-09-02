namespace CoreFramework.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }

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
        StartedAt = startedAt;
        EndedAt = endedAt;
    }
}