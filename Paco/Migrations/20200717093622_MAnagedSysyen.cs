using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class MAnagedSysyen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Distribution",
                table: "ManagedSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distribution",
                table: "ManagedSystems");
        }
    }
}
