using Domain.Entities;
using CoreFramework.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>, IRepository<Appointment>
    {
    }
}

