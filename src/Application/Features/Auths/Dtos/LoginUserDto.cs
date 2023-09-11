using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Dtos;

public class LoginUserDto
{
}

public class LoginUserSuccessDto : LoginUserDto
{
    public Token Token { get; set; }
}
public class LoginUserErrorDto : LoginUserDto
{
    public string Message { get; set; }
}
