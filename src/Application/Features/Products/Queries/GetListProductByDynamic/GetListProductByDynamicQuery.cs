using AutoMapper;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using CoreFramework.Persistence.Paging;
using MediatR;


namespace Application.Features.Products.Queries.GetListProductByDynamic;

public class GetListProductByDynamicQuery : IRequest<ProductListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

}
public class GetListProductByDynamicQueryHandler : IRequestHandler<GetListProductByDynamicQuery, ProductListModel>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetListProductByDynamicQueryHandler(IMapper mappler, IProductRepository productRepository)
    {
        _mapper = mappler;
        _productRepository = productRepository;
    }

    public async Task<ProductListModel> Handle(GetListProductByDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Product> products = await _productRepository.GetListByDynamicAsync(request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        ProductListModel mappedModels = _mapper.Map<ProductListModel>(products);

        return mappedModels;

    }
}
