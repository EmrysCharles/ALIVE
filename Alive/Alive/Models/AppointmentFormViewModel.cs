﻿using System.ComponentModel.DataAnnotations;

namespace Alive.Models
{
    public class AppointmentFormViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string? Description { get; set; }
        public string? Approve { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Decline { get; set; }
        public string? PatientType { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}