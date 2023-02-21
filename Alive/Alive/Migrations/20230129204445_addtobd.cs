using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class addtobd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Bed",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeforeMeal",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complaint",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Consultation",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowToTake",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Laboratory",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Medicne",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Others",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Pharmacy",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Surgery",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TreatAmount",
                table: "Checkups",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Treatment",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bed",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "BeforeMeal",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Complaint",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Consultation",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "HowToTake",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Laboratory",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Medicne",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Pharmacy",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Surgery",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "TreatAmount",
                table: "Checkups");

            migrationBuilder.DropColumn(
                name: "Treatment",
                table: "Checkups");
        }
    }
}
