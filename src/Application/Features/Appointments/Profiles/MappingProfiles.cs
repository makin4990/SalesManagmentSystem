using AutoMapper;
using Application.Features.Appointments.Commands.CreateAppointment;
using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Models;
using Application.Features.Appointments.Commands.UpdateAppointment;
using Domain.Entities;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Appointments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Appointment, AppointmentListModelDto>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

        CreateMap<IPaginate<Appointment>, AppointmentListModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateAppointmentCommand, Appointment>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateAppointmentCommand, Appointment>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<CreateAppointmentDto, Appointment>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<UpdateAppointmentDto, Appointment>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        CreateMap<AppointmentDto, Appointment>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));

    }
}

