using AutoMapper;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand: IRequest<UpdateProductDto>
{
    public int Id {get; set;}
    public int CategoryId {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,UpdateProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    //private readonly ProductBusinessRules _productBusinessRules;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        Product? entityToUpdate = await _productRepository.GetAsync(i => i.Id == request.Id);
        Product? mappedProduct = _mapper.Map(request,entityToUpdate);
        Product? Updated = await _productRepository.UpdateAsync(mappedProduct);
        UpdateProductDto updatedDto = _mapper.Map<UpdateProductDto>(Updated);
        return updatedDto;
    }
}

