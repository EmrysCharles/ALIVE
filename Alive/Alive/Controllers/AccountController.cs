using Alive.data;
using Alive.Enum;
using Alive.Helpers;
using Alive.IHelpers;
using Alive.Models;
using Alive.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Alive.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDropdownhelper _dropdownhelper;

        public AccountController(AppDbContext context, IUserHelper userHelper, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IDropdownhelper dropdownhelper )
        {
            _context = context;
            _userHelper = userHelper;
            _userManager = userManager;
            _signInManager = signInManager;
            _dropdownhelper = dropdownhelper;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.Dropdownkeys = await _dropdownhelper.GetGenderDropdownByKey(AliveProjectEnums.GenderDropdownKey);

            ViewBag.Country = _context.Country.Where(x => x.Id != 0).ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminRegister()
        {
            ViewBag.Dropdownkeys = await _dropdownhelper.GetGenderDropdownByKey(AliveProjectEnums.GenderDropdownKey);

            ViewBag.Country = _context.Country.Where(x => x.Id != 0).ToList();
            return View();
        }
        [HttpPost]
        public JsonResult AdminRegister(string userDetails)
        {
            ViewBag.Dropdownkeys = _dropdownhelper.GetGenderDropdownByKey(AliveProjectEnums.GenderDropdownKey);
            //ViewBag.Country = _context.Country.Where(x => x.Id != 0).ToList();
            var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(userDetails);
            if (applicationUserViewModel != null)
            {
                var user = _userHelper.RegisterUser(applicationUserViewModel).Result;
                if (user != null)
                {
                    var userRole = _userManager.AddToRoleAsync(user, "Admin").Result;
                    if (userRole.Succeeded)
                    {
                        return Json(new { isError = false, msg = "Admin Registered Successfully" });
                    }
                }
            }
            return Json(new { isError = true, msg = "Error Occurred" });
        }
        [HttpPost]
        public JsonResult registerUser(string userDetails)
        {
            ViewBag.Dropdownkeys =  _dropdownhelper.GetGenderDropdownByKey(AliveProjectEnums.GenderDropdownKey);

            //ViewBag.Country = _context.Country.Where(x => x.Id != 0).ToList();

            var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(userDetails);
            if (applicationUserViewModel!= null)
            {
                var user = _userHelper.RegisterUser(applicationUserViewModel).Result;
                if (user != null)
                {
                   var userRole = _userManager.AddToRoleAsync(user, "Users").Result;
                    if (userRole.Succeeded)
                    {
                        return Json(new { isError = false, msg = "User Registered Successfully" });
                    }
                    
                }
            }
            return Json(new { isError = true, msg = "Error Occurred" }); 
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<JsonResult> Login(string userDetails)
        {
            var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(userDetails);
            if (applicationUserViewModel != null)
            {
                var user =await _userHelper.GetUser(applicationUserViewModel.Email).ConfigureAwait(false);
                var signIn =await _signInManager.PasswordSignInAsync(user, applicationUserViewModel.Password, true, false).ConfigureAwait(false);
                if (signIn.Succeeded)
                {
                    var url = _userHelper.GetValidatedUrl(user);
                        return Json(new { isError = false, url = url });
                    
                }
            }
            return Json(new { isError = true, msg = "Error Occurred" });
        }

        [HttpGet]
        public IActionResult LoadState(int id)
        {
            var state = _context.State.Where(x => x.CountryId == id).ToList();
            return Json(state);
        }
    }


}
