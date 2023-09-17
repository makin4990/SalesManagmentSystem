using CoreFramework.Persistence.Paging;

namespace Application.Features.Appointments.Models;
public class AppointmentListModel:BasePageableModel
{
    public IList<AppointmentListModel> Items { get; set; }
}
