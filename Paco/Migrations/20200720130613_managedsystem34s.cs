using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class managedsystem34s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateFetched",
                table: "ManagedSystems",
                newName: "UpdateFetchedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateFetchedAt",
                table: "ManagedSystems",
                newName: "LastUpdateFetched");
        }
    }
}
