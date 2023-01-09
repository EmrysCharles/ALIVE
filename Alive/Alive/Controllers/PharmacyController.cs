using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class PharmacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Medicine()
        {
            return View();
        }
        public IActionResult MedicineCategory()
        {
            return View();
        }
    }
}
