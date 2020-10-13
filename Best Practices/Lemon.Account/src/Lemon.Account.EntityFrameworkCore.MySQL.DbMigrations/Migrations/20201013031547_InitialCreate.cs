using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lemon.Account.EntityFrameworkCore.MySQL.DbMigrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionData",
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
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogOn",
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
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
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
                        principalTable: "RoleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Account",
                table: "UserData",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Email",
                table: "UserData",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserData_Mobile",
                table: "UserData",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_UserId",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionData");

            migrationBuilder.DropTable(
                name: "RolePermissionData");

            migrationBuilder.DropTable(
                name: "UserLogOn");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "RoleData");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
