using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using CoreFramework.Persistence.Repositories;

namespace Persistence.Repositories;

public class AppointmentProductRepository: EfRepositoryBase<AppointmentProduct, SmsDbContext>, IAppointmentProductRepository
{
    public AppointmentProductRepository(SmsDbContext context):base(context)
    {

    }
}

