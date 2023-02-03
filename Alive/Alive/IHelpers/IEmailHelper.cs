using Alive.Models;

namespace Alive.IHelpers
{
    public interface IEmailHelper
    {
        bool SendAppointmentConfirmationEmail(DateTime? AppointmentDate, string Name);
        bool SendMedicalRecordEmail(string PatientName);
        bool SendCheckupApprovalEmail(string LastName);
    }
}
