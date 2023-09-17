using AutoMapper;
using Application.Features.AppointmentProducts.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.AppointmentProducts.Commands.CreateAppointmentProduct
{
    public class CreateAppointmentProductCommand:IRequest<CreateAppointmentProductDto>
    {
        public int Id {get; set;}
        public int AppointmentId {get; set;}
        public int ProductId {get; set;}
       public string Description {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}


    }
    public class CreateAppointmentProductCommandHandler : IRequestHandler<CreateAppointmentProductCommand, CreateAppointmentProductDto>
    {
        private readonly IAppointmentProductRepository _appointmentproductRepository;
        private readonly IMapper _mapper;
        //private readonly AppointmentProductBusinessRules _appointmentproductBusinessRules;

        public CreateAppointmentProductCommandHandler(IAppointmentProductRepository appointmentproductRepository, IMapper mapper)
        {
            _appointmentproductRepository = appointmentproductRepository;
            _mapper = mapper;
        }

        public async Task<CreateAppointmentProductDto> Handle(CreateAppointmentProductCommand request, CancellationToken cancellationToken)
        {
            AppointmentProduct mappedAppointmentProduct = _mapper.Map<AppointmentProduct>(request);
            AppointmentProduct createdAppointmentProduct = await _appointmentproductRepository.AddAsync(mappedAppointmentProduct);
            CreateAppointmentProductDto createdAppointmentProductDto = _mapper.Map<CreateAppointmentProductDto>(createdAppointmentProduct);
            return createdAppointmentProductDto;
        }
    }
}
