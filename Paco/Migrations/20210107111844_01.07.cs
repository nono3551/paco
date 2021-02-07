using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class _0107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogRecord",
                table: "LogRecord");

            migrationBuilder.RenameTable(
                name: "LogRecord",
                newName: "LogRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogRecords",
                table: "LogRecords",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogRecords",
                table: "LogRecords");

            migrationBuilder.RenameTable(
                name: "LogRecords",
                newName: "LogRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogRecord",
                table: "LogRecord",
                column: "Id");
        }
    }
}
