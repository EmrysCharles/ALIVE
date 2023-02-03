using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class Addtodalive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Payments",
                newName: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Payments",
                newName: "picture");
        }
    }
}
