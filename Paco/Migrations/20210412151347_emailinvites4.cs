using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class emailinvites4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEmailInvite");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1981aade-0a36-4e24-9ff5-ec4b296804a9"), new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"));

            migrationBuilder.CreateTable(
                name: "EmailInvites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InviterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInvites_AspNetUsers_InviterId",
                        column: x => x.InviterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailInvites_AspNetUsers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("e781a250-cbe3-4fd0-96a8-cc247f6a4e7d"), "e436f44d-32fe-42b9-997a-61360947287a", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("6253809a-2ad3-4bf0-9db7-7d33b576a111"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("7b73ad76-c1e3-4cae-ad61-a37a588defef"), new Guid("e781a250-cbe3-4fd0-96a8-cc247f6a4e7d"), new Guid("6253809a-2ad3-4bf0-9db7-7d33b576a111"), null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_EmailInvites_InviterId",
                table: "EmailInvites",
                column: "InviterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInvites_TargetId",
                table: "EmailInvites",
                column: "TargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailInvites");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7b73ad76-c1e3-4cae-ad61-a37a588defef"), new Guid("e781a250-cbe3-4fd0-96a8-cc247f6a4e7d"), new Guid("6253809a-2ad3-4bf0-9db7-7d33b576a111") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e781a250-cbe3-4fd0-96a8-cc247f6a4e7d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6253809a-2ad3-4bf0-9db7-7d33b576a111"));

            migrationBuilder.CreateTable(
                name: "UserEmailInvite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InviterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmailInvite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmailInvite_AspNetUsers_InviterId",
                        column: x => x.InviterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEmailInvite_AspNetUsers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), "9d110ccd-7663-4ec1-816f-57c79caf103f", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("1981aade-0a36-4e24-9ff5-ec4b296804a9"), new Guid("9359bfdf-31a5-4d89-b025-bd0cbbdf5cf3"), new Guid("57ada597-8b88-4941-b5b4-5d724e9d19a8"), null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_UserEmailInvite_InviterId",
                table: "UserEmailInvite",
                column: "InviterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmailInvite_TargetId",
                table: "UserEmailInvite",
                column: "TargetId",
                unique: true);
        }
    }
}
