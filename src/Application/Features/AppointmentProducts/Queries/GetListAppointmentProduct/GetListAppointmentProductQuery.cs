using AutoMapper;
using Application.Features.AppointmentProducts.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Paging;
using MediatR;

namespace Application.Features.AppointmentProducts.Queries.GetListAppointmentProduct;

public class GetListAppointmentProductQuery:IRequest<AppointmentProductListModel>
{
    public PageRequest  PageRequest { get; set; }
    public class GetListAppointmentProductQueryHandler : IRequestHandler<GetListAppointmentProductQuery, AppointmentProductListModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentProductRepository _appointmentproductRepository;

        public GetListAppointmentProductQueryHandler(IMapper mapper, IAppointmentProductRepository appointmentproductRepository)
        {
            _mapper = mapper;
            _appointmentproductRepository = appointmentproductRepository;
        }

        public async Task<AppointmentProductListModel> Handle(GetListAppointmentProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AppointmentProduct> appointmentproductList = await _appointmentproductRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            AppointmentProductListModel appointmentproductListModel = _mapper.Map<IPaginate<AppointmentProduct>, AppointmentProductListModel>(appointmentproductList);
            return appointmentproductListModel;
        }
    }
}

