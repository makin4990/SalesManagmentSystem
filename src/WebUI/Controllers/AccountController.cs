using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Forgot()
        {
            return View();
        }
        public IActionResult Login()
        {
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
