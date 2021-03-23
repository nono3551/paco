using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class removedpassowrd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ecaf7bb5-6c75-47d0-b550-498341aae899"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26"), new Guid("69dc6c0c-61be-425c-83d7-d1c44be54952") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("c9d14fd7-0dc4-4929-8006-5a479d3e9fd8"), new Guid("8f7533d4-5061-4d0e-96dd-11312de7167a"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("d478527d-2168-4cbf-b234-07e0e5069ceb"), new Guid("a933bfbb-de1c-46ef-af6a-887adb219dbc"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("31886026-b79e-4d94-b9ef-341178d39a26"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69dc6c0c-61be-425c-83d7-d1c44be54952"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("8f7533d4-5061-4d0e-96dd-11312de7167a"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("a933bfbb-de1c-46ef-af6a-887adb219dbc"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"), "1be4d1da-0d94-4103-805e-07d4f9ac890f", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("5e272134-e089-4ed0-b0dd-f21dab44d6da"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "PackageActions", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("a5dc3b80-9048-4b26-8b81-3f784887d217"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("b05261e8-afb1-4880-8247-4f521a395e1b"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("ce6ec657-1bbd-4577-98dd-8c8db9f81761"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"), new Guid("5e272134-e089-4ed0-b0dd-f21dab44d6da"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("618f0f36-bf6b-4ddf-9a5d-e84f3fffdfe8"), new Guid("a5dc3b80-9048-4b26-8b81-3f784887d217"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("84e43fb6-c389-48c1-9119-3acf5a64562e"), new Guid("b05261e8-afb1-4880-8247-4f521a395e1b"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"), null, null, (short)7, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ce6ec657-1bbd-4577-98dd-8c8db9f81761"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"), new Guid("5e272134-e089-4ed0-b0dd-f21dab44d6da") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("618f0f36-bf6b-4ddf-9a5d-e84f3fffdfe8"), new Guid("a5dc3b80-9048-4b26-8b81-3f784887d217"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("84e43fb6-c389-48c1-9119-3acf5a64562e"), new Guid("b05261e8-afb1-4880-8247-4f521a395e1b"), new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8345c1f-c8a8-4d19-9eb2-6cafe58726e4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e272134-e089-4ed0-b0dd-f21dab44d6da"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("a5dc3b80-9048-4b26-8b81-3f784887d217"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("b05261e8-afb1-4880-8247-4f521a395e1b"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "ManagedSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("31886026-b79e-4d94-b9ef-341178d39a26"), "a7ff268d-955f-4e05-b1ef-695ecbcdcc7d", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("69dc6c0c-61be-425c-83d7-d1c44be54952"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "PackageActions", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("8f7533d4-5061-4d0e-96dd-11312de7167a"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("a933bfbb-de1c-46ef-af6a-887adb219dbc"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("ecaf7bb5-6c75-47d0-b550-498341aae899"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26"), new Guid("69dc6c0c-61be-425c-83d7-d1c44be54952"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("c9d14fd7-0dc4-4929-8006-5a479d3e9fd8"), new Guid("8f7533d4-5061-4d0e-96dd-11312de7167a"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("d478527d-2168-4cbf-b234-07e0e5069ceb"), new Guid("a933bfbb-de1c-46ef-af6a-887adb219dbc"), new Guid("31886026-b79e-4d94-b9ef-341178d39a26"), null, null, (short)7, null });
        }
    }
}
