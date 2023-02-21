using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class Addtonow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "LabTests");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LabTests",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LabTests");

            migrationBuilder.AddColumn<string>(
                name: "Delete",
                table: "LabTests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
