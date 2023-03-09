using Alive.data;                                           
using Alive.IHelpers;
using Alive.Models;
using Alive.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;

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
                    if (userRole.Contains("USER"))
                    {
                        return "/Admin/Index";
                    }
                    else
                    {
                        return "/Admin/Index";
                    }
                }
            }
            return "/Account/Login";
        }
        //Doctor
        public bool EditDoctor(DoctorFormViewModel DoctorFormViewModel)
        {
           try 
            {
                if (DoctorFormViewModel != null)
                {
                    var DoctorBeEdited = _dbContext.DocInfos.Where(x => x.Id == DoctorFormViewModel.Id).FirstOrDefault();
                    if (DoctorBeEdited != null)
                    {
                        DoctorBeEdited.Id = DoctorFormViewModel.Id;
                        DoctorBeEdited.Name = DoctorFormViewModel.Name;
                        DoctorBeEdited.Email = DoctorFormViewModel.Email;
                        DoctorBeEdited.PhoneNumber = DoctorFormViewModel.PhoneNumber;
                        DoctorBeEdited.Category = DoctorFormViewModel.Category;
                        DoctorBeEdited.Gender = DoctorFormViewModel.Gender;
                        DoctorBeEdited.Country = DoctorFormViewModel.Country;

                        _dbContext.DocInfos.Update(DoctorBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteDoctorInfo(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {

                    var DoctorBeDeleted = _dbContext.DocInfos.Where(f => f.Id != Guid.Empty).FirstOrDefault();
                    if (DoctorBeDeleted != null)
                    {
                        DoctorBeDeleted.Deleted = true;
                        _dbContext.DocInfos.Update(DoctorBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //PatientAppointment
        public bool EditAppointment(AppointmentFormViewModel AppointmentFormViewModel)
        {
            try
            {
                if (AppointmentFormViewModel != null)
                {
                    var AppointmentBeEdited = _dbContext.patientAppointments.Where(x => x.Id == AppointmentFormViewModel.Id).FirstOrDefault();
                    if (AppointmentBeEdited != null)
                    {
                        AppointmentBeEdited.Id = AppointmentFormViewModel.Id;
                        AppointmentBeEdited.Name = AppointmentFormViewModel.Name;
                        AppointmentBeEdited.Email = AppointmentFormViewModel.Email;
                        AppointmentBeEdited.PhoneNumber = AppointmentFormViewModel.PhoneNumber;
                        AppointmentBeEdited.AppointmentDate = AppointmentFormViewModel.AppointmentDate;
                        AppointmentBeEdited.Description = AppointmentFormViewModel.Description;
                        AppointmentBeEdited.DateCreated = AppointmentFormViewModel.DateCreated;
                        _dbContext.patientAppointments.Update(AppointmentBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAppointment(int id)
        {
            try
            {
                if (id != 0)
                {

                    var AppointmenttoBeDeleted = _dbContext.patientAppointments.Where(f => f.Id == id).FirstOrDefault();
                    if (AppointmenttoBeDeleted != null)
                    {
                        AppointmenttoBeDeleted.Deleted = true;
                        _dbContext.patientAppointments.Update(AppointmenttoBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //labtest
        public bool EditLabTest(LabTestFormViewModel LabTestFormViewModel)
        {
            try
            {
                if (LabTestFormViewModel != null)
                {
                    var LabTestBeEdited = _dbContext.LabTests.Where(x => x.Id == LabTestFormViewModel.Id).FirstOrDefault();
                    if (LabTestBeEdited != null)
                    {
                        LabTestBeEdited.Id = LabTestFormViewModel.Id;
                        LabTestBeEdited.LabTestName = LabTestFormViewModel.LabTestName;
                        LabTestBeEdited.TestCategory = LabTestFormViewModel.TestCategory;
                        LabTestBeEdited.UnitPrice = LabTestFormViewModel.UnitPrice;
                        LabTestBeEdited.ReferenceRange = LabTestFormViewModel.ReferenceRange;
                        LabTestBeEdited.DateCreated = LabTestFormViewModel.DateCreated;
                        _dbContext.LabTests.Update(LabTestBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteLabTest(int id)
        {
            try
            {
                if (id != 0)
                {

                    var LabTestBeDeleted = _dbContext.LabTests.Where(f => f.Id == id).FirstOrDefault();
                    if (LabTestBeDeleted != null)
                    {
                        LabTestBeDeleted.Deleted = true;
                        _dbContext.LabTests.Update(LabTestBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EditNurse(NurseFormViewModel NurseFormViewModel)
        {
            try
            {
                if (NurseFormViewModel != null)
                {
                    var NurseBeEdited = _dbContext.NurseInfos.Where(x => x.Id == NurseFormViewModel.Id).FirstOrDefault();
                    if (NurseBeEdited != null)
                    {
                        NurseBeEdited.Id = NurseFormViewModel.Id;
                        NurseBeEdited.Name = NurseFormViewModel.Name;
                        NurseBeEdited.Email = NurseFormViewModel.Email;
                        NurseBeEdited.PhoneNumber = NurseFormViewModel.PhoneNumber;
                        NurseBeEdited.Gender = NurseFormViewModel.Gender;
                        NurseBeEdited.Country = NurseFormViewModel.Country;
                        _dbContext.NurseInfos.Update(NurseBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteNurse(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {

                    var NurseBeDeleted = _dbContext.NurseInfos.Where(f => f.Id != Guid.Empty).FirstOrDefault();
                    if (NurseBeDeleted != null)
                    {
                        NurseBeDeleted.Deleted = true;
                        _dbContext.NurseInfos.Update(NurseBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EditMedicine(TreatmentFormViewModel TreatmentFormViewModel)
        {
            try
            {
                if (TreatmentFormViewModel != null)
                {
                    var TreatmentBeEdited = _dbContext.Medicines.Where(x => x.Id == TreatmentFormViewModel.Id).FirstOrDefault();
                    if (TreatmentBeEdited != null)
                    {
                        TreatmentBeEdited.Id = TreatmentFormViewModel.Id;
                        TreatmentBeEdited.MedicineName = TreatmentFormViewModel.MedicineName;
                        TreatmentBeEdited.MedicineCategory = TreatmentFormViewModel.MedicineCategory;
                        TreatmentBeEdited.Amount = TreatmentFormViewModel.Amount;
                        _dbContext.Medicines.Update(TreatmentBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteMedicine(int id)
        {
            try
            {
                if (id != 0)
                {

                    var MedicineBeDeleted = _dbContext.Medicines.Where(f => f.Id == id).FirstOrDefault();
                    if (MedicineBeDeleted != null)
                    {
                        MedicineBeDeleted.Deleted = true;
                        _dbContext.Medicines.Update(MedicineBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EditPayment(PaymentFormViewModel PaymentFormViewModel)
        {
            try
            {
                if (PaymentFormViewModel != null)
                {
                    var PaymentBeEdited = _dbContext.Payments.Where(x => x.Id == PaymentFormViewModel.Id).FirstOrDefault();
                    if (PaymentBeEdited != null)
                    {
                        PaymentBeEdited.Id = PaymentFormViewModel.Id;
                        PaymentBeEdited.PatientName = PaymentFormViewModel.PatientName;
                        PaymentBeEdited.PaidAmount = PaymentFormViewModel.PaidAmount;
                        PaymentBeEdited.PaymentDate = PaymentFormViewModel.PaymentDate;
                        PaymentBeEdited.ModeOfPay = PaymentFormViewModel.ModeOfPay;
                        PaymentBeEdited.Proof = PaymentFormViewModel.Proof;

                        _dbContext.Payments.Update(PaymentBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeletePayment(Guid id)
        {
            try
            {
                if (id !=Guid.Empty)
                {

                    var PaymentBeDeleted = _dbContext.Payments.Where(f => f.Id == id).FirstOrDefault();
                    if (PaymentBeDeleted != null)
                    {
                        PaymentBeDeleted.Deleted = true;
                        _dbContext.Payments.Update(PaymentBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditCheckup(CheckupFormViewModel CheckupFormViewModel)
        {
            try
            {
                if (CheckupFormViewModel != null)
                {
                    var CheckupBeEdited = _dbContext.Checkups.Where(x => x.Id == CheckupFormViewModel.Id).FirstOrDefault();
                    if (CheckupBeEdited != null)
                    {
                        CheckupBeEdited.Id = (Guid)CheckupFormViewModel.Id;
                        CheckupBeEdited.FirstName = CheckupFormViewModel.FirstName;
                        CheckupBeEdited.LastName = CheckupFormViewModel.LastName;
                        CheckupBeEdited.Email = CheckupFormViewModel.Email;
                        CheckupBeEdited.Address = CheckupFormViewModel.Address;
                        CheckupBeEdited.Advice = CheckupFormViewModel.Advice;
                        CheckupBeEdited.Allergy = CheckupFormViewModel.Allergy;
                        CheckupBeEdited.Amount = CheckupFormViewModel.Amount;
                        CheckupBeEdited.AnyAddictionId = CheckupFormViewModel.AnyAddictionId;
                        CheckupBeEdited.SexuallyActiveId = CheckupFormViewModel.SexuallyActiveId;
                        CheckupBeEdited.TreatAmount = CheckupFormViewModel.TreatAmount;
                        CheckupBeEdited.Surgery = CheckupFormViewModel.Surgery;
                        CheckupBeEdited.NextVisist = CheckupFormViewModel.NextVisist;
                        CheckupBeEdited.Bed = CheckupFormViewModel.Bed;
                        CheckupBeEdited.BeforeMeal = CheckupFormViewModel.BeforeMeal;
                        CheckupBeEdited.BloodPressure = CheckupFormViewModel.BloodPressure;
                        CheckupBeEdited.BodyTemperature = CheckupFormViewModel.BodyTemperature;
                        CheckupBeEdited.BodyWeight = CheckupFormViewModel.BodyWeight;
                        CheckupBeEdited.DOB = CheckupFormViewModel.DOB;
                        CheckupBeEdited.DateCreated = CheckupFormViewModel.DateCreated;
                        CheckupBeEdited.Diagnoses = CheckupFormViewModel.Diagnoses;
                        CheckupBeEdited.DoseOfSelfmedication = CheckupFormViewModel.DoseOfSelfmedication;
                        CheckupBeEdited.DrugIntakeDuration = CheckupFormViewModel.DrugIntakeDuration;
                        CheckupBeEdited.DurationOfIllness = CheckupFormViewModel.DurationOfIllness;
                        CheckupBeEdited.Comment = CheckupFormViewModel.Comment;
                        CheckupBeEdited.Complaint = CheckupFormViewModel.Complaint;
                        CheckupBeEdited.Consultation = CheckupFormViewModel.Consultation;
                        CheckupBeEdited.Country = CheckupFormViewModel.Country;
                        CheckupBeEdited.GenderId = CheckupFormViewModel.GenderId;
                        CheckupBeEdited.GenotypeId = CheckupFormViewModel.GenotypeId;
                        CheckupBeEdited.Height = CheckupFormViewModel.Height;
                        CheckupBeEdited.HowToTake = CheckupFormViewModel.HowToTake;
                        CheckupBeEdited.IfYesWhen = CheckupFormViewModel.IfYesWhen;
                        CheckupBeEdited.Investigation = CheckupFormViewModel.Investigation;
                        CheckupBeEdited.Laboratory = CheckupFormViewModel.Laboratory;
                        CheckupBeEdited.MaritalStatusId = CheckupFormViewModel.MaritalStatusId;
                        CheckupBeEdited.Medicine = CheckupFormViewModel.Medicine;
                        CheckupBeEdited.MilitaryServiceId = CheckupFormViewModel.MilitaryServiceId;
                        CheckupBeEdited.MSMId = CheckupFormViewModel.MSMId;
                        CheckupBeEdited.NextVisist = CheckupFormViewModel.NextVisist;
                        CheckupBeEdited.Occupation = CheckupFormViewModel.Occupation;
                        CheckupBeEdited.Others = CheckupFormViewModel.Others;
                        CheckupBeEdited.PatientTypeId = CheckupFormViewModel.PatientTypeId;
                        CheckupBeEdited.Pharmacy = CheckupFormViewModel.Pharmacy;
                        CheckupBeEdited.Phone = CheckupFormViewModel.Phone;
                        CheckupBeEdited.PulseRate = CheckupFormViewModel.PulseRate;
                        CheckupBeEdited.Result = CheckupFormViewModel.Result;
                        CheckupBeEdited.SmokingHabitId = CheckupFormViewModel.SmokingHabitId;
                        CheckupBeEdited.State = CheckupFormViewModel.State;
                        CheckupBeEdited.Total = CheckupFormViewModel.Total;
                        CheckupBeEdited.TreatAmount = CheckupFormViewModel.TreatAmount;
                        CheckupBeEdited.Treatment = CheckupFormViewModel.Treatment;
                        CheckupBeEdited.UnprotectedSexId = CheckupFormViewModel.UnprotectedSexId;
                       _dbContext.Checkups.Update(CheckupBeEdited);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCheckup(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {

                    var CheckupBeDeleted = _dbContext.Checkups.Where(f => f.Id == id).FirstOrDefault();
                    if (CheckupBeDeleted != null)
                    {
                        CheckupBeDeleted.Deleted = true;
                        _dbContext.Checkups.Update(CheckupBeDeleted);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }







    }


}

