using CoreFramework.Persistence.Repositories;

namespace Domain.Entities;
public class Appointment:Entity
{
    public int Id {get; set;}
    public string Company {get; set;}
    public string ContactName {get; set;}
    public string MobileNo {get; set;}
    public string LandLineNo {get; set;}
    public string Address {get; set;}
    public int CityId {get; set;}
    public int ProvinceId {get; set;}
    public DateTime AppointmentDate {get; set;}
    public DateTime ContractDate {get; set;}
    public int AgentId {get; set;}
    public int FieldSalesmanId {get; set;}
    public DateTime? CreatedAt {get; set;}
    public DateTime? UpdatedAt {get; set;}
    public int Statu {get; set;}
}
