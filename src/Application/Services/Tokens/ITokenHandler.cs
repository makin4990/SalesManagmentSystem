using Application.Features.Auths.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tokens
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessToken(int second, User user);
        string CreateRefreshToken();
    }
}
