using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paco.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    SourceContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagedSystemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagedSystemGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagedSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemFingerprint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SshPrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatesFetchedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Distribution = table.Column<int>(type: "int", nullable: false),
                    NeedsInteraction = table.Column<bool>(type: "bit", nullable: false),
                    InteractionReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagedSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagedSystemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_ManagedSystemGroups_ManagedSystemGroupId",
                        column: x => x.ManagedSystemGroupId,
                        principalTable: "ManagedSystemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagedSystemManagedSystemGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagedSystemManagedSystemGroups", x => new { x.Id, x.ManagedSystemId, x.ManagedSystemGroupId });
                    table.ForeignKey(
                        name: "FK_ManagedSystemManagedSystemGroups_ManagedSystemGroups_ManagedSystemGroupId",
                        column: x => x.ManagedSystemGroupId,
                        principalTable: "ManagedSystemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagedSystemManagedSystemGroups_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.Id, x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleManagedSystemGroupPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permissions = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleManagedSystemGroupPermissions", x => new { x.Id, x.RoleId, x.ManagedSystemGroupId });
                    table.ForeignKey(
                        name: "FK_RoleManagedSystemGroupPermissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleManagedSystemGroupPermissions_ManagedSystemGroups_ManagedSystemGroupId",
                        column: x => x.ManagedSystemGroupId,
                        principalTable: "ManagedSystemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleManagedSystemPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagedSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permissions = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleManagedSystemPermissions", x => new { x.Id, x.RoleId, x.ManagedSystemId });
                    table.ForeignKey(
                        name: "FK_RoleManagedSystemPermissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleManagedSystemPermissions_ManagedSystems_ManagedSystemId",
                        column: x => x.ManagedSystemId,
                        principalTable: "ManagedSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "ManagedSystemGroupId", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("52a86539-bcf6-41d2-b207-333232e88a47"), "6447c131-e077-4df7-99fa-240f5a8c3500", null, null, null, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("b55d975f-3242-4965-a1b7-2585e4478980"), 0, "34acbb54-9ae3-4742-af3c-89de44e306e0", null, null, "asd@ads.asd", true, true, null, "ASD@ASD.ASD", "ASD@ASD.ASD", "AQAAAAEAACcQAAAAEJdyASTL66Dd+IQPIPJsne7GQnFQ+H8G7ngSPb5+OUNH8+PU7YuCzPjjLMvj947dcg==", null, false, "JBIW2JAV2THPAPR3NGHSE3ZVXUCHEBPU", false, null, "asd@ads.asd" });

            migrationBuilder.InsertData(
                table: "ManagedSystems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Distribution", "Hostname", "InteractionReason", "LastAccessed", "Login", "Name", "NeedsInteraction", "Password", "SshPrivateKey", "SystemFingerprint", "SystemInformation", "UpdatedAt", "UpdatesFetchedAt" },
                values: new object[,]
                {
                    { new Guid("69ad0426-0220-4f66-8cad-5f56f6c0a3f5"), null, null, 0, "none.test.test", null, null, "test", "PermNone", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null },
                    { new Guid("632183fb-7097-46ad-9b1b-5fa9b5fcef3e"), null, null, 0, "multiple.test.test", null, null, "test", "PermMultiple", false, "test", null, "12:f8:7e:78:61:b4:bf:e2:de:24:15:96:4e:d4:72:53", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "Id", "RoleId", "UserId", "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("5a64b34d-fed6-4be6-87b3-6c93faf2db01"), new Guid("52a86539-bcf6-41d2-b207-333232e88a47"), new Guid("b55d975f-3242-4965-a1b7-2585e4478980"), null, null, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("0ff69add-2e3f-47b3-9106-3bf839cbb595"), new Guid("69ad0426-0220-4f66-8cad-5f56f6c0a3f5"), new Guid("52a86539-bcf6-41d2-b207-333232e88a47"), null, null, (short)0, null });

            migrationBuilder.InsertData(
                table: "RoleManagedSystemPermissions",
                columns: new[] { "Id", "ManagedSystemId", "RoleId", "CreatedAt", "DeletedAt", "Permissions", "UpdatedAt" },
                values: new object[] { new Guid("d6276b79-60e4-4b27-9e2d-40640058d22d"), new Guid("632183fb-7097-46ad-9b1b-5fa9b5fcef3e"), new Guid("52a86539-bcf6-41d2-b207-333232e88a47"), null, null, (short)7, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ManagedSystemGroupId",
                table: "AspNetRoles",
                column: "ManagedSystemGroupId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ManagedSystemManagedSystemGroups_ManagedSystemGroupId",
                table: "ManagedSystemManagedSystemGroups",
                column: "ManagedSystemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagedSystemManagedSystemGroups_ManagedSystemId",
                table: "ManagedSystemManagedSystemGroups",
                column: "ManagedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleManagedSystemGroupPermissions_ManagedSystemGroupId",
                table: "RoleManagedSystemGroupPermissions",
                column: "ManagedSystemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleManagedSystemGroupPermissions_RoleId",
                table: "RoleManagedSystemGroupPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleManagedSystemPermissions_ManagedSystemId",
                table: "RoleManagedSystemPermissions",
                column: "ManagedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleManagedSystemPermissions_RoleId",
                table: "RoleManagedSystemPermissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LogRecords");

            migrationBuilder.DropTable(
                name: "ManagedSystemManagedSystemGroups");

            migrationBuilder.DropTable(
                name: "RoleManagedSystemGroupPermissions");

            migrationBuilder.DropTable(
                name: "RoleManagedSystemPermissions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ManagedSystems");

            migrationBuilder.DropTable(
                name: "ManagedSystemGroups");
        }
    }
}
