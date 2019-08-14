using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 14, 7, 7, 662, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 14, 7, 7, 662, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 14, 7, 7, 662, DateTimeKind.Utc).AddTicks(8583));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 13, 50, 48, 471, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 13, 50, 48, 471, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 13, 50, 48, 471, DateTimeKind.Utc).AddTicks(7925));
        }
    }
}
