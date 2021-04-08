using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3d94ddb2-d810-48d5-b982-a62b54e5ec6e"), new Guid("8fc9b9c9-b82f-4ebc-baaa-f748a33a68fb"), new Guid("5ef9019f-0773-4176-86df-db1cd8b993c1") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fc9b9c9-b82f-4ebc-baaa-f748a33a68fb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ef9019f-0773-4176-86df-db1cd8b993c1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("9029f7c6-f6d0-4265-842b-30a85b250f56"), "397e9bbe-0340-4306-afb7-d6f88527e87b", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("182ffe8e-efd0-4e32-8bbc-9f0581b8e3ff"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("f3e3f342-8211-4131-8ca4-99ccaefde5fa"), new Guid("9029f7c6-f6d0-4265-842b-30a85b250f56"), new Guid("182ffe8e-efd0-4e32-8bbc-9f0581b8e3ff"), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f3e3f342-8211-4131-8ca4-99ccaefde5fa"), new Guid("9029f7c6-f6d0-4265-842b-30a85b250f56"), new Guid("182ffe8e-efd0-4e32-8bbc-9f0581b8e3ff") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9029f7c6-f6d0-4265-842b-30a85b250f56"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("182ffe8e-efd0-4e32-8bbc-9f0581b8e3ff"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("8fc9b9c9-b82f-4ebc-baaa-f748a33a68fb"), "444f297b-8f7f-4b25-90d4-7b4f85846299", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("5ef9019f-0773-4176-86df-db1cd8b993c1"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("3d94ddb2-d810-48d5-b982-a62b54e5ec6e"), new Guid("8fc9b9c9-b82f-4ebc-baaa-f748a33a68fb"), new Guid("5ef9019f-0773-4176-86df-db1cd8b993c1"), null, null, null });
        }
    }
}
