using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using CoreFramework.Persistence.Repositories;

namespace Persistence.Repositories;

public class AppointmentRepository: EfRepositoryBase<Appointment, SmsDbContext>, IAppointmentRepository
{
    public AppointmentRepository(SmsDbContext context):base(context)
    {

    }
}

