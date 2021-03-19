using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b9eb38af-2030-4603-8d4a-e7c824d2f3f4"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"), new Guid("203cd5cf-9ef0-4cf5-8a4f-3d3660f691ca") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("22bd766d-94fd-4606-91e8-4415ea5a8210"), new Guid("2363cc84-9d83-4826-911d-6ef5cf1847eb"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("30937cf4-04e5-496a-b759-e1bdae4614d0"), new Guid("255e0506-c371-4dea-a236-b3592f5b8d8e"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("203cd5cf-9ef0-4cf5-8a4f-3d3660f691ca"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("2363cc84-9d83-4826-911d-6ef5cf1847eb"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("255e0506-c371-4dea-a236-b3592f5b8d8e"));

            migrationBuilder.CreateTable(
                name: "SystemUpdate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUpdate_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"), "e22a08ff-5102-4bf4-8acc-c55b2075df08", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("5ee5d73e-adcb-4360-a5c9-fcb158f0ab3d"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("c39bc67d-39db-4bbd-91a6-8248260b53c6"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("6b9cbe27-3397-49e6-841f-6fe3fabf754d"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("9df776f0-5284-4675-8637-2ba1c81954a1"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"), new Guid("5ee5d73e-adcb-4360-a5c9-fcb158f0ab3d"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("8eab6cca-1d4a-44a5-9344-e14c570e9936"), new Guid("c39bc67d-39db-4bbd-91a6-8248260b53c6"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("f984d574-ec03-4273-9c90-bdab8657c1d7"), new Guid("6b9cbe27-3397-49e6-841f-6fe3fabf754d"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"), null, null, (short)7, null });

            migrationBuilder.CreateIndex(
                name: "IX_SystemUpdate_ManagedSystemId",
                table: "SystemUpdate",
                column: "ManagedSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUpdate");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9df776f0-5284-4675-8637-2ba1c81954a1"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"), new Guid("5ee5d73e-adcb-4360-a5c9-fcb158f0ab3d") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("8eab6cca-1d4a-44a5-9344-e14c570e9936"), new Guid("c39bc67d-39db-4bbd-91a6-8248260b53c6"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("f984d574-ec03-4273-9c90-bdab8657c1d7"), new Guid("6b9cbe27-3397-49e6-841f-6fe3fabf754d"), new Guid("02dde930-f86f-4c6e-a57a-61a9de646983") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("02dde930-f86f-4c6e-a57a-61a9de646983"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ee5d73e-adcb-4360-a5c9-fcb158f0ab3d"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("6b9cbe27-3397-49e6-841f-6fe3fabf754d"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("c39bc67d-39db-4bbd-91a6-8248260b53c6"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"), "5797b5cc-897b-4e4c-b1ff-e95e74c516b4", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("203cd5cf-9ef0-4cf5-8a4f-3d3660f691ca"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("2363cc84-9d83-4826-911d-6ef5cf1847eb"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("255e0506-c371-4dea-a236-b3592f5b8d8e"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("b9eb38af-2030-4603-8d4a-e7c824d2f3f4"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"), new Guid("203cd5cf-9ef0-4cf5-8a4f-3d3660f691ca"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("22bd766d-94fd-4606-91e8-4415ea5a8210"), new Guid("2363cc84-9d83-4826-911d-6ef5cf1847eb"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("30937cf4-04e5-496a-b759-e1bdae4614d0"), new Guid("255e0506-c371-4dea-a236-b3592f5b8d8e"), new Guid("0fa5ff48-75b5-4fde-ab6c-54ba807f0eea"), null, null, (short)7, null });
        }
    }
}
