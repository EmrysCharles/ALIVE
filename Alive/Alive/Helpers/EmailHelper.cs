using Alive.data;
using Alive.IHelpers;
using Alive.Models;
using Alive.SmtpMailServices;
using Microsoft.EntityFrameworkCore;

namespace Alive.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public EmailHelper(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public bool SendAppointmentConfirmationEmail(DateTime? AppointmentDate, string Name)
        {
            if (Name != null)
            {
                var AppointmentDetail = _context.patientAppointments.Where(o => o.Name == Name).FirstOrDefault();
                string toEmail = AppointmentDetail.Email.ToString();
                string subject = "APPOINTMENT REQUEST SUBMITTED SUCESSFFULY";
                string message = "Dear " + AppointmentDetail.Name + "," + "Your Request For Appointment has  been submitted Successfully and being processed." + "<br>" + "Our doctor will be able to attend to you on" + AppointmentDate + "Thank you for choosing Alive </br>";  
                _emailService.SendEmail(toEmail, subject, message);
                return true;
            }
            return false;
        }
        public bool SendCheckupApprovalEmail( string LastName)
        {
            if (LastName != null)
            {
                var CheckupDetail = _context.Checkups.Where(o => o.LastName == LastName).FirstOrDefault();
                string toEmail = CheckupDetail.Email.ToString();
                string subject = "Payment Message";
                string message = "Dear " + CheckupDetail.LastName + "," + "Your Medical Record is Ready." + "<br>" +
                    "Thank you for always choosing Alive. " + "<br>" + "Your total charge is " + "" + 20000 + "" + "Naira. </br>" + "" +
                    "Please go ahead and make your payment to this account " + "<br>" + "<b>Account Name: Alive Inc</b>" + "<br>" +
                    "<b>Account Number: 09876543</b>" + "<br>" + "<b>Bank : Access Bank</b>" + "<br>" + "<br>" +
                    "Please endeavour to put send the proof of payment to our email stating the method you and the picture of your bank teller" +
                    ",POS slip or Alert. Thank you";
                _emailService.SendEmail(toEmail, subject, message);
                return true;
            }
            return false;
        }

        public bool SendMedicalRecordEmail(string email, string patientName)
        {
            if (patientName != null)
            {
                string toEmail = email.ToString();
                string subject = "APPOINTMENT REQUEST SUBMITTED SUCESSFFULY";
                string message = "Dear " + patientName + "," + "Your Payment has been Received." + "<br>" + "Your Medical Histyory can be sent on request </br>";
                _emailService.SendEmail(toEmail, subject, message);
                return true;
            }
            return false;
        }

        //public bool SendMedicalRecordRequest( DateTime? AppointmentDate, string LastName)
        //{
        //    if (LastName != null)
        //    {
        //        var AppointmentDetail = _context.Checkups.Where(o => o.LastName == LastName).FirstOrDefault();
        //        string toEmail = AppointmentDetail.Email.ToString();
        //        string subject = "APPOINTMENT REQUEST SUBMITTED SUCESSFFULY";
        //        string message = "Dear Mr " + AppointmentDetail.LastName + "," + "We received your request for the medical record to be sent to you. " + "<br>" + "It shall be duly sent to you within 24hrs. Thank you for choosing ALIVE </br>";
        //        _emailService.SendEmail(toEmail, subject, message);
        //        return true;
        //    }
        //    return false;
        //}

        public bool SendPaymentRecordRequest(DateTime? PaymentDate, string PatientName, double ChargedAmount)
        {
            if (PatientName != null)
            {
                var PaymentDetail = _context.Payments.Where(o => o.PatientName == PatientName).FirstOrDefault();
                string toEmail = PaymentDetail.Email.ToString();
                string subject = "Please Make Your Payment";
                string message = "Dear Mr " + PaymentDetail.PatientName + "," + "Thank you for always choosing Alive. " + "<br>" + "Your total charge is " +""+ ChargedAmount + ""+ "Naira. </br>" + "" + 
                    "Please go ahead and make your payment to this account " + "<br>" + "<b>Account Name: Alive Inc</b>" + "<br>" + "<b>Account Number: 09876543</b>" + "<br>" + "<b>Bank : Access Bank</b>"+"<br>" + "<br>" + "Please endeavour to put send the proof of payment to our email stating the method you and the picture of your bank teller,POS slip or Alert. Thank you";
                _emailService.SendEmail(toEmail, subject, message);
                return true;
            }
            return false;
        }
        //public bool SendRegistrationConfirmationEmail(ApplicationUser userRegisteringDetail)
        //{
        //    //if (customerId > 0)
        //    //{
        //    string toEmail = userRegisteringDetail.Email;
        //    string subject = "REGISTRATION SUCCESSFFUL";
        //    string message = "Dear" + ", " + userRegisteringDetail.Name + ", " + "Your Account has been succefully created, Click the link below to login Create Create your first Order." + "<br>" + "User Login: <a href=\"https://localhost:44350/Account/Login\">Click Here to LOGIN</a>" + "<br>";
        //    _emailService.SendEmail(toEmail, subject, message);
        //    return true;
        //    //}
        //    //return false;
        //}

        //public bool SendMedicalRecordRequestToCustomer(ApplicationUser customerDetail, int totalAmount, int orderNo)
        //{
        //    //if (customerId > 0)
        //    //{
        //    string toEmail = customerDetail.Email;
        //    string subject = "YOUR INVOICE FOR Order Number: " + orderNo + "IS RAEDY";
        //    string message = "Dear " + customerDetail.Name + ", " + "Your order with invoice number " + orderNo + "is ready for procurement with a total Amount of " + totalAmount + "." + "Kindly payment click the link provided below to proceed with Your order payment" + "<br>" + "User Login: <a href=\"https://localhost:44350/Customers/PayForQuotation?orderNumber=" + orderNo + "\">Click Here to Make PAYMENT</a>" + "<br>";
        //    _emailService.SendEmail(toEmail, subject, message);
        //    return true;
        //    //}
        //    //return false;
        //}

    }
}

