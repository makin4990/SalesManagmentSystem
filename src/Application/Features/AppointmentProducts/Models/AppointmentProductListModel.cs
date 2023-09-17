using Application.Features.AppointmentProducts.Dtos;
using CoreFramework.Persistence.Paging;

namespace Application.Features.AppointmentProducts.Models;
public class AppointmentProductListModel:BasePageableModel
{
    public IList<AppointmentProductDto> Items { get; set; }
}
