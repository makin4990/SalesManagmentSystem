using AutoMapper;
using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery: IRequest<ProductDto>
{
    public int Id { get; set; }
}
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetAsync(i=> i.Id == request.Id);
        ProductDto productDto = _mapper.Map<Product, ProductDto>(product);
        return productDto;
    }
}
