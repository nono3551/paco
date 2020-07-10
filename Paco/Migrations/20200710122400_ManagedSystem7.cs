using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class ManagedSystem7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SshFingerprint",
                table: "ManagedSystems",
                newName: "SystemFingerprint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemFingerprint",
                table: "ManagedSystems",
                newName: "SshFingerprint");
        }
    }
}
