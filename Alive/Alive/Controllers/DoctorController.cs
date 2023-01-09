using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult vitalsign()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult Checkup()
        {
            return View();
        }
        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
        public IActionResult DocInfo()
        {
            return View();
        }
    }
}
