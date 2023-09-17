using AutoMapper;
using Application.Features.AppointmentProducts.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.AppointmentProducts.Queries.GetAppointmentProductById;

public class GetAppointmentProductByIdQuery: IRequest<AppointmentProductDto>
{
    public int Id { get; set; }
}
public class GetAppointmentProductByIdQueryHandler : IRequestHandler<GetAppointmentProductByIdQuery, AppointmentProductDto>
{
    private readonly IMapper _mapper;
    private readonly IAppointmentProductRepository _appointmentproductRepository;

    public GetAppointmentProductByIdQueryHandler(IMapper mapper, IAppointmentProductRepository appointmentproductRepository)
    {
        _mapper = mapper;
        _appointmentproductRepository = appointmentproductRepository;
    }

    public async Task<AppointmentProductDto> Handle(GetAppointmentProductByIdQuery request, CancellationToken cancellationToken)
    {
        AppointmentProduct appointmentproduct = await _appointmentproductRepository.GetAsync(i=> i.Id == request.Id);
        AppointmentProductDto appointmentproductDto = _mapper.Map<AppointmentProduct, AppointmentProductDto>(appointmentproduct);
        return appointmentproductDto;
    }
}
