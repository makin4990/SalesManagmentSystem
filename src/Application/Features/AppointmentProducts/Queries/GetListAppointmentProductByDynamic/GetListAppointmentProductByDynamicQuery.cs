using AutoMapper;
using Application.Features.AppointmentProducts.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using CoreFramework.Persistence.Paging;
using MediatR;


namespace Application.Features.AppointmentProducts.Queries.GetListAppointmentProductByDynamic;

public class GetListAppointmentProductByDynamicQuery : IRequest<AppointmentProductListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

}
public class GetListAppointmentProductByDynamicQueryHandler : IRequestHandler<GetListAppointmentProductByDynamicQuery, AppointmentProductListModel>
{
    private readonly IMapper _mapper;
    private readonly IAppointmentProductRepository _appointmentproductRepository;

    public GetListAppointmentProductByDynamicQueryHandler(IMapper mappler, IAppointmentProductRepository appointmentproductRepository)
    {
        _mapper = mappler;
        _appointmentproductRepository = appointmentproductRepository;
    }

    public async Task<AppointmentProductListModel> Handle(GetListAppointmentProductByDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<AppointmentProduct> appointmentproducts = await _appointmentproductRepository.GetListByDynamicAsync(request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        AppointmentProductListModel mappedModels = _mapper.Map<AppointmentProductListModel>(appointmentproducts);

        return mappedModels;

    }
}
