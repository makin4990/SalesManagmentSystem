using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected ClientProxyHelper? _client => HttpContext?.RequestServices?.GetService<ClientProxyHelper>();

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
