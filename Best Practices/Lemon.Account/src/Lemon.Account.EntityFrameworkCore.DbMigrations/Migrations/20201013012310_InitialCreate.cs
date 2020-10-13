using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lemon.Account.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "account");

            migrationBuilder.CreateTable(
                name: "PermissionData",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleData",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    HeadIcon = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionData",
                schema: "account",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Permission = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionData", x => new { x.RoleId, x.Permission });
                    table.ForeignKey(
                        name: "FK_RolePermissionData_RoleData_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "account",
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogOn",
                schema: "account",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    SecretKey = table.Column<string>(nullable: true),
                    AllowStartTime = table.Column<DateTime>(nullable: false),
                    AllowEndTime = table.Column<DateTime>(nullable: false),
                    LockStartTime = table.Column<DateTime>(nullable: false),
                    LockEndDate = table.Column<DateTime>(nullable: false),
                    FirstVisitTime = table.Column<DateTime>(nullable: false),
                    PreviousVisitTime = table.Column<DateTime>(nullable: false),
                    LastVisitTime = table.Column<DateTime>(nullable: false),
                    ChangPasswordDate = table.Column<DateTime>(nullable: false),
                    MultiUserLogin = table.Column<bool>(nullable: false),
                    LogonCount = table.Column<int>(nullable: false),
                    UserOnline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogOn", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserLogOn_UserData_UserId",
                        column: x => x.UserId,
                        principalSchema: "account",
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_RoleData_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "account",
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserData_UserId",
                        column: x => x.UserId,
                        principalSchema: "account",
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Account",
                schema: "account",
                table: "UserData",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Email",
                schema: "account",
                table: "UserData",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Mobile",
                schema: "account",
                table: "UserData",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "account",
                table: "UserRole",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "account",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_UserId",
                schema: "account",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionData",
                schema: "account");

            migrationBuilder.DropTable(
                name: "RolePermissionData",
                schema: "account");

            migrationBuilder.DropTable(
                name: "UserLogOn",
                schema: "account");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "account");

            migrationBuilder.DropTable(
                name: "RoleData",
                schema: "account");

            migrationBuilder.DropTable(
                name: "UserData",
                schema: "account");
        }
    }
}
