using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class AddtoAlive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientType",
                table: "patientAppointments");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "patientAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "patientAppointments");

            migrationBuilder.AddColumn<string>(
                name: "PatientType",
                table: "patientAppointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
