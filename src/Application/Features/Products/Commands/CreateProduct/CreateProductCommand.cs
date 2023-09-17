using AutoMapper;
using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<CreateProductDto>
    {
        public int Id {get; set;}
        public int CategoryId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}


    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        //private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            Product createdProduct = await _productRepository.AddAsync(mappedProduct);
            CreateProductDto createdProductDto = _mapper.Map<CreateProductDto>(createdProduct);
            return createdProductDto;
        }
    }
}
