using CoreFramework.Persistence.Repositories;

namespace Domain.Entities;
public class Category:Entity
{
    public Category()
    {
            Products = new  HashSet<Product>();
    }
    public int Id {get; set;}
    public string Name {get; set;}

    public virtual ICollection<Product> Products { get; set;}   
}
