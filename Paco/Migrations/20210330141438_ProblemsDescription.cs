using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class ProblemsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cd7d0b16-774d-4ae8-87e5-750bd2b3f564"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"), new Guid("aeef0520-6b05-4795-86b9-22bdc10a5e00") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("2b6e9c6e-d56b-4914-80f3-8a7415e0db62"), new Guid("63b6e77c-8fb7-477f-9fb1-8d6f1f78d1c4"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("fa9fe6f4-b9bc-4962-8297-d07a46c9870c"), new Guid("1b88e53e-6ecb-4e3f-a795-3b973fd8c44b"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("aeef0520-6b05-4795-86b9-22bdc10a5e00"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("1b88e53e-6ecb-4e3f-a795-3b973fd8c44b"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("63b6e77c-8fb7-477f-9fb1-8d6f1f78d1c4"));

            migrationBuilder.RenameColumn(
                name: "NeedsInteraction",
                table: "ManagedSystems",
                newName: "HasProblems");

            migrationBuilder.RenameColumn(
                name: "InteractionReason",
                table: "ManagedSystems",
                newName: "ProblemDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"), "4f28740e-a119-4fec-8e4f-25996142a8a0", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("cb808920-186e-4dc2-a9ec-cc8fb89b4a08"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "HasProblems", "Hostname", "LastAccessed", "Name", "PackageActions", "ProblemDescription", "SshLogin", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("ff417265-ad1f-4dbc-9f92-8390ccacecea"), null, null, 0, false, "none.test.test", null, "PermNone", 0, null, null, null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("85df6666-c7fd-495e-8546-23f34870e26e"), null, null, 0, false, "multiple.test.test", null, "PermMultiple", 0, null, null, null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("165f2110-47f8-449b-b09e-2113f3610d7d"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"), new Guid("cb808920-186e-4dc2-a9ec-cc8fb89b4a08"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("d22f5066-7bce-40e2-a4b8-28eb85df48d3"), new Guid("ff417265-ad1f-4dbc-9f92-8390ccacecea"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("eb86a395-e727-4fef-a852-10b80fc20132"), new Guid("85df6666-c7fd-495e-8546-23f34870e26e"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"), null, null, (short)7, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("165f2110-47f8-449b-b09e-2113f3610d7d"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"), new Guid("cb808920-186e-4dc2-a9ec-cc8fb89b4a08") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("d22f5066-7bce-40e2-a4b8-28eb85df48d3"), new Guid("ff417265-ad1f-4dbc-9f92-8390ccacecea"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("eb86a395-e727-4fef-a852-10b80fc20132"), new Guid("85df6666-c7fd-495e-8546-23f34870e26e"), new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f72ccc8-f495-492c-bc6d-20de8f552eb6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb808920-186e-4dc2-a9ec-cc8fb89b4a08"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("85df6666-c7fd-495e-8546-23f34870e26e"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("ff417265-ad1f-4dbc-9f92-8390ccacecea"));

            migrationBuilder.RenameColumn(
                name: "ProblemDescription",
                table: "ManagedSystems",
                newName: "InteractionReason");

            migrationBuilder.RenameColumn(
                name: "HasProblems",
                table: "ManagedSystems",
                newName: "NeedsInteraction");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"), "3b88d077-c1a7-4d0f-a59b-8ed7281048c3", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("aeef0520-6b05-4795-86b9-22bdc10a5e00"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Name", "NeedsInteraction", "PackageActions", "SshLogin", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("63b6e77c-8fb7-477f-9fb1-8d6f1f78d1c4"), null, null, 0, "none.test.test", null, null, "PermNone", false, 0, null, null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("1b88e53e-6ecb-4e3f-a795-3b973fd8c44b"), null, null, 0, "multiple.test.test", null, null, "PermMultiple", false, 0, null, null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("cd7d0b16-774d-4ae8-87e5-750bd2b3f564"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"), new Guid("aeef0520-6b05-4795-86b9-22bdc10a5e00"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("2b6e9c6e-d56b-4914-80f3-8a7415e0db62"), new Guid("63b6e77c-8fb7-477f-9fb1-8d6f1f78d1c4"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("fa9fe6f4-b9bc-4962-8297-d07a46c9870c"), new Guid("1b88e53e-6ecb-4e3f-a795-3b973fd8c44b"), new Guid("be771a43-05f6-4efd-a2bf-f37aa401a621"), null, null, (short)7, null });
        }
    }
}
