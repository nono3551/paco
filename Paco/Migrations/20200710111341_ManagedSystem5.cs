using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class ManagedSystem5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "ManagedSystems");
        }
    }
}
