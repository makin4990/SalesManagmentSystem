using AutoMapper;
using Application.Features.Categorys.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Paging;
using MediatR;

namespace Application.Features.Categorys.Queries.GetListCategory;

public class GetListCategoryQuery:IRequest<CategoryListModel>
{
    public PageRequest  PageRequest { get; set; }
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categoryList = await _categoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            CategoryListModel categoryListModel = _mapper.Map<IPaginate<Category>, CategoryListModel>(categoryList);
            return categoryListModel;
        }
    }
}

