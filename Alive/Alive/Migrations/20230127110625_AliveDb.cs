using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class AliveDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinInfos");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "WhenToTake",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Edit",
                table: "NurseInfos");

            migrationBuilder.RenameColumn(
                name: "Qualifications",
                table: "NurseInfos",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Medicines",
                newName: "Amount");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Treatments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "Treatments",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "patientAppointments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "NurseInfos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DocInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bool",
                table: "Checkups",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "NurseInfos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DocInfos");

            migrationBuilder.DropColumn(
                name: "Bool",
                table: "Checkups");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "NurseInfos",
                newName: "Qualifications");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Medicines",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhenToTake",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "patientAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edit",
                table: "NurseInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinInfos", x => x.Id);
                });
        }
    }
}
