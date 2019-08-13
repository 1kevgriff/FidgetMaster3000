using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class SeedFidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets");

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                table: "Fidgets",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Fidgets",
                columns: new[] { "Id", "Color", "Name", "TypeId" },
                values: new object[] { 1L, "Green", "Foo", 2L });

            migrationBuilder.AddForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets",
                column: "TypeId",
                principalTable: "FidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets");

            migrationBuilder.DeleteData(
                table: "Fidgets",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                table: "Fidgets",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "FidgetTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DesignedDate",
                value: new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.AddForeignKey(
                name: "FK_Fidgets_FidgetTypes_TypeId",
                table: "Fidgets",
                column: "TypeId",
                principalTable: "FidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
