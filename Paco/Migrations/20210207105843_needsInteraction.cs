using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class needsInteraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InteractionReason",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsInteraction",
                table: "ManagedSystems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InteractionReason",
                table: "ManagedSystems");

            migrationBuilder.DropColumn(
                name: "NeedsInteraction",
                table: "ManagedSystems");
        }
    }
}
