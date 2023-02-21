using Alive.data;
using Alive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class NurseController : Controller
    {
        private readonly AppDbContext _db;


        public NurseController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nvitalsign()
        {
            var signs = _db.VitalSigns.Where(x => x.Id != 0).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult VitalCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VitalCreate(VitalSign obj)
        {
            if (ModelState.IsValid)
            {
                _db.VitalSigns.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Nvitalsign");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult VitalEdit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var obj = _db.VitalSigns.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VitalEdit(VitalSign obj)
        {
            if (ModelState.IsValid)
            {
                _db.VitalSigns.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Nvitalsign");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.VitalSigns.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

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
        public IActionResult Info()
        { 
            return View();  
        }
    }
}
