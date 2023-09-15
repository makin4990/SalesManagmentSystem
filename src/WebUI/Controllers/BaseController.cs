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
        protected void NotifyUI(string header, string message, ResponseType type)
        {
            TempData["Header"] = header;
            TempData["Message"] = message;
            switch (type)
            {
                case ResponseType.success:
                    TempData["Type"] = nameof(type);
                    break;
                case ResponseType.info:
                    TempData["Type"] = nameof(type);
                    break;
                case ResponseType.warning:
                    TempData["Type"] = nameof(type);
                    break;
                case ResponseType.error:
                    TempData["Type"] = nameof(type);
                    break;
                default:
                    TempData["Type"] = nameof(type);
                    break;
            }
        }
    }

    public enum ResponseType
    {
        success = 1,
        info,
        warning,
        error,
    };
}
