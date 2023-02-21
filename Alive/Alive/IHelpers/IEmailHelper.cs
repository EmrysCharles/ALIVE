using Alive.Models;

namespace Alive.IHelpers
{
    public interface IEmailHelper
    {
        bool SendAppointmentConfirmationEmail(DateTime? AppointmentDate, string Name);
        bool SendMedicalRecordEmail(string PatientName, string Email);
        bool SendCheckupApprovalEmail(string LastName);
    }
}
