using AutoMapper;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Paging;
using MediatR;

namespace Application.Features.Products.Queries.GetListProduct;

public class GetListProductQuery:IRequest<ProductListModel>
{
    public PageRequest  PageRequest { get; set; }
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> productList = await _productRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ProductListModel productListModel = _mapper.Map<IPaginate<Product>, ProductListModel>(productList);
            return productListModel;
        }
    }
}

