using AutoMapper;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Domain.Entities;
using CoreFramework.Persistence.Paging;
using Application.Features.Auths.Commands.CreateUser;
using Application.Features.Auths.Commands.UpdateUser;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<IPaginate<User>, UserListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateUserCommand, User>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateUserCommand, User>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateUserDto, User>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateUserDto, User>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UserDto, User>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

    }
}

