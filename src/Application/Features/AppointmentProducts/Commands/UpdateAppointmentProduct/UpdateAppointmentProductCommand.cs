using AutoMapper;
using Application.Features.AppointmentProducts.Commands.CreateAppointmentProduct;
using Application.Features.AppointmentProducts.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppointmentProducts.Commands.UpdateAppointmentProduct;

public class UpdateAppointmentProductCommand: IRequest<UpdateAppointmentProductDto>
{
    public int Id {get; set;}
    public int AppointmentId {get; set;}
    public int ProductId {get; set;}
   public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public class UpdateAppointmentProductCommandHandler : IRequestHandler<UpdateAppointmentProductCommand,UpdateAppointmentProductDto>
{
    private readonly IAppointmentProductRepository _appointmentproductRepository;
    private readonly IMapper _mapper;
    //private readonly AppointmentProductBusinessRules _appointmentproductBusinessRules;

    public UpdateAppointmentProductCommandHandler(IAppointmentProductRepository appointmentproductRepository, IMapper mapper)
    {
        _appointmentproductRepository = appointmentproductRepository;
        _mapper = mapper;
    }

    public async Task<UpdateAppointmentProductDto> Handle(UpdateAppointmentProductCommand request, CancellationToken cancellationToken)
    {

        AppointmentProduct? entityToUpdate = await _appointmentproductRepository.GetAsync(i => i.Id == request.Id);
        AppointmentProduct? mappedAppointmentProduct = _mapper.Map(request,entityToUpdate);
        AppointmentProduct? Updated = await _appointmentproductRepository.UpdateAsync(mappedAppointmentProduct);
        UpdateAppointmentProductDto updatedDto = _mapper.Map<UpdateAppointmentProductDto>(Updated);
        return updatedDto;
    }
}

