using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class updatessssssssssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("90579e5a-b144-4cfa-bfec-8f5b8bc6edc5"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"), new Guid("d6c1da36-0f7c-4a25-8586-70bd67a027da") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("71513efe-0fc3-48e5-afdc-87cec5ea79ed"), new Guid("8ae3271b-cede-4f40-8318-c8fd591645e4"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("944f2e5d-aa96-4617-beb9-250e047d092a"), new Guid("f4297d25-80b6-4cf1-a8f7-7894c3ed1465"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6c1da36-0f7c-4a25-8586-70bd67a027da"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("8ae3271b-cede-4f40-8318-c8fd591645e4"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("f4297d25-80b6-4cf1-a8f7-7894c3ed1465"));

            migrationBuilder.AddColumn<int>(
                name: "PackageActions",
                table: "ManagedSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PackageActions",
                table: "ManagedSystems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"), "43a08c13-15f5-4ee2-ba12-7745700263e9", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("d6c1da36-0f7c-4a25-8586-70bd67a027da"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("f4297d25-80b6-4cf1-a8f7-7894c3ed1465"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("8ae3271b-cede-4f40-8318-c8fd591645e4"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("90579e5a-b144-4cfa-bfec-8f5b8bc6edc5"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"), new Guid("d6c1da36-0f7c-4a25-8586-70bd67a027da"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("944f2e5d-aa96-4617-beb9-250e047d092a"), new Guid("f4297d25-80b6-4cf1-a8f7-7894c3ed1465"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("71513efe-0fc3-48e5-afdc-87cec5ea79ed"), new Guid("8ae3271b-cede-4f40-8318-c8fd591645e4"), new Guid("d01997a1-4a32-4623-a28a-dbf986da766e"), null, null, (short)7, null });
        }
    }
}
