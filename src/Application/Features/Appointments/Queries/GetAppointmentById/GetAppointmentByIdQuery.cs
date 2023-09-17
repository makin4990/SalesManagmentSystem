using AutoMapper;
using Application.Features.Appointments.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdQuery: IRequest<AppointmentDto>
{
    public int Id { get; set; }
}
public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentByIdQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
    {
        _mapper = mapper;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        Appointment appointment = await _appointmentRepository.GetAsync(i=> i.Id == request.Id);
        AppointmentDto appointmentDto = _mapper.Map<Appointment, AppointmentDto>(appointment);
        return appointmentDto;
    }
}
