using AutoMapper;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Commands.UpdateProduct;
using Domain.Entities;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateProductCommand, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateProductCommand, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateProductDto, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateProductDto, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<ProductDto, Product>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

    }
}

