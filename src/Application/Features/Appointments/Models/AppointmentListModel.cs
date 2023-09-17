using Application.Features.Appointments.Dtos;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Appointments.Models;
public class AppointmentListModel:BasePageableModel
{
    public IList<AppointmentListModelDto> Items { get; set; }
}
