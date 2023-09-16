using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Dtos;

public class LoginUserDto
{
    public LoginUserDto()
    {
        
    }

    public Token Token { get; set; }

    public LoginUserDto(Token token)
    {
        Token = token;
    }
}

