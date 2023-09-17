using AutoMapper;
using Application.Features.Appointments.Commands.CreateAppointment;
using Application.Features.Appointments.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentCommand: IRequest<UpdateAppointmentDto>
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
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public int Statu {get; set;}
}

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand,UpdateAppointmentDto>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    //private readonly AppointmentBusinessRules _appointmentBusinessRules;

    public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<UpdateAppointmentDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {

        Appointment? entityToUpdate = await _appointmentRepository.GetAsync(i => i.Id == request.Id);
        Appointment? mappedAppointment = _mapper.Map(request,entityToUpdate);
        Appointment? Updated = await _appointmentRepository.UpdateAsync(mappedAppointment);
        UpdateAppointmentDto updatedDto = _mapper.Map<UpdateAppointmentDto>(Updated);
        return updatedDto;
    }
}

