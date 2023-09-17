using AutoMapper;
using Application.Features.Categorys.Commands.CreateCategory;
using Application.Features.Categorys.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categorys.Commands.UpdateCategory;

public class UpdateCategoryCommand: IRequest<UpdateCategoryDto>
{
    public int Id {get; set;}
    public string Name {get; set;}
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,UpdateCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    //private readonly CategoryBusinessRules _categoryBusinessRules;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {

        Category? entityToUpdate = await _categoryRepository.GetAsync(i => i.Id == request.Id);
        Category? mappedCategory = _mapper.Map(request,entityToUpdate);
        Category? Updated = await _categoryRepository.UpdateAsync(mappedCategory);
        UpdateCategoryDto updatedDto = _mapper.Map<UpdateCategoryDto>(Updated);
        return updatedDto;
    }
}

