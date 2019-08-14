using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class disablecascading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets");

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 19, 29, 29, 155, DateTimeKind.Utc).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 19, 29, 29, 155, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 14, 19, 29, 29, 155, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.AddForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets",
                column: "TypeId",
                principalTable: "FidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets",
                column: "TypeId",
                principalTable: "FidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
