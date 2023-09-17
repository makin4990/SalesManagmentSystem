using AutoMapper;
using Application.Features.Categorys.Commands.CreateCategory;
using Application.Features.Categorys.Dtos;
using Application.Features.Categorys.Models;
using Application.Features.Categorys.Commands.UpdateCategory;
using Domain.Entities;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Categorys.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateCategoryCommand, Category>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateCategoryDto, Category>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateCategoryDto, Category>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CategoryDto, Category>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

    }
}

