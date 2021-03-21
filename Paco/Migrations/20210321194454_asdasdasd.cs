using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class asdasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b62db8cf-e416-4f90-a3f0-263f03e35c45"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"), new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("524392ff-6a23-43bd-9804-af5799ec2a45"), new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("68fe8784-defe-49ea-a7e9-2f00ba764b41"), new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "ScheduledActions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "ScheduledActions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"), "aa6b91cf-6b3a-412d-810f-f3fd3555d446", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "PackageActions", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, 0, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("b62db8cf-e416-4f90-a3f0-263f03e35c45"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"), new Guid("248f87b1-6382-4c82-95e3-feb6824dcbe2"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("524392ff-6a23-43bd-9804-af5799ec2a45"), new Guid("aa33052b-e176-4e55-873b-11cb99a9362d"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("68fe8784-defe-49ea-a7e9-2f00ba764b41"), new Guid("ee290dc1-d530-4fce-9c4c-dcf586ea3924"), new Guid("9241a27f-2059-4067-8cf3-69f5d7f280f4"), null, null, (short)7, null });
        }
    }
}
