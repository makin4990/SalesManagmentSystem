using AutoMapper;
using Application.Features.Appointments.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using CoreFramework.Persistence.Paging;
using MediatR;


namespace Application.Features.Appointments.Queries.GetListAppointmentByDynamic;

public class GetListAppointmentByDynamicQuery : IRequest<AppointmentListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

}
public class GetListAppointmentByDynamicQueryHandler : IRequestHandler<GetListAppointmentByDynamicQuery, AppointmentListModel>
{
    private readonly IMapper _mapper;
    private readonly IAppointmentRepository _appointmentRepository;

    public GetListAppointmentByDynamicQueryHandler(IMapper mappler, IAppointmentRepository appointmentRepository)
    {
        _mapper = mappler;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<AppointmentListModel> Handle(GetListAppointmentByDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Appointment> appointments = await _appointmentRepository.GetListByDynamicAsync(request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        AppointmentListModel mappedModels = _mapper.Map<AppointmentListModel>(appointments);

        return mappedModels;

    }
}
