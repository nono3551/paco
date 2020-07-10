using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class ManagedSystem4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ManagedSystems");
        }
    }
}
