using Alive.Helpers;
using Alive.Models;
using Alive.ViewModel;

namespace Alive.IHelpers
{
    public interface IUserHelper
    {
        Task<ApplicationUser> RegisterUser(ApplicationUserViewModel applicationUserViewModel);
        Task<ApplicationUser> GetUser(string email);
        string GetValidatedUrl(ApplicationUser user);
    }
    
}
