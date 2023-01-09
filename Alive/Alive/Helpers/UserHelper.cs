using Alive.data;                                           
using Alive.IHelpers;
using Alive.Models;
using Alive.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Alive.Helpers
{
    public class UserHelper: IUserHelper
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserHelper(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext= dbContext;
            _userManager= userManager;
        }

        public async Task<ApplicationUser?> RegisterUser(ApplicationUserViewModel applicationUserViewModel)
        {
            var applicationUser = new ApplicationUser()
            {
                FirstName= applicationUserViewModel.FirstName,
                LastName = applicationUserViewModel.LastName,

                Email = applicationUserViewModel.Email,
                PhoneNumber= applicationUserViewModel.PhoneNumber,
                UserName = applicationUserViewModel.Email,
            };
           var user = await _userManager.CreateAsync(applicationUser, applicationUserViewModel.Password)
                .ConfigureAwait(false);
            if (user.Succeeded)
            {
                return applicationUser;
            }
            return null;
        }
       public async Task<ApplicationUser>? GetUser(string email)
        {
            var user = _dbContext.ApplicationUsers.Where(x=>x.Id!=null && x.Email==email).FirstOrDefault();
            if (user != null) 
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public string GetValidatedUrl(ApplicationUser user)
        {
          var userRoles =  _userManager.GetRolesAsync(user).Result;
            if (userRoles != null && userRoles.Count > 0)
            {
                foreach (var userRole in userRoles)
                {
                    if (userRole.Contains("ManagingDirector"))
                    {
                        return "/Admin/Index";
                    }
                    else if (userRole.Contains("Doctor"))
                    {
                        return "/Doctor/Index";
                    }
                    else if (userRole.Contains("Nurse"))
                    {
                        return "/Nurse/Index";

                    }
                    else if (userRole.Contains("LaboratoryScientist"))
                    {
                        return "/LaboratoryScientist/Index";
                    }
                    else if (userRole.Contains("Pharmacist"))
                    {
                        return "/Pharmacist/Index";
                    }
                    else if (userRole.Contains("FinancialManager"))
                    {
                        return "/FinancialManager/Index";
                    }
                    else
                    {
                        return "/Admin/Index";
                    }
                }
            }
            return "/Account/Login";
        }
    }
}
