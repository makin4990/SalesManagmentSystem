namespace Application.Features.AppointmentProducts.Dtos;

public class AppointmentProductListModelDto
{
    public int Id {get; set;}
    public int AppointmentId {get; set;}
    public int ProductId {get; set;}
   public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}
