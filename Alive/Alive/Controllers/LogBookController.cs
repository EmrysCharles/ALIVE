using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class LogBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
