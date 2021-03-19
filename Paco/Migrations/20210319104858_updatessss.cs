using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class updatessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUpdate");

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

            migrationBuilder.CreateTable(
                name: "SystemUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateStatus = table.Column<int>(type: "int", nullable: false),
                    UpdateType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "SystemUpdate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateStatus = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUpdate_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SystemUpdate_ManagedSystemId",
                table: "SystemUpdate",
                column: "ManagedSystemId");
        }
    }
}
