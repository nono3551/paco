using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("61800742-e011-4274-8f82-249a3cf7db34"), new Guid("5906f4b6-e160-4c50-888e-f9a450e3c8b5"), new Guid("dbb44967-8708-4aac-9d97-f27efcb3ff01") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5906f4b6-e160-4c50-888e-f9a450e3c8b5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dbb44967-8708-4aac-9d97-f27efcb3ff01"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), "9d110ccd-7663-4ec1-816f-57c79caf103f", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("1981aade-0a36-4e24-9ff5-ec4b296804a9"), new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1981aade-0a36-4e24-9ff5-ec4b296804a9"), new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("5906f4b6-e160-4c50-888e-f9a450e3c8b5"), "df55248f-ee97-4d42-9f49-f69138d3443d", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("dbb44967-8708-4aac-9d97-f27efcb3ff01"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("61800742-e011-4274-8f82-249a3cf7db34"), new Guid("5906f4b6-e160-4c50-888e-f9a450e3c8b5"), new Guid("dbb44967-8708-4aac-9d97-f27efcb3ff01"), null, null, null });
        }
    }
}
