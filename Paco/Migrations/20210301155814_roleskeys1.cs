using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class roleskeys1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"), new Guid("f4e951b6-40aa-46dc-8fde-c16cc0245d82") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("4775c99a-65bc-4882-ae3a-7883872ba56d"), new Guid("75ad3d00-d5d7-4700-b323-c20e73f95df9"), new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("517edb56-605f-4f1f-b9bd-8958f62c437f"), new Guid("eb33e284-808c-41f8-bf78-255ca9911c11"), new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f4e951b6-40aa-46dc-8fde-c16cc0245d82"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("75ad3d00-d5d7-4700-b323-c20e73f95df9"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("eb33e284-808c-41f8-bf78-255ca9911c11"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "IsDeleted", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"), "520c04ea-186a-4d29-b399-7ef49a40ac8a", null, false, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("b90857ba-3955-4354-8689-9c633f793fef"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, "asd@ads.asd", true, false, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@ads.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "IsDeleted", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("510bc21c-874d-4141-8315-2c3817890cf6"), null, null, 0, "none.test.test", null, false, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("75ebeab7-e43d-41cb-8a25-0ba9bcca1f94"), null, null, 0, "multiple.test.test", null, false, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "IsDeleted", "RoleId1", "UpdatedAt", "UserId1" },
                values: new object[] { new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"), new Guid("b90857ba-3955-4354-8689-9c633f793fef"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "IsDeleted", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("75fa0c13-5f3e-4cc0-844c-1cdd834abb4a"), new Guid("510bc21c-874d-4141-8315-2c3817890cf6"), new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"), null, false, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "IsDeleted", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("c73f7e7c-275f-4245-bd52-11556d9dba21"), new Guid("75ebeab7-e43d-41cb-8a25-0ba9bcca1f94"), new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"), null, false, (short)7, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"), new Guid("b90857ba-3955-4354-8689-9c633f793fef") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("75fa0c13-5f3e-4cc0-844c-1cdd834abb4a"), new Guid("510bc21c-874d-4141-8315-2c3817890cf6"), new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("c73f7e7c-275f-4245-bd52-11556d9dba21"), new Guid("75ebeab7-e43d-41cb-8a25-0ba9bcca1f94"), new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c950c785-8c95-4d9d-bccb-57ae7e579172"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b90857ba-3955-4354-8689-9c633f793fef"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("510bc21c-874d-4141-8315-2c3817890cf6"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("75ebeab7-e43d-41cb-8a25-0ba9bcca1f94"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "IsDeleted", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"), "00fdc2de-9ec3-429c-b921-40b76d2d93b2", null, false, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("f4e951b6-40aa-46dc-8fde-c16cc0245d82"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, "asd@ads.asd", true, false, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@ads.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "IsDeleted", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("eb33e284-808c-41f8-bf78-255ca9911c11"), null, null, 0, "none.test.test", null, false, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("75ad3d00-d5d7-4700-b323-c20e73f95df9"), null, null, 0, "multiple.test.test", null, false, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "IsDeleted", "RoleId1", "UpdatedAt", "UserId1" },
                values: new object[] { new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"), new Guid("f4e951b6-40aa-46dc-8fde-c16cc0245d82"), null, false, null, null, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "IsDeleted", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("517edb56-605f-4f1f-b9bd-8958f62c437f"), new Guid("eb33e284-808c-41f8-bf78-255ca9911c11"), new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"), null, false, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "IsDeleted", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("4775c99a-65bc-4882-ae3a-7883872ba56d"), new Guid("75ad3d00-d5d7-4700-b323-c20e73f95df9"), new Guid("9f6cc867-1e13-4327-95ba-5001ef3ff214"), null, false, (short)7, null });
        }
    }
}
