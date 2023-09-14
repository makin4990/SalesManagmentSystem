using Application.Features.Auths.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tokens;

public class TokenHandler : ITokenHandler
{
    readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public TokenHandler(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<Token> CreateAccessToken(int second, User user)
    {
        Token token = new();

        //Security Key'in simetriğini alıyoruz.
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

        //Şifrelenmiş kimliği oluşturuyoruz.
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        //Oluşturulacak token ayarlarını veriyoruz.
        var userClaims = new List<Claim> { new(ClaimTypes.Name, user.UserName) };
        var userRoles =await _userManager.GetRolesAsync(user);
        userClaims.Add(new(ClaimTypes.Role, "HasToken"));
        if (userRoles.Any())
        {
            foreach (var role in userRoles)
            {
                userClaims.Add(new(ClaimTypes.Role, role));
            }

        }

        token.Expiration = DateTime.UtcNow.AddSeconds(second);
        JwtSecurityToken securityToken = new(
            audience: _configuration["TokenOptions:Audience"],
            issuer: _configuration["TokenOptions:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims: userClaims
            );

        //Token oluşturucu sınıfından bir örnek alalım.
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);


        token.RefreshToken = CreateRefreshToken();
        return token;
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}