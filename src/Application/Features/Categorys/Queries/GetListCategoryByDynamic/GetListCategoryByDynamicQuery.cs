using AutoMapper;
using Application.Features.Categorys.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using CoreFramework.Persistence.Paging;
using MediatR;


namespace Application.Features.Categorys.Queries.GetListCategoryByDynamic;

public class GetListCategoryByDynamicQuery : IRequest<CategoryListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

}
public class GetListCategoryByDynamicQueryHandler : IRequestHandler<GetListCategoryByDynamicQuery, CategoryListModel>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetListCategoryByDynamicQueryHandler(IMapper mappler, ICategoryRepository categoryRepository)
    {
        _mapper = mappler;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryListModel> Handle(GetListCategoryByDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Category> categorys = await _categoryRepository.GetListByDynamicAsync(request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        CategoryListModel mappedModels = _mapper.Map<CategoryListModel>(categorys);

        return mappedModels;

    }
}
