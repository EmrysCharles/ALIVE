using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alive.Migrations
{
    public partial class alivetb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bool",
                table: "Checkups",
                newName: "Deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Payments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nok",
                table: "Checkups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Nok",
                table: "Checkups");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Checkups",
                newName: "Bool");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
