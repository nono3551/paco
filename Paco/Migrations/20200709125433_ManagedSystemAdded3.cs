using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class ManagedSystemAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Systems",
                table: "Systems");

            migrationBuilder.RenameTable(
                name: "Systems",
                newName: "ManagedSystems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagedSystems",
                table: "ManagedSystems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagedSystems",
                table: "ManagedSystems");

            migrationBuilder.RenameTable(
                name: "ManagedSystems",
                newName: "Systems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Systems",
                table: "Systems",
                column: "Id");
        }
    }
}
