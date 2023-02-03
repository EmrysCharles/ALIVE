using Alive.data;
using Alive.Enum;
using Alive.Helpers;
using Alive.IHelpers;
using Alive.Models;
using Alive.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using System.Data;

namespace Alive.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IDropdownhelper _dropdownhelper;
        private readonly AppDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IEmailHelper _emailHelper; 
        private readonly IWebHostEnvironment _webHostEnvironment;
       
        public AdminController(AppDbContext db, IDropdownhelper dropdownhelper, AppDbContext context, IUserHelper userHelper,
            IWebHostEnvironment webHostEnvironment, IEmailHelper emailHelper)
        {
            _db = db;
            _dropdownhelper = dropdownhelper;
            _context = context;
            _userHelper = userHelper;
            _webHostEnvironment = webHostEnvironment;
            _emailHelper = emailHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //checkup
        public async Task<IActionResult> Checkup(Guid Id)
        {
            var signs = _db.Checkups.Where(x => x.Deleted == false).ToList();
            ViewBag.AllGenderDropdownData = await _dropdownhelper.GetGenderDropdownByKey(AliveProjectEnums.GenderDropdownKey);
            ViewBag.BloodGroup = await _dropdownhelper.GetBloodGroupDropdownByKey(AliveProjectEnums.BloodGroupDropdownKey);
            ViewBag.Genotype = await _dropdownhelper.GetGenotypeDropdownByKey(AliveProjectEnums.GenotypeDropdownKey);
            ViewBag.PatientType = await _dropdownhelper.GetPatientTypeDropdownByKey(AliveProjectEnums.PatientTypeDropdownKey);
            ViewBag.MaritalStatus = await _dropdownhelper.GetMaritalStatusDropdownByKey(AliveProjectEnums.MaritalStatusDropdownKey);
            ViewBag.MilitaryService = await _dropdownhelper.GetMilitaryServiceDropdownByKey(AliveProjectEnums.MilitaryServiceDropdownKey);
            ViewBag.SexuallyActive = await _dropdownhelper.GetSexuallyActiveDropdownByKey(AliveProjectEnums.SexuallyActiveDropdownKey);
            ViewBag.UnprotectedSex = await _dropdownhelper.GetUnprotectedSexDropdownByKey(AliveProjectEnums.UnprotectedSexDropdownKey);
            ViewBag.MSM = await _dropdownhelper.GetMSMDropdownByKey(AliveProjectEnums.MSMDropdownKey);
            ViewBag.SmokingHabit = await _dropdownhelper.GetSmokingHabitDropdownByKey(AliveProjectEnums.SmokingHabitDropdownKey);
            ViewBag.Addiction = await _dropdownhelper.GetAnyAddictionDropdownByKey(AliveProjectEnums.AnyAddictionDropdownKey);
            ViewBag.Country = _context.Country.Where(x => x.Id != 0).ToList();

            CheckupViewModel vm = new CheckupViewModel();
            vm.Checkups = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult CheckupCreate(string deserializedCheckupFormViewModel)
        {
            try
            {

                var CheckupDetails = JsonConvert.DeserializeObject<CheckupFormViewModel>(deserializedCheckupFormViewModel);
                if (CheckupDetails?.FirstName == string.Empty)
                {
                    return Json(new { isError = true, msg = "First Name can not be empty,enter your fist name" });
                };

                if (CheckupDetails.Email == string.Empty)
                {
                    return Json(new { isError = true, msg = "Email can't be empty, enter a correct Email" });
                }

                if (CheckupDetails.GenderId == 0)
                {
                    return Json(new { isError = true, msg = "Gender can not be empty" });
                };

                if (CheckupDetails.DateCreated == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "Please put today's date" });
                }
                if (CheckupDetails.DOB == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "Please put your date of birth " });
                };
                if (CheckupDetails.PatientTypeId == 0)
                {
                    return Json(new { isError = true, msg = "This can not be empty " });
                }
                if (CheckupDetails.Address == string.Empty)
                {
                    return Json(new { isError = true, msg = "Put your home address " });
                };
                if (CheckupDetails.LastName == string.Empty)
                {
                    return Json(new { isError = true, msg = "Put your surname " });
                }
                if (CheckupDetails.Phone == string.Empty)
                {
                    return Json(new { isError = true, msg = "put your phone number " });
                };
                
                if (CheckupDetails.Nok == string.Empty)
                {
                    return Json(new { isError = true, msg = " Put your next of kin" });
                };
                if (CheckupDetails.NextVisist == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "Next visit can not be empty " });
                }
                if (CheckupDetails.Country == string.Empty)
                {
                    return Json(new { isError = true, msg = "Country can not be empty " });
                };
               
                if (CheckupDetails.Occupation == string.Empty)
                {
                    return Json(new { isError = true, msg = "Occupation can not be empty " });
                };
                if (CheckupDetails.State == string.Empty)
                {
                    return Json(new { isError = true, msg = "State can not be empty " });
                }
                

                var existingCheckup = _context.Checkups.Where(s => s.FirstName == CheckupDetails.FirstName).FirstOrDefault();
                if (existingCheckup != null)
                {
                    ;
                }

                var newCheckup = new Checkup()
                {
                    FirstName = CheckupDetails.FirstName,
                    Email = CheckupDetails.Email,
                    GenderId = CheckupDetails.GenderId,
                    DateCreated = CheckupDetails.DateCreated,
                    DOB = CheckupDetails.DOB,
                    PatientTypeId = CheckupDetails.PatientTypeId,
                    Address = CheckupDetails.Address,
                    LastName = CheckupDetails.LastName,
                    Phone = CheckupDetails.Phone,
                    GenotypeId = CheckupDetails.GenotypeId,
                    Nok = CheckupDetails.Nok,
                    NextVisist = CheckupDetails.NextVisist,
                    Country = CheckupDetails.Country,
                     Occupation = CheckupDetails.Occupation,
                    State = CheckupDetails.State,
                    Deleted = false,
                };
            
                _context.Checkups.Add(newCheckup);
                _context.SaveChanges();
                ModelState.Clear();
                return Json(new { isError = false, msg = "Patient Checkup Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public JsonResult GetEditCheckup(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var Checkup = _db.Checkups.Where(x => x.Deleted == false).FirstOrDefault();
                    if (Checkup != null)
                    {
                        return Json(new { isError = false, result = Checkup });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public JsonResult PrintCheckup(Guid Id)
        //{
        //    try
        //    {
        //        if (Id != Guid.Empty)
        //        {
        //            var Checkup = _db.Checkups.Where(x => x.Deleted == false).FirstOrDefault();
        //            if (Checkup != null)
        //            {
        //                return Json(new { isError = false, result = Checkup });
        //            }
        //        }
        //        return Json(new { isError = true, msg = "No Result Found" });
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpPost]
        public JsonResult SaveEditCheckup(string deserializedCheckupViewModel)
        {
            try
            {
                if (deserializedCheckupViewModel != null)
                {
                    var CheckupViewModel = JsonConvert.DeserializeObject<CheckupFormViewModel>(deserializedCheckupViewModel);
                    if (CheckupViewModel != null)
                    {
                        var editCheckup = _userHelper.EditCheckup(CheckupViewModel);
                        _emailHelper.SendCheckupApprovalEmail(CheckupViewModel.LastName);

                        if (editCheckup)
                        {
                            return Json(new { isError = false, msg = "Patient Medical Recorde Updated successfully", url = "/Admin/Checkup" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update Checkup" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeleteCheckup(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var CheckupToBeDeleted = _userHelper.DeleteCheckup(Id);
                    if (CheckupToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Checkup Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Checkup" });
                }
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Post - Edit
        //Edit Labtest
        //[HttpGet]
        //public JsonResult GetEditCheckup(int? id)
        //{
        //    try
        //    {
        //        if (id > 0)
        //        {
        //            var labTest = _db.LabTests.Where(b => b.Id == id).FirstOrDefault();
        //            if (labTest != null)
        //            {
        //                return Json(new { isError = false, result = labTest });
        //            }
        //        }
        //        return Json(new { isError = true, msg = "No Result Found" });
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //[HttpPost]
        //public JsonResult SaveEditCheckup(string deserializedLabTestViewModel)
        //{
        //    try
        //    {
        //        if (deserializedLabTestViewModel != null)
        //        {
        //            var LabTestFormViewModel = JsonConvert.DeserializeObject<LabTestFormViewModel>(deserializedLabTestViewModel);
        //            if (LabTestFormViewModel != null)
        //            {
        //                var editLabTest = _userHelper.EditLabTest(LabTestFormViewModel);
        //                if (editLabTest)
        //                {
        //                    return Json(new { isError = false, msg = "LabTest Updated successfully", url = "/Admin/Labtest" });
        //                }
        //            }
        //            return Json(new { isError = true, msg = "Unable to update LabTest" });
        //        }
        //        return Json(new { isError = true, msg = "Error Occurred" });
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpGet]

        public IActionResult VitalSign()
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
                return RedirectToAction("vitalsign");
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
                return RedirectToAction("vitalsign");
            }
            return View(obj);
        }
        //get - Delete
        public IActionResult Delete(int? Id)
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
            var signs = _db.patientAppointments.Where(x => x.Deleted == false).ToList();
            AppointmentViewModel vm = new AppointmentViewModel();
            vm.patientAppointments = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult AppointmentCreate(string deserializedAppointmentViewModel)
        {
            try
            {
                var AppointmentDetails = JsonConvert.DeserializeObject<AppointmentFormViewModel>(deserializedAppointmentViewModel);
                if (AppointmentDetails.Name == string.Empty)
                {
                    return Json(new { isError = true, msg = "Please put your name" });
                };

                if (AppointmentDetails.Email == string.Empty)
                {
                    return Json(new { isError = true, msg = "Put a correct Email" });
                }

                if (AppointmentDetails.PhoneNumber == string.Empty)
                {
                    return Json(new { isError = true, msg = "Put your phone number" });
                };

                if (AppointmentDetails.DateCreated == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "This can not be empty" });
                };
                if (AppointmentDetails.AppointmentDate == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "Checking in successful" });
                };
                if (AppointmentDetails.Description == string.Empty)
                {
                    return Json(new { isError = true, msg = "This can not be empty " });
                }

                //var existingAppointment = _context.patientAppointments.Where(s => s.Name == AppointmentDetails.Name).FirstOrDefault();
                //if (existingAppointment != null)
                //{
                //    ;
                //}

                var newPatientAppointment = new PatientAppointment()
                {
                    Name = AppointmentDetails.Name,
                    Email = AppointmentDetails.Email,
                    PhoneNumber = AppointmentDetails.PhoneNumber,
                    AppointmentDate = AppointmentDetails.AppointmentDate,
                    DateCreated = AppointmentDetails.DateCreated,
                    Description = AppointmentDetails.Description,
                    Deleted = false,
                };
                _context.patientAppointments.Add(newPatientAppointment);
                _context.SaveChanges();
                _emailHelper.SendAppointmentConfirmationEmail(newPatientAppointment.AppointmentDate, newPatientAppointment.Name);
                ModelState.Clear();
                return Json(new { isError = false, msg = "Appointment Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Edit pATIENTAPPOINTMENT
        [HttpGet]
        public JsonResult GetEditAppointment(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var Appointment = _db.patientAppointments.Where(b => b.Id == id).FirstOrDefault();
                    if (Appointment != null)
                    {
                        return Json(new { isError = false, result = Appointment });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditAppointment(string deserializedAppointmentViewModel)
        {
            try
            {
                if (deserializedAppointmentViewModel != null)
                {
                    var AppointmentFormViewModel = JsonConvert.DeserializeObject<AppointmentFormViewModel>(deserializedAppointmentViewModel);
                    if (AppointmentFormViewModel != null)
                    {
                        var editAppointment = _userHelper.EditAppointment(AppointmentFormViewModel);
                        //_emailHelper.SendAppointmentConfirmationEmail(AppointmentFormViewModel.AppointmentDate, AppointmentFormViewModel.Name);

                        {
                            return Json(new { isError = false, msg = "Appointment Updated successfully", url = "/Admin/Labtest" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update Appointment" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeleteAppointment(int appointmentId)
        {
            try
            {
                if (appointmentId > 0)
                {
                    var AppointmentToBeDeleted = _userHelper.DeleteAppointment(appointmentId);
                    if (AppointmentToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Lab Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Appointment" });
                }
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        //get - Create
       
        //Post - Create

        public IActionResult LabTest()
        {
            var signs = _db.LabTests.Where(x => x.Deleted == false).ToList();
            LabTestViewModel vm = new LabTestViewModel();
            vm.LabTests = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult LabTest(string deserializedLabTestViewModel)
        {
            try
            {
                 var labTestDetails = JsonConvert.DeserializeObject<LabTestFormViewModel>(deserializedLabTestViewModel);
                if (labTestDetails.LabTestName == string.Empty)
                {
                    return Json(new { isError = true, msg = "Labtest name is needed" });
                };

                if (labTestDetails.TestCategory == string.Empty)
                {
                    return Json(new { isError = true, msg = "Test category is needed" });
                }

                if (labTestDetails.UnitPrice == double.MinValue)
                {
                    return Json(new { isError = true, msg = "The price is needed" });
                };

                if (labTestDetails.DateCreated == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "date is needed" });
                };
                if (labTestDetails.ReferenceRange == string.Empty)
                {
                    return Json(new { isError = true, msg = "This can not be empty " });
                }

                var existingLabTest = _context.LabTests.Where(s => s.LabTestName == labTestDetails.LabTestName).FirstOrDefault();
                if (existingLabTest != null)
                {
                    ;
                }

                var newLabTest = new LabTest()
                {
                    LabTestName = labTestDetails.LabTestName,
                    TestCategory = labTestDetails.TestCategory,
                    DateCreated = labTestDetails.DateCreated,
                    ReferenceRange = labTestDetails.ReferenceRange,
                    UnitPrice = labTestDetails.UnitPrice,
                    Deleted = false,
                };
                _context.LabTests.Add(newLabTest);
                _context.SaveChanges();
                ModelState.Clear();
                return Json(new { isError = false, msg = "Labtest Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit Labtest
        [HttpGet]
        public JsonResult GetEditLabTest(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var labTest = _db.LabTests.Where(b => b.Id == id).FirstOrDefault();
                    if (labTest != null)
                    {
                        return Json(new { isError = false, result = labTest });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditLabTest(string deserializedLabTestViewModel)
        {
            try
            {
                if (deserializedLabTestViewModel != null)
                {
                    var LabTestFormViewModel = JsonConvert.DeserializeObject<LabTestFormViewModel>(deserializedLabTestViewModel);
                    if (LabTestFormViewModel != null)
                    {
                        var editLabTest = _userHelper.EditLabTest(LabTestFormViewModel);
                            if (editLabTest)
                        {
                            return Json(new { isError = false, msg = "LabTest Updated successfully", url = "/Admin/Labtest" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update LabTest" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        	[HttpPost]
		public JsonResult DeleteLabTest(int id)
		{
			try
			{
				if (id > 0)
				{
						var LabToBeDeleted = _userHelper.DeleteLabTest(id);
						if (LabToBeDeleted)
						{
							return Json(new { isError = false, msg = "Lab Deleted successfully" });
						}
					return Json(new { isError = false, msg = "Unable to Delete Lab" });
				}
				return Json(new { isError = false, msg = "Error Occurred" });
			}
			catch (Exception)
			{

				throw;
			}
		}

        //Post - Edit

       
        public IActionResult Info(Guid id)
        {
            var signs = _db.NurseInfos.Where(x => x.Deleted == false).ToList();
            NurseViewModel vm = new NurseViewModel();
            vm.Nurseinfos = signs;
            return View(vm);
        }
        
        [HttpPost]
        public JsonResult InfoCreate(string deserializedNurseViewModel)
        {
            try
            {
                var NursetoDetails = JsonConvert.DeserializeObject<NurseFormViewModel>(deserializedNurseViewModel);
                if (NursetoDetails.Name == string.Empty)
                {
                    return Json(new { isError = true, msg = "Name is needed" });
                };

                if (NursetoDetails.Email == string.Empty)
                {
                    return Json(new { isError = true, msg = "Email is needed" });
                }

                if (NursetoDetails.PhoneNumber == string.Empty)
                {
                    return Json(new { isError = true, msg = "Phone number is needed" });
                };

                if (NursetoDetails.Gender == string.Empty)
                {
                    return Json(new { isError = true, msg = "Gender is needed" });
                };
                if (NursetoDetails.Country == string.Empty)
                {
                    return Json(new { isError = true, msg = "Country can not be empty " });
                }

                var existingNurse = _context.NurseInfos.Where(s => s.Name == NursetoDetails.Name).FirstOrDefault();
                if (existingNurse != null)
                {
                    ;
                }

                var newNurse = new NurseInfo()
                {
                    Name = NursetoDetails.Name,
                    Email = NursetoDetails.Email,
                    PhoneNumber = NursetoDetails.PhoneNumber,
                    Gender = NursetoDetails.Gender,
                    Country = NursetoDetails.Country,
                    Deleted = false,
                };
                _context.NurseInfos.Add(newNurse);
                _context.SaveChanges();
                ModelState.Clear();
                return Json(new { isError = false, msg = "Nurse Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit Labtest
        [HttpGet]
        public JsonResult GetEditNurse(Guid? id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var NurseInfo = _db.NurseInfos.Where(b => b.Id == id).FirstOrDefault();
                    if (NurseInfo != null)
                    {
                        return Json(new { isError = false, result = NurseInfo });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditNurse(string deserializedNurseViewModel)
        {
            try
            {
                if (deserializedNurseViewModel != null)
                {
                    var NurseFormViewModel = JsonConvert.DeserializeObject<NurseFormViewModel>(deserializedNurseViewModel);
                    if (NurseFormViewModel != null)
                    {
                        var editNurse = _userHelper.EditNurse(NurseFormViewModel);
                        if (editNurse)
                        {
                            return Json(new { isError = false, msg = "Nurse Updated successfully", url = "/Admin/Info" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update Nurse" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeleteNurse(Guid Id )
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var NurseToBeDeleted = _userHelper.DeleteNurse(Id);
                    if (NurseToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Nurse Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Nurse" });
                }
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }


        

        public IActionResult DocInfo(Guid id)
        {
            var signs = _db.DocInfos.Where(x => x.Deleted == false).ToList();
            DoctorViewModel vm = new DoctorViewModel();
            vm.DocInfos = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult DocInfoCreate(string deserializedDoctorViewModel)
        {
            try
            {
                var DoctorDetails = JsonConvert.DeserializeObject<DoctorFormViewModel>(deserializedDoctorViewModel);
                if (DoctorDetails.Name == string.Empty)
                {
                    return Json(new { isError = true, msg = "Name is needed" });
                };

                if (DoctorDetails.Email == string.Empty)
                {
                    return Json(new { isError = true, msg = "Email Is needed" });
                }

                if (DoctorDetails.PhoneNumber == string.Empty)
                {
                    return Json(new { isError = true, msg = "Phone number is needed" });
                };

                if (DoctorDetails.Category == string.Empty)
                {
                    return Json(new { isError = true, msg = "Doctor category is needed" });
                };
                if (DoctorDetails.Gender == string.Empty)
                {
                    return Json(new { isError = true, msg = "Gender can not be empty " });
                }
                if (DoctorDetails.Country == string.Empty)
                {
                    return Json(new { isError = true, msg = "Country can not be empty " });
                }

                var DoctorInfo = _context.DocInfos.Where(s => s.Name == DoctorDetails.Name).FirstOrDefault();
                if (DoctorInfo != null)
                {
                    ;
                }

                var newDoctor = new DocInfo()
                {
                    Name = DoctorDetails.Name,
                    Email = DoctorDetails.Email,
                    PhoneNumber = DoctorDetails.PhoneNumber,
                    Category = DoctorDetails.Category,
                    Gender = DoctorDetails.Gender,
                    Country = DoctorDetails.Country,
                    Deleted = false,
                };
                _context.DocInfos.Add(newDoctor);
                _context.SaveChanges();
                ModelState.Clear();
                return Json(new { isError = false, msg = "Doctor Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit Labtest
        [HttpGet]
        public JsonResult GetEditDoctor(Guid? id)
        {
            try
            {
                 var Doctor = _db.DocInfos.Where(x => x.Id != id).FirstOrDefault();
                    if (Doctor != null)
                    {
                        return Json(new { isError = false, result = Doctor });
                    }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditDoctor(string deserializedDoctorViewModel)
        {
            try
            {
                if (deserializedDoctorViewModel != null)
                {
                    var DoctorFormViewModel = JsonConvert.DeserializeObject<DoctorFormViewModel>(deserializedDoctorViewModel);
                    if (DoctorFormViewModel != null)
                    {
                        var editDoctor = _userHelper.EditDoctor(DoctorFormViewModel);
                        if (editDoctor)
                        {
                            return Json(new { isError = false, msg = "Doctor Info Updated successfully", url = "/Admin/Labtest" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update Doctor Info" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeleteDoctor(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var DocToBeDeleted = _userHelper.DeleteDoctorInfo(Id);
                    if (DocToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Doctor Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Doctror" });
                }
                
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult Medicine()
        {
            var signs = _db.Medicines.Where(x => x.Deleted == false).ToList();
            TreatmentViewModel vm = new TreatmentViewModel();
            vm.Medicines = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult MedicineCreate(string deserializedTreatmentViewModel)
        {
            try
            {
                var MedicineDetails = JsonConvert.DeserializeObject<TreatmentFormViewModel>(deserializedTreatmentViewModel);
                if (MedicineDetails.MedicineName == string.Empty)
                {
                    return Json(new { isError = true, msg = "Medicine name can not be empty" });
                };

                if (MedicineDetails.MedicineCategory == string.Empty)
                {
                    return Json(new { isError = true, msg = "Medicine Category is needed" });
                }

                if (MedicineDetails.Amount == double.MinValue)
                {
                    return Json(new { isError = true, msg = "Amount is needed" });
                };
               
                var existingMedicine = _context.Medicines.Where(s => s.MedicineName == MedicineDetails.MedicineName).FirstOrDefault();
                if (existingMedicine != null)
                {
                    ;
                }

                var newMedicine = new Medicine()
                {
                    MedicineName = MedicineDetails.MedicineName,
                    MedicineCategory = MedicineDetails.MedicineCategory,
                    Amount = MedicineDetails.Amount,
                    Deleted = false,
                };
                _context.Medicines.Add(newMedicine);
                _context.SaveChanges();
                ModelState.Clear();
                return Json(new { isError = false, msg = "Treatment Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit Labtest
        [HttpGet]
        public JsonResult GetEditMedicine(int? id)
        {
            try
            {
                if (id > 0)
                {
                    var medicine = _db.Medicines.Where(b => b.Id == id).FirstOrDefault();
                    if (medicine != null)
                    {
                        return Json(new { isError = false, result = medicine });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditMedicine(string deserializedTreatmentViewModel)
        {
            try
            {
                if (deserializedTreatmentViewModel != null)
                {
                    var TreatmentFormViewModel = JsonConvert.DeserializeObject<TreatmentFormViewModel>(deserializedTreatmentViewModel);
                    if (TreatmentFormViewModel != null)
                    {
                        var editMedicine = _userHelper.EditMedicine(TreatmentFormViewModel);
                        if (editMedicine)
                        {
                            return Json(new { isError = false, msg = "Treatment Updated successfully", url = "/Admin/Medicine" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update Treatment" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeletMedicine(int id)
        {
            try
            {
                if (id > 0)
                {
                    var MedToBeDeleted = _userHelper.DeleteMedicine(id);
                    if (MedToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Treatment Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Treatment" });
                }
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }



        public IActionResult Payment()
        {
            var signs = _db.Payments.Where(x => x.Deleted == false).ToList();
            PaymentViewModel vm = new PaymentViewModel();
            vm.Payments = signs;
            return View(vm);
        }
        [HttpPost]
        public JsonResult PaymentCreate(string deserializedPaymentViewModel)
        {
            try
            {
                var paymentDetails = JsonConvert.DeserializeObject<PaymentFormViewModel>(deserializedPaymentViewModel);
                if (paymentDetails.PatientName == string.Empty)
                {
                    return Json(new { isError = true, msg = "Patient name is needed" });
                };

                if (paymentDetails.PaidAmount == double.MinValue)
                {
                    return Json(new { isError = true, msg = "Amount paid can not be empty" });
                }

                if (paymentDetails.PaymentDate == DateTime.MinValue)
                {
                    return Json(new { isError = true, msg = "Put the payment date" });
                };

                if (paymentDetails.ModeOfPay == string.Empty)
                {
                    return Json(new { isError = true, msg = "Mode of payment is needed" });
                };
                if (paymentDetails.Picture == string.Empty)
                {
                    return Json(new { isError = false, msg = " Proof of payment is needed " });
                }
                if (paymentDetails.Email == string.Empty)
                {
                    return Json(new { isError = false, msg = " Proof of payment is needed " });
                }
                if (paymentDetails.ChargedAmount == double.MinValue)
                {
                    return Json(new { isError = false, msg = " Proof of payment is needed " });
                }

                //var existingPayment = _context.Payments.Where(s => s.PatientName == paymentDetails.PatientName).FirstOrDefault();
                //if (existingPayment != null)
                //{
                //    ; 
                //}

                var newPayment = new Payment()
                {
                    PatientName = paymentDetails.PatientName,
                    PaidAmount = paymentDetails.PaidAmount,
                    ModeOfPay = paymentDetails.ModeOfPay,
                    Picture = paymentDetails.Picture,
                    PaymentDate = paymentDetails.PaymentDate,
                    Email = paymentDetails.Email,
                    ChargedAmount = paymentDetails.ChargedAmount,
                    Deleted = false,
                };
                _context.Payments.Add(newPayment);
                _context.SaveChanges();
                _emailHelper.SendMedicalRecordEmail(newPayment.PatientName);

                ModelState.Clear();
                return Json(new { isError = false, msg = "Payment Created successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit Payment
        [HttpGet]
        public JsonResult GetEditPayment(Guid? id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var payment = _db.Payments.Where(b => b.Id == id).FirstOrDefault();
                    if (payment != null)
                    {
                        return Json(new { isError = false, result = payment });
                    }
                }
                return Json(new { isError = true, msg = "No Result Found" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public JsonResult SaveEditPayment(string deserializedPaymentViewModel)
        {
            try
            {
                if (deserializedPaymentViewModel != null)
                {
                    var PaymentFormViewModel = JsonConvert.DeserializeObject<PaymentFormViewModel>(deserializedPaymentViewModel);
                    if (PaymentFormViewModel != null)
                    {
                        var editPayment = _userHelper.EditPayment(PaymentFormViewModel);
                       
                        if (editPayment)
                        {
                            return Json(new { isError = false, msg = "Payment Updated successfully", url = "/Admin/Payment" });
                        }
                    }
                    return Json(new { isError = true, msg = "Unable to update payment" });
                }
                return Json(new { isError = true, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //post-delete
        [HttpPost]
        public JsonResult DeletePayment(Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    var PaymentToBeDeleted = _userHelper.DeletePayment(Id);
                    if (PaymentToBeDeleted)
                    {
                        return Json(new { isError = false, msg = "Payment Deleted successfully" });
                    }
                    return Json(new { isError = false, msg = "Unable to Delete Lab" });
                }
                return Json(new { isError = false, msg = "Error Occurred" });
            }
            catch (Exception)
            {

                throw;
            }
        }


        //uploadfile
        //public string UploadedFile(PaymentFormViewModel filesSender)
        //{

        //    string uniqueFileName = string.Empty;

        //    if (filesSender.ProofOfPaymentUrl != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Payment");
        //        string pathString = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Payment");
        //        if (!Directory.Exists(pathString))
        //        {
        //            Directory.CreateDirectory(pathString);
        //        }
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + filesSender.ProofOfPaymentUrl.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            filesSender.ProofOfPaymentUrl.CopyTo(fileStream);
        //        }
        //    }
        //    var generatedPictureFilePath = "/orderpaymentProof/" + uniqueFileName;
        //    return generatedPictureFilePath;
        //}




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

    