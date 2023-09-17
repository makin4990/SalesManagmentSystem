using CoreFramework.Persistence.Repositories;

namespace Domain.Entities;
public class AppointmentProduct:Entity
{
    public int Id {get; set;}
    public int AppointmentId {get; set;}
    public int ProductId {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}

    public virtual Product Product { get; set;} 
    public virtual Appointment Appointment { get; set;}
}
