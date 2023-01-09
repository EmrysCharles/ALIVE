using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Patienttest()
        {
            return View();
        }
        public IActionResult Labtest()
        {
            return View();
        }
        public IActionResult LabTestCategory()
        {
            return View();
        }
    }
}
