using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class managedsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemInformation",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemInformation",
                table: "ManagedSystems");
        }
    }
}
