using Alive.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alive.data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet <MedicalHistory> MedicalHistories { get; set; } 
        public DbSet <ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }

        //public DbSet<Bed> Beds { get; set; }
        //public DbSet<BedAllotment> BedAllotments { get; set; }
        //public DbSet<BedCategory> BedCategories { get; set; }
        public DbSet<Checkup> Checkups { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DocInfo> DocInfos { get; set; }
        //public DbSet<ExpenseReport> ExpenseReports { get; set; }
        //public DbSet<Expenses> Expenses { get; set; }
        //public DbSet<ExpensesCategory> ExpensesCategories { get; set; }
        // public DbSet<Investigation> Investigations { get; set; }
        //public DbSet<Finance> Finances { get; set; }
        public DbSet<LabCategory> LabCategories { get; set; }
        public DbSet<LaboInfo> LaboInfos { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LoginDetails> loginDetails { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Dispensary> Dispensaries { get; set; }
        public DbSet<NurseInfo> NurseInfos { get; set; }
        public DbSet<PatientAppointment> patientAppointments { get; set; }
        public DbSet<PatientInfo> patientInfos { get; set; }
        public DbSet<Patienttest> patienttests { get; set; }
        public DbSet<PayCategory> PayCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentReport> PaymentReports { get; set; }
        public DbSet<PharmaList> PharmaLists { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
         public DbSet<PharmaInfo> PharmaInfos { get; set; }




        public DbSet<CommonDropdown> CommonDropdowns { get; set; }

    }
}
