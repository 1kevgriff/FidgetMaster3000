using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class fidgetapproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Fidgets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Fidgets",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Fidgets");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Fidgets");

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
    }
}
