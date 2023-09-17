using AutoMapper;
using Application.Features.Categorys.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorys.Queries.GetCategoryById;

public class GetCategoryByIdQuery: IRequest<CategoryDto>
{
    public int Id { get; set; }
}
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetAsync(i=> i.Id == request.Id);
        CategoryDto categoryDto = _mapper.Map<Category, CategoryDto>(category);
        return categoryDto;
    }
}
