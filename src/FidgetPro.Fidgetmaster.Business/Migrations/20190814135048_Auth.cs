using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 20, 14, 6, 486, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 20, 14, 6, 486, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 20, 14, 6, 486, DateTimeKind.Utc).AddTicks(2206));
        }
    }
}
