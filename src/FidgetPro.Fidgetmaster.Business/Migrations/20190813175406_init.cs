using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FidgetPro.Fidgetmaster.Business.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FidgetTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true),
                    DesignedDate = table.Column<DateTime>(nullable: false),
                    IsSpinning = table.Column<bool>(nullable: false),
                    IsBouncing = table.Column<bool>(nullable: false),
                    IsFlying = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FidgetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fidgets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fidgets_FidgetTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FidgetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FidgetTypes",
                columns: new[] { "Id", "DesignedDate", "IsBouncing", "IsFlying", "IsSpinning", "TypeName" },
                values: new object[] { 1L, new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(2892), false, true, true, "Thingamajig" });

            migrationBuilder.InsertData(
                table: "FidgetTypes",
                columns: new[] { "Id", "DesignedDate", "IsBouncing", "IsFlying", "IsSpinning", "TypeName" },
                values: new object[] { 2L, new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(4890), true, false, true, "Domaflotitch" });

            migrationBuilder.InsertData(
                table: "FidgetTypes",
                columns: new[] { "Id", "DesignedDate", "IsBouncing", "IsFlying", "IsSpinning", "TypeName" },
                values: new object[] { 3L, new DateTime(2019, 8, 13, 17, 54, 5, 954, DateTimeKind.Utc).AddTicks(4903), false, false, false, "Chad" });

            migrationBuilder.CreateIndex(
                name: "IX_Fidgets_TypeId",
                table: "Fidgets",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fidgets");

            migrationBuilder.DropTable(
                name: "FidgetTypes");
        }
    }
}
