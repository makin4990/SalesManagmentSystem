using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
