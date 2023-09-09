using AutoMapper;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using Domain.Entities;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using CoreFramework.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Queries.GetListUserByDynamic;

public class GetListUserByDynamicQuery : IRequest<UserListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

}
public class GetListUserByDynamicQueryHandler : IRequestHandler<GetListUserByDynamicQuery, UserListModel>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public GetListUserByDynamicQueryHandler(IMapper mappler, UserManager<User> userManager)
    {
        _mapper = mappler;
        _userManager = userManager;
    }

    public async Task<UserListModel> Handle(GetListUserByDynamicQuery request, CancellationToken cancellationToken)
    {
        return null;

    }
}
