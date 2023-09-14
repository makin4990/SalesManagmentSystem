using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using WebUI.Models.Accounts.Login;
using WebUI.Models.Accounts.Register;

namespace WebUI.Controllers
{
    public class AccountController : BaseController
    {
        HttpClient _httpClient;
        IConfiguration _configuration;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress= new Uri(configuration["ApiBaseURL"]);
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
            LoginResponseModel loginResponse = await _client.PostAsync<LoginResponseModel>(@"api/Auth/login", userLoginDto);
            try
            {

                if (loginResponse.Token is not null)
                {
                    var token = loginResponse.Token;

                    HttpContext.Session.SetString("SMS.Auth.Token", token.AccessToken);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout()
        {
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
                if(result is not null)
                {
                    return RedirectToAction("Index","Home");

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
