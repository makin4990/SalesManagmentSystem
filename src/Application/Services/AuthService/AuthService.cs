
using Application.Features.Auths.Dtos;
using Application.Helpers;
using Application.Services.Tokens;
using CoreFramework.Mailing;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IMailService _mailService;
    private readonly ITokenHandler _tokenHandler;
    private readonly SignInManager<User> _signInManager;

    public AuthService(IConfiguration configuration,
        UserManager<User> userManager,
        IUserService userService,
        IMailService mailService,
        ITokenHandler tokenHandler,
        SignInManager<User> signInManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _userService = userService;
        _mailService = mailService;
        _tokenHandler = tokenHandler;
        _signInManager = signInManager;
    }

    public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
    {
        User user = await _userManager.FindByNameAsync(usernameOrEmail);
        if (user == null)
            user = await _userManager.FindByEmailAsync(usernameOrEmail);

        if (user == null)
            throw new Exception();

        var result = await _signInManager.CheckPasswordSignInAsync(user,password,false);

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);
        if (result.Succeeded) //Authentication başarılı!
        {
            Token token = await _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
            return token;
        }
       throw new Exception();
    }
    public async Task PasswordResetAsnyc(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            //byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
            //resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
            resetToken = resetToken.UrlEncode();
            string clientUrl = _configuration[""];
            var htmlBody = $"\r\n<!doctype html>\r\n<html lang=\"en-US\">\r\n\r\n<head>\r\n    <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\" />\r\n    <title>Reset Password Email Template</title>\r\n    <meta name=\"description\" content=\"Reset Password Email Template.\">\r\n    <style type=\"text/css\">\r\n        a:hover {{text-decoration: underline !important;}}\r\n    </style>\r\n</head>\r\n\r\n<body marginheight=\"0\" topmargin=\"0\" marginwidth=\"0\" style=\"margin: 0px; background-color: #f2f3f8;\" leftmargin=\"0\">\r\n    <!--100% body table-->\r\n    <table cellspacing=\"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\"\r\n        style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">\r\n        <tr>\r\n            <td>\r\n                <table style=\"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\"\r\n                    align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                          <a href=\"https://rakeshmandal.com\" title=\"logo\" target=\"_blank\">\r\n                            <img width=\"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">\r\n                          </a>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"\r\n                                style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"padding:0 35px;\">\r\n                                        <h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">You have\r\n                                            requested to reset your password</h1>\r\n                                        <span\r\n                                            style=\"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\"></span>\r\n                                        <p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">\r\n                                            We cannot simply send you your old password. A unique link to reset your\r\n                                            password has been generated for you. To reset your password, click the\r\n                                            following link and follow the instructions.\r\n                                        </p>\r\n                                        <a href=\"{clientUrl}\"/update-password/{user.Id}/{resetToken}\"\r\n                                            style=\"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\">Reset Password</a>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                            <p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.rakeshmandal.com</strong></p>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <!--/100% body table-->\r\n</body>\r\n\r\n</html>";
            Mail resetMail = new Mail
            {
                Subject = "Reset Password",
                HtmlBody = htmlBody,
                ToEmail = email,
                ToFullName = "Mert Semiz"
            };
            _mailService.SendMail(resetMail);
        }
    }
    public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
    {
        User? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
        {
            Token token = await _tokenHandler.CreateAccessToken(15, user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
            return token;
        }
        else
            throw new Exception();
    }
    public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
            //resetToken = Encoding.UTF8.GetString(tokenBytes);
            resetToken = resetToken.UrlDecode();

            return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
        }
        return false;
    }
}