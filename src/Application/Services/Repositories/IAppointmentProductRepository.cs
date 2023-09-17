using Domain.Entities;
using CoreFramework.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface IAppointmentProductRepository : IAsyncRepository<AppointmentProduct>, IRepository<AppointmentProduct>
    {
    }
}

