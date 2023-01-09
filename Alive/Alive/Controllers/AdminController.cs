using Alive.data;
using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db)
        {
            _db = db;
        }
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddDoc()
        {
            return View();
        }
        public IActionResult vitalSign()
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
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            return View();
        }
        public IActionResult Debt()
        {
            return View();
        }
        public IActionResult PayCategory()
        {
            return View();
        }
        public IActionResult LabInfo()
        {
            return View();
        }
        public IActionResult FinInfo()
        {
            return View();
        }
        public IActionResult PharmaInfo()
        {
            return View();
        }

        public IActionResult ExpenseCategory()
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
        public IActionResult paymentReport()
        {
            return View();
        }

        public IActionResult ExpenseReport()
        {
            return View();
        }
        public IActionResult doc()
        {
            return View();
        }
        public IActionResult nurs()
        {
            return View();
        }
        public IActionResult labo()
        {
            return View();
        }
        public IActionResult Fin()
        {
            return View();
        }
        public IActionResult  UserManagement()
        {
            return View();
        }
        public IActionResult ManagePage()
        {
            return View();
        }
        public IActionResult emailSetting()
        {
            return View();
        }
        public IActionResult userProfile()
        {
            return View();
        }
        public IActionResult IdentitySetting()
        {
            return View();
        }
        public IActionResult loginHistory()
        {
            return View();
        }

        public IActionResult companyInfo()
        {
            return View();
        }

        public IActionResult CurrencyList()
        {
            return View();
        }

    }

}
