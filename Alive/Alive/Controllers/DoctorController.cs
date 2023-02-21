using Alive.data;
using Alive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppDbContext _db;


        public DoctorController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dvitalsign()
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
                return RedirectToAction("Dvitalsign");
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
                return RedirectToAction("Dvitalsign");
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
        //Post - Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id)
        {
            var obj = _db.VitalSigns.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.VitalSigns.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("vitalsign");
            }
            return View(obj);
        }


        public IActionResult AppointmentD()
        {
            var signs = _db.patientAppointments.Where(x => x.Id != 0).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult DAppointmentCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AppointmentCreate(PatientAppointment obj)
        {
            if (ModelState.IsValid)
            {
                _db.patientAppointments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AppointmentD");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult DAppointmentEdit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var obj = _db.patientAppointments.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DAppointmentEdit(PatientAppointment obj)
        {
            if (ModelState.IsValid)
            {
                _db.patientAppointments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("AppointmentD");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult DAppointmentDelete(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.patientAppointments.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DAppointmentDelete(int? Id)
        {
            var obj = _db.patientAppointments.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.patientAppointments.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("AppointmentD");
            }
            return View(obj);
        }
        public IActionResult DCheckup(Guid Id)
        {
            var signs = _db.Checkups.Where(x => x.Id != Id).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult DCheckupCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DCheckupCreate(Checkup obj)
        {
            if (ModelState.IsValid)
            {
                _db.Checkups.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("DCheckup");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult DCheckupEdit(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Checkups.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DCheckupEdit(Checkup obj)
        {
            if (ModelState.IsValid)
            {
                _db.Checkups.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("DCheckup");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult DCheckupDelete(Guid Id)
        {
            if (Id == null || Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Checkups.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DCheckupDelete(Guid? Id)
        {
            var obj = _db.Checkups.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Checkups.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("DCheckup");
            }
            return View(obj);
        }
        public IActionResult DPatient(Guid Id)
        {
            var signs = _db.patientInfos.Where(x => x.Id != Id).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult DPatientCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DPatientCreate(PatientInfo obj)
        {
            if (ModelState.IsValid)
            {
                _db.patientInfos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Patient");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult DPatientEdit(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.patientInfos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DPatientEdit(PatientInfo obj)
        {
            if (ModelState.IsValid)
            {
                _db.patientInfos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("DPatient");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult DPatientDelete(Guid Id)
        {
            if (Id == null || Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.patientInfos.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

            return View();
        }
        //Post - Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DPatientDelete(Guid? Id)
        {
            var obj = _db.patientInfos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.patientInfos.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Dpatient");
            }
            return View(obj);
        }


        public IActionResult DInfo()
        {
            return View();
        }
        public IActionResult DocInfo()
        {
            return View();
        }
    }
}
