using AutoMapper;
using Application.Features.Appointments.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand:IRequest<CreateAppointmentDto>
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
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentDto>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        //private readonly AppointmentBusinessRules _appointmentBusinessRules;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<CreateAppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment mappedAppointment = _mapper.Map<Appointment>(request);
            Appointment createdAppointment = await _appointmentRepository.AddAsync(mappedAppointment);
            CreateAppointmentDto createdAppointmentDto = _mapper.Map<CreateAppointmentDto>(createdAppointment);
            return createdAppointmentDto;
        }
    }
}
