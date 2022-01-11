using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSSCodingChallenge.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    fund_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.fund_id);
                });

            migrationBuilder.CreateTable(
                name: "FundValues",
                columns: table => new
                {
                    fund_id = table.Column<int>(type: "int", nullable: false),
                    value_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundValues", x => x.fund_id);
                    table.ForeignKey(
                        name: "FK_FundValues_Fund_fund_id",
                        column: x => x.fund_id,
                        principalTable: "Fund",
                        principalColumn: "fund_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundValues");

            migrationBuilder.DropTable(
                name: "Fund");
        }
    }
}
