using AutoMapper;
using Application.Features.AppointmentProducts.Commands.CreateAppointmentProduct;
using Application.Features.AppointmentProducts.Dtos;
using Application.Features.AppointmentProducts.Models;
using Application.Features.AppointmentProducts.Commands.UpdateAppointmentProduct;
using Domain.Entities;
using CoreFramework.Persistence.Paging;

namespace Application.Features.AppointmentProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppointmentProduct, AppointmentProductListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<IPaginate<AppointmentProduct>, AppointmentProductListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateAppointmentProductCommand, AppointmentProduct>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateAppointmentProductCommand, AppointmentProduct>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateAppointmentProductDto, AppointmentProduct>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateAppointmentProductDto, AppointmentProduct>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<AppointmentProductDto, AppointmentProduct>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

    }
}

