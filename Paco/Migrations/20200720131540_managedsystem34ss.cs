using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class managedsystem34ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateFetchedAt",
                table: "ManagedSystems",
                newName: "UpdatesFetchedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatesFetchedAt",
                table: "ManagedSystems",
                newName: "UpdateFetchedAt");
        }
    }
}
