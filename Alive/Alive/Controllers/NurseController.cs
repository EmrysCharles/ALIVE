using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class NurseController : Controller
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
        public IActionResult Bed()
        {
            return View();
        }
        public IActionResult Bedcategory()
        {
            return View();
        }
        public IActionResult BedAllotment()
        {
            return View();
        }
    }
}
