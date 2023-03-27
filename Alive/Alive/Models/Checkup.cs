using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alive.Models
{
    public class Checkup 
    {
        [Key]
        public Guid Id { get; set; }
        public string? VisitId { get; set; }
        public string? Nok { get; set; }


        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [ForeignKey("PatientTypeId")]
       
        public int? PatientTypeId { get; set; }
        public virtual CommonDropdown? PatientType { get; set; }

        public DateTime? NextVisist { get; set; }
        public string? Advice { get; set; }
        public string? Comment { get; set; }
        
        public string? Diagnoses { get; set; }
        public string? Selfmedication { get; set; }
        public string? Address { get; set; }
        
        public string? DurationOfIllness { get; set; }
        public string? DoseOfSelfmedication { get; set; }
        public string? DrugIntakeDuration { get; set; }
        [ForeignKey("MilitaryServiceId")]

        public int? MilitaryServiceId { get; set; }
        public virtual CommonDropdown? MilitaryService { get; set; }
        [ForeignKey("SmokingHabitId")]
        public int? SmokingHabitId { get; set; }
        public virtual CommonDropdown? SmokingHabit { get; set; }
         public string? Allergy { get; set; }
        [ForeignKey("AnyAddictionId")]
        public int? AnyAddictionId { get; set; }
         public virtual CommonDropdown? AnyAddiction { get; set; }
        [ForeignKey("SexuallyActive")]
        public int? SexuallyActiveId { get; set; }
        public virtual CommonDropdown? SexuallyActive { get; set; }
        [ForeignKey("UnprotectedSexId")]
        public int? UnprotectedSexId { get; set; }
        public virtual CommonDropdown? UnprotectedSex { get; set; }

        public string? IfYesWhen { get; set; }
        [ForeignKey("MSMId")]
        public int? MSMId { get; set; }
        public virtual CommonDropdown? MSM { get; set; }


        public string? Disease1 { get; set; }
         
        public string? NurseName { get; set; }
        public string? BodyTemperature { get; set; }

        public int? Height { get; set; }

        public int? BodyWeight { get; set; }

        public string? PulseRate { get; set; }

        public string? BloodPressure { get; set; }

        public string? PainRate { get; set; }

        public string? LevelOfConsciousness { get; set; }
        public string? Skin { get; set; }
        [ForeignKey("GenotypeId")]
        public int? GenotypeId { get; set; }
        public virtual CommonDropdown? Genotype { get; set; }

         public string? Medicine { get; set; }
        public string? Investigation { get; set; }
        
        public string? Occupation { get; set; }

        public DateTime? DateCreated { get; set; }
        public string? Email { get; set; }
        public DateTime? DOB { get; set; }
        [ForeignKey("MaritalStatusId")]
        public int? MaritalStatusId { get; set; }
        public virtual CommonDropdown? MaritalStatus { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        [ForeignKey("BloodGroupId")]
        public int? BloodGroupId { get; set; }
        public virtual CommonDropdown? BloodGroup { get; set; }
        public string? Phone { get; set; }
        [ForeignKey("GenderId")]
        public int? GenderId { get; set; }
        public virtual CommonDropdown? Gender { get; set; }
        public double? Amount { get; set; }
        public bool Deleted { get; set; }
        public double? Consultation { get; set; }
        public double? Laboratory { get; set; }
        public double? Pharmacy { get; set; }
        public double? Surgery { get; set; }
        public double? Medicne { get; set; }
        public double? Bed { get; set; }
        public double? Others { get; set; }
        public double? Total { get; set; }
        public string? Complaint { get; set; }
        public string? Result { get; set; }
        public double? TreatAmount { get; set; }
        public string? Treatment { get; set; }
        public string? HowToTake { get; set; }
        public string? BeforeMeal { get; set; }
        

    }
}
