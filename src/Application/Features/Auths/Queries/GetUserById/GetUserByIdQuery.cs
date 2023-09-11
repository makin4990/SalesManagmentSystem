using AutoMapper;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auths.Queries.GetUserById;

public class GetUserByIdQuery: IRequest<UserDto>
{
    public int Id { get; set; }
}
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public GetUserByIdQueryHandler(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.Id.ToString());
        UserDto userDto = _mapper.Map<User, UserDto>(user);
        return userDto;
    }
}
