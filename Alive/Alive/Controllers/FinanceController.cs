using Alive.data;
using Alive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alive.Controllers
{
    public class FinanceController : Controller
    {
        private readonly AppDbContext _db;


        public FinanceController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Payment(Guid Id)
        {
            var signs = _db.Payments.Where(x => x.Id != Id).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult PaymentCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PaymentCreate(Payment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Payments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Payment");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult PaymentEdit(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Payments.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PaymentEdit(Payment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Payments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Payment");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult PaymentDelete(Guid Id)
        {
            if (Id == null || Id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Payments.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PaymentDelete(Guid? Id)
        {
            var obj = _db.DocInfos.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.DocInfos.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("DocInfo");
            }
            return View(obj);
        }

        //public IActionResult Expenses()
        //{
        //    var signs = _db.Expenses.Where(x => x.Id != 0).ToList();
        //    return View(signs);
        //}

        ////get - Create
        //public IActionResult ExpensesCreate()
        //{

        //    return View();
        //}
        ////Post - Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesCreate(Expenses obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Expenses.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Expenses");
        //    }
        //    return View(obj);
        //}
        ////get - Edit
        //[HttpGet]
        //public IActionResult ExpensesEdit(int Id)
        //{
        //    if (Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Expenses.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(obj);
        //}
        ////Post -Edit

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesEdit(Expenses obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Expenses.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Expenses");
        //    }
        //    return View(obj);
        //}
        ////get - Delete
        //public IActionResult ExpensesDelete(int Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Expenses.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound(obj);
        //    }

        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesDelete(int? Id)
        //{
        //    var obj = _db.Checkups.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _db.Checkups.Remove(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Checkup");
        //    }
        //    return View(obj);
        //}
        //public IActionResult Debt()
        //{
        //    return View();
        //}
        public IActionResult PayCategory()
        {
            var signs = _db.PayCategories.Where(x => x.Id != 0).ToList();
            return View(signs);
        }

        //get - Create
        public IActionResult PayCategoryCreate()
        {

            return View();
        }
        //Post - Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PayCategoryCreate(PayCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.PayCategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("PayCategory");
            }
            return View(obj);
        }
        //get - Edit
        [HttpGet]
        public IActionResult PayCategoryEdit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var obj = _db.PayCategories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Post -Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PayCategoryEdit(PayCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.PayCategories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("PayCategory");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult PayCategoryDelete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.PayCategories.Find(Id);
            if (obj == null)
            {
                return NotFound(obj);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PayCategoryDelete(int Id)
        {
            var obj = _db.PayCategories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.PayCategories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("paycategories");
            }
            return View(obj);
        }


        //public IActionResult ExpenseCategory()
        //{
        //    var signs = _db.ExpensesCategories.Where(x => x.Id != 0).ToList();
        //    return View(signs);
        //}

        ////get - Create
        //public IActionResult ExpensesCategoryCreate()
        //{

        //    return View();
        //}
        ////Post - Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesCategoryCreate(ExpensesCategory obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.ExpensesCategories.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("ExpensesCategory");
        //    }
        //    return View(obj);
        //}
        ////get - Edit
        //[HttpGet]
        //public IActionResult ExpensesCategoryEdit(int Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.ExpensesCategories.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(obj);
        //}
        ////Post -Edit

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesCategoryEdit(ExpensesCategory obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.ExpensesCategories.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("ExpensesCategory");
        //    }
        //    return View(obj);
        //}
        ////get - Delete
        //public IActionResult ExpensesCategoryDelete(int? Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.ExpensesCategories.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound(obj);
        //    }

        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExpensesCategoryDelete(int Id)
        //{
        //    var obj = _db.ExpensesCategories.Find(Id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _db.ExpensesCategories.Remove(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("ExpensesCategory");
        //    }
        //    return View(obj);
        //}
        public IActionResult Fin()
        {
            return View();
        }
        public IActionResult UserManagement()
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
