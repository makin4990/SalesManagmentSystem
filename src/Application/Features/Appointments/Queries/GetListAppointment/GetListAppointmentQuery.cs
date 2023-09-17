using AutoMapper;
using Application.Features.Appointments.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Paging;
using MediatR;

namespace Application.Features.Appointments.Queries.GetListAppointment;

public class GetListAppointmentQuery:IRequest<AppointmentListModel>
{
    public PageRequest  PageRequest { get; set; }
    public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, AppointmentListModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetListAppointmentQueryHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentListModel> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Appointment> appointmentList = await _appointmentRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            AppointmentListModel appointmentListModel = _mapper.Map<IPaginate<Appointment>, AppointmentListModel>(appointmentList);
            return appointmentListModel;
        }
    }
}

