﻿using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebUI.Models.Accounts.Login;
using WebUI.Models.Accounts.Register;
using CoreFramework.Application.Responses;


namespace WebUI.Controllers
{
    public class AccountController : BaseController
    {
        IConfiguration _configuration;

        public AccountController()
        {
        }

        public IActionResult Forgot()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            var loginModel = new UserLoginDto();
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var response = await _client.PostAsync<LoginResponseModel>(@"api/Auth/login", userLoginDto);
                
                if (!response.Success)
                    NotifyUI("Hata", "Kullanıcı adı veya parola hatalı", ResponseType.error);

                var token = response.Data.Token;
                HttpContext.Session.SetString("SMS.Auth.Token", token.AccessToken);

                NotifyUI("Başarılı", "Giriş Başararılı", ResponseType.success);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            string? token = HttpContext?.Session?.GetString("SMS.Auth.Token");
            if (token is not null)
                HttpContext.Session.Remove("SMS.Auth.Token");

            return View();
        }
        public IActionResult Register()
        {
            RegisterUserDto registerModel = new();
            return View(registerModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            try
            {
                var result = await _client.PostAsync<RegisterUserResponse>(@"api/users", registerUserDto);
                if (result is not null)
                {
                    return RedirectToAction("Index", "Home");

                }
                return View(registerUserDto);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
