using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class addtodata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonDropdowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropdownKey = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonDropdowns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispensaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispensaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "LabCategories",
                columns: table => new
                {
                    sn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabCategories", x => x.sn);
                });

            migrationBuilder.CreateTable(
                name: "LaboInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratorianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    ReferenceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loginDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    unit = table.Column<int>(type: "int", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NurseInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Decline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientAppointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloodgroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genotype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewCheckup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patienttests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patienttests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amountpaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<int>(type: "int", nullable: true),
                    Tax = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<int>(type: "int", nullable: true),
                    GrandTotal = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    PatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsultCharge = table.Column<double>(type: "float", nullable: true),
                    MedCharge = table.Column<double>(type: "float", nullable: true),
                    Proof = table.Column<byte>(type: "tinyint", nullable: true),
                    ModeOfPay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedCharge = table.Column<double>(type: "float", nullable: true),
                    PaidAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueAmount = table.Column<double>(type: "float", nullable: true),
                    ChargedAmount = table.Column<double>(type: "float", nullable: true),
                    AccomodationCharge = table.Column<double>(type: "float", nullable: true),
                    LabCharge = table.Column<double>(type: "float", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Edit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmaCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Medicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOoFDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VitalSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulseRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelOfConsciousness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PupillaryAssesment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_CommonDropdowns_GenderId",
                        column: x => x.GenderId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Checkups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientTypeId = table.Column<int>(type: "int", nullable: true),
                    NextVisist = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Advice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnoses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selfmedication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationOfIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoseOfSelfmedication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugIntakeDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MilitaryServiceId = table.Column<int>(type: "int", nullable: true),
                    SmokingHabitId = table.Column<int>(type: "int", nullable: true),
                    Allergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyAddictionId = table.Column<int>(type: "int", nullable: true),
                    SexuallyActiveId = table.Column<int>(type: "int", nullable: true),
                    UnprotectedSexId = table.Column<int>(type: "int", nullable: true),
                    IfYesWhen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MSMId = table.Column<int>(type: "int", nullable: true),
                    Disease1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    BodyWeight = table.Column<int>(type: "int", nullable: true),
                    PulseRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PainRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelOfConsciousness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenotypeId = table.Column<int>(type: "int", nullable: true),
                    Medicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Investigation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroupId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Consultation = table.Column<double>(type: "float", nullable: true),
                    Laboratory = table.Column<double>(type: "float", nullable: true),
                    Pharmacy = table.Column<double>(type: "float", nullable: true),
                    Surgery = table.Column<double>(type: "float", nullable: true),
                    Medicne = table.Column<double>(type: "float", nullable: true),
                    Bed = table.Column<double>(type: "float", nullable: true),
                    Others = table.Column<double>(type: "float", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Complaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatAmount = table.Column<double>(type: "float", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowToTake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeMeal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_AnyAddictionId",
                        column: x => x.AnyAddictionId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_GenderId",
                        column: x => x.GenderId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_GenotypeId",
                        column: x => x.GenotypeId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_MilitaryServiceId",
                        column: x => x.MilitaryServiceId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_MSMId",
                        column: x => x.MSMId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_SexuallyActiveId",
                        column: x => x.SexuallyActiveId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_SmokingHabitId",
                        column: x => x.SmokingHabitId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checkups_CommonDropdowns_UnprotectedSexId",
                        column: x => x.UnprotectedSexId,
                        principalTable: "CommonDropdowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SexuallyActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexPreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastDose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalQuery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnoses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_AnyAddictionId",
                table: "Checkups",
                column: "AnyAddictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_BloodGroupId",
                table: "Checkups",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_GenderId",
                table: "Checkups",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_GenotypeId",
                table: "Checkups",
                column: "GenotypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_MaritalStatusId",
                table: "Checkups",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_MilitaryServiceId",
                table: "Checkups",
                column: "MilitaryServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_MSMId",
                table: "Checkups",
                column: "MSMId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_PatientTypeId",
                table: "Checkups",
                column: "PatientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_SexuallyActiveId",
                table: "Checkups",
                column: "SexuallyActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_SmokingHabitId",
                table: "Checkups",
                column: "SmokingHabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_UnprotectedSexId",
                table: "Checkups",
                column: "UnprotectedSexId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_UserId",
                table: "MedicalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Checkups");

            migrationBuilder.DropTable(
                name: "Dispensaries");

            migrationBuilder.DropTable(
                name: "DocInfos");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "LabCategories");

            migrationBuilder.DropTable(
                name: "LaboInfos");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "loginDetails");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "NurseInfos");

            migrationBuilder.DropTable(
                name: "patientAppointments");

            migrationBuilder.DropTable(
                name: "patientInfos");

            migrationBuilder.DropTable(
                name: "patienttests");

            migrationBuilder.DropTable(
                name: "PayCategories");

            migrationBuilder.DropTable(
                name: "PaymentReports");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PharmaInfos");

            migrationBuilder.DropTable(
                name: "PharmaLists");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "VitalSigns");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "CommonDropdowns");
        }
    }
}
