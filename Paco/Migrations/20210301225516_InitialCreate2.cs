using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f5f19d4-cf87-41c3-8d5b-98ea83b582f9"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"), new Guid("65809062-ffd3-4903-83c0-5b1c91c4b5da") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("6f2e5ed7-cfe9-4ac7-8e4d-ec1f96fdbeff"), new Guid("5de90034-b633-4824-9bf2-5b83802fe8bf"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("e5206b41-48ec-4d63-b9cb-b62d5ff6e96d"), new Guid("2babfe64-e594-406e-ac00-c575273d9cf7"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("65809062-ffd3-4903-83c0-5b1c91c4b5da"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("2babfe64-e594-406e-ac00-c575273d9cf7"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("5de90034-b633-4824-9bf2-5b83802fe8bf"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"), "73a41a0f-41ce-429b-84f5-4614d1492c7c", null, null, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("8f7d95ed-b7c3-42db-9dd3-ae3505878cce"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@ads.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@ads.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("10c5f3b0-c176-4f1d-bc37-9ab92bf6863b"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("ecf043b0-68a7-415e-8f23-64d6a7ad2c63"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("65077aeb-63e1-42d2-ae61-512383b8f040"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"), new Guid("8f7d95ed-b7c3-42db-9dd3-ae3505878cce"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("3ca5b825-56f6-44fd-b649-aa2da3aaf9d4"), new Guid("10c5f3b0-c176-4f1d-bc37-9ab92bf6863b"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("377716b7-38a7-4ae2-bfd7-a769716232a9"), new Guid("ecf043b0-68a7-415e-8f23-64d6a7ad2c63"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"), null, null, (short)7, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65077aeb-63e1-42d2-ae61-512383b8f040"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"), new Guid("8f7d95ed-b7c3-42db-9dd3-ae3505878cce") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("377716b7-38a7-4ae2-bfd7-a769716232a9"), new Guid("ecf043b0-68a7-415e-8f23-64d6a7ad2c63"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d") });

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("3ca5b825-56f6-44fd-b649-aa2da3aaf9d4"), new Guid("10c5f3b0-c176-4f1d-bc37-9ab92bf6863b"), new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bbc09947-078a-4268-9918-d6bd6f1f2a3d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f7d95ed-b7c3-42db-9dd3-ae3505878cce"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("10c5f3b0-c176-4f1d-bc37-9ab92bf6863b"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("ecf043b0-68a7-415e-8f23-64d6a7ad2c63"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"), "c38edbf4-7ca8-437e-95b8-21ba7129d2fc", null, null, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("65809062-ffd3-4903-83c0-5b1c91c4b5da"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@ads.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@ads.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("2babfe64-e594-406e-ac00-c575273d9cf7"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("5de90034-b633-4824-9bf2-5b83802fe8bf"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("5f5f19d4-cf87-41c3-8d5b-98ea83b582f9"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"), new Guid("65809062-ffd3-4903-83c0-5b1c91c4b5da"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("e5206b41-48ec-4d63-b9cb-b62d5ff6e96d"), new Guid("2babfe64-e594-406e-ac00-c575273d9cf7"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("6f2e5ed7-cfe9-4ac7-8e4d-ec1f96fdbeff"), new Guid("5de90034-b633-4824-9bf2-5b83802fe8bf"), new Guid("d7e82ef1-13be-4efb-82e7-44f07278129d"), null, null, (short)7, null });
        }
    }
}
