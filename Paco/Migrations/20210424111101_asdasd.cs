using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("75e47a9a-546e-4048-a3f1-54bb2fcb3d0b"), new Guid("cbe38f69-845d-426f-9490-8ef24c56f0e5"), new Guid("45a09434-06b3-4931-b9c2-553634cfe2e8") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbe38f69-845d-426f-9490-8ef24c56f0e5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("45a09434-06b3-4931-b9c2-553634cfe2e8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("42fb97d3-a862-4036-8a89-91806a6c79eb"), "33b059e2-a7cc-4f81-b24c-f457eab43d06", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("91fb5d6b-1c8b-47f0-8863-b8f1e65ab705"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("ffb1bc71-d9e1-423d-b7ee-5c9f2bd22e80"), new Guid("42fb97d3-a862-4036-8a89-91806a6c79eb"), new Guid("91fb5d6b-1c8b-47f0-8863-b8f1e65ab705"), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "Id", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ffb1bc71-d9e1-423d-b7ee-5c9f2bd22e80"), new Guid("42fb97d3-a862-4036-8a89-91806a6c79eb"), new Guid("91fb5d6b-1c8b-47f0-8863-b8f1e65ab705") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("42fb97d3-a862-4036-8a89-91806a6c79eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("91fb5d6b-1c8b-47f0-8863-b8f1e65ab705"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("cbe38f69-845d-426f-9490-8ef24c56f0e5"), "a1f3b296-5f11-4010-9e0a-444c0add3071", null, null, null, "Administrator", "ADMINISTRATOR", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "EmailNotifications", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("45a09434-06b3-4931-b9c2-553634cfe2e8"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "michal.zahradnik@backbone.sk", true, true, true, null, "MICHAL.ZAHRADNIK@BACKBONE.SK", "MICHAL.ZAHRADNIK@BACKBONE.SK", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "michal.zahradnik@backbone.sk" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("75e47a9a-546e-4048-a3f1-54bb2fcb3d0b"), new Guid("cbe38f69-845d-426f-9490-8ef24c56f0e5"), new Guid("45a09434-06b3-4931-b9c2-553634cfe2e8"), null, null, null });
        }
    }
}
