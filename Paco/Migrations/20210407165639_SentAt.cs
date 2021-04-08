using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class SentAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6da139c2-f794-41f3-9176-7dcf7c40f515"), new Guid("85e31306-d9e2-4e2c-baec-d07e7a0685bf"), new Guid("30ef7f2a-e239-40ae-9b06-b1dab04bf461") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85e31306-d9e2-4e2c-baec-d07e7a0685bf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30ef7f2a-e239-40ae-9b06-b1dab04bf461"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("85e31306-d9e2-4e2c-baec-d07e7a0685bf"), "043faf98-3ecb-4a1a-bb39-b6db80df878c", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("30ef7f2a-e239-40ae-9b06-b1dab04bf461"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("6da139c2-f794-41f3-9176-7dcf7c40f515"), new Guid("85e31306-d9e2-4e2c-baec-d07e7a0685bf"), new Guid("30ef7f2a-e239-40ae-9b06-b1dab04bf461"), null, null, null });
        }
    }
}
