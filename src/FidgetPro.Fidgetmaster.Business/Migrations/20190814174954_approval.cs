using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class approval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanApprovedFidgets",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 49, 54, 603, DateTimeKind.Utc).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 49, 54, 603, DateTimeKind.Utc).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 49, 54, 603, DateTimeKind.Utc).AddTicks(7836));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanApprovedFidgets",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 4, 8, 176, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 4, 8, 176, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 17, 4, 8, 176, DateTimeKind.Utc).AddTicks(8642));
        }
    }
}
