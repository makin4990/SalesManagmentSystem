using AutoMapper;
using Application.Features.Categorys.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<CreateCategoryDto>
    {
        public int Id {get; set;}
        public string Name {get; set;}


    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        //private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category mappedCategory = _mapper.Map<Category>(request);
            Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreateCategoryDto createdCategoryDto = _mapper.Map<CreateCategoryDto>(createdCategory);
            return createdCategoryDto;
        }
    }
}
