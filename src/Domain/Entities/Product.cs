using CoreFramework.Persistence.Repositories;

namespace Domain.Entities;
public class Product:Entity
{
    public int Id {get; set;}
    public int CategoryId {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public virtual Category Category { get; set;}
}
