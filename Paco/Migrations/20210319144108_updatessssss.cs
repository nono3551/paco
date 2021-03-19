using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class updatessssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUpdates");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("eb2d4b6d-0a90-49ba-b2c7-f64b85052f9b"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"), new Guid("026f2802-ed5a-457d-b452-85a330187de7") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("4ef781ac-7750-4216-94f3-2950d14613b2"), new Guid("5c4132ab-0ca6-4393-bef5-5674695fcd8e"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe") });

            migrationBuilder.DeleteData(
                table: "RoleManagedSystemPermissions",
                keyColumns: new[] { "Id", "ManagedSystemId", "RoleId" },
                keyValues: new object[] { new Guid("67f31bd1-dbf7-42e8-9e14-e4348ac73e83"), new Guid("448d7f2a-178d-46a2-bf4b-accb484fee4b"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("026f2802-ed5a-457d-b452-85a330187de7"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("448d7f2a-178d-46a2-bf4b-accb484fee4b"));

            migrationBuilder.DeleteData(
                table: "ManagedSystems",
                keyColumn: "Id",
                keyValue: new Guid("5c4132ab-0ca6-4393-bef5-5674695fcd8e"));

            migrationBuilder.CreateTable(
                name: "ScheduledActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledActionStatus = table.Column<int>(type: "int", nullable: false),
                    ScheduledActionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledActions_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledActions_ManagedSystemId",
                table: "ScheduledActions",
                column: "ManagedSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledActions");

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

            migrationBuilder.CreateTable(
                name: "SystemUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateStatus = table.Column<int>(type: "int", nullable: false),
                    UpdateType = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUpdates_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"), "29cee10b-d7b0-4cbc-8371-5378ae9f547a", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("026f2802-ed5a-457d-b452-85a330187de7"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@asd.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@asd.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("5c4132ab-0ca6-4393-bef5-5674695fcd8e"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("448d7f2a-178d-46a2-bf4b-accb484fee4b"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("eb2d4b6d-0a90-49ba-b2c7-f64b85052f9b"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"), new Guid("026f2802-ed5a-457d-b452-85a330187de7"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("4ef781ac-7750-4216-94f3-2950d14613b2"), new Guid("5c4132ab-0ca6-4393-bef5-5674695fcd8e"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("67f31bd1-dbf7-42e8-9e14-e4348ac73e83"), new Guid("448d7f2a-178d-46a2-bf4b-accb484fee4b"), new Guid("6ea13974-8a28-4de6-abdb-05bb85e24dfe"), null, null, (short)7, null });

            migrationBuilder.CreateIndex(
                name: "IX_SystemUpdates_ManagedSystemId",
                table: "SystemUpdates",
                column: "ManagedSystemId");
        }
    }
}
