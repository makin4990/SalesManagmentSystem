using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Forgot()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            object data = new { usernameOrEmail = "Mstring", password = "Mstring.123" };
            var result = await _client.PostAsync<object>(@"api/Auth/login", data);

            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
