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
        bool EditLabTest(LabTestFormViewModel LabTestFormViewModel);
        bool DeleteLabTest(int id);
        bool EditAppointment(AppointmentFormViewModel AppointmentFormViewModel);
        bool DeleteAppointment(int id);
        bool EditDoctor(DoctorFormViewModel DoctorFormViewModel);
        bool DeleteDoctorInfo(Guid Id);
        bool EditNurse(NurseFormViewModel NurseFormViewModel);
        bool DeleteNurse(Guid id);
        bool DeleteMedicine(int id);
        bool EditMedicine(TreatmentFormViewModel TreatmentFormViewModel);
        bool DeletePayment(Guid id);
        bool EditPayment(PaymentFormViewModel PaymentFormViewModel);
        bool DeleteCheckup(Guid id);
        bool EditCheckup(CheckupFormViewModel CheckupFormViewModel);
    }    
        

}
