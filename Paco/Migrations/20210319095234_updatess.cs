using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class updatess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "SystemUpdate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateStatus",
                table: "SystemUpdate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"), "a49c7bdc-2846-4a0f-9a8d-ae47ae74d011", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("907e640d-6108-4ba5-91a4-6227fedde0e6"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("3d3d1f96-e80e-4adb-95b6-efb84ecf360d"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("b38f8957-9ec3-4e59-899d-c08035e4f7e6"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("e1d01364-294a-4cb2-8f5b-2f7d28fe83ad"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"), new Guid("907e640d-6108-4ba5-91a4-6227fedde0e6"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("c791560a-8073-45bc-9a46-a7e36235db01"), new Guid("3d3d1f96-e80e-4adb-95b6-efb84ecf360d"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("9f120060-076c-4aa6-97a7-feb12fa6b6db"), new Guid("b38f8957-9ec3-4e59-899d-c08035e4f7e6"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"), null, null, (short)7, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1d01364-294a-4cb2-8f5b-2f7d28fe83ad"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"), new Guid("907e640d-6108-4ba5-91a4-6227fedde0e6") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("9f120060-076c-4aa6-97a7-feb12fa6b6db"), new Guid("b38f8957-9ec3-4e59-899d-c08035e4f7e6"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("c791560a-8073-45bc-9a46-a7e36235db01"), new Guid("3d3d1f96-e80e-4adb-95b6-efb84ecf360d"), new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6ba4599-c679-41de-9d89-8ec2d7d5d1e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("907e640d-6108-4ba5-91a4-6227fedde0e6"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("3d3d1f96-e80e-4adb-95b6-efb84ecf360d"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("b38f8957-9ec3-4e59-899d-c08035e4f7e6"));

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "SystemUpdate");

            migrationBuilder.DropColumn(
                name: "UpdateStatus",
                table: "SystemUpdate");

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
        }
    }
}
