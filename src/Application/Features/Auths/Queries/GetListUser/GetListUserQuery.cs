using Application.Features.Users.Models;
using AutoMapper;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auths.Queries.GetListUser;

public class GetListUserQuery:IRequest<UserListModel>
{
    public PageRequest  PageRequest { get; set; }
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetListUserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}

