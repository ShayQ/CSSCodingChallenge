using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSSCodingChallenge.Migrations
{
    public partial class addedfundvalueseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FundValues",
                columns: new[] { "fund_id", "value", "value_date" },
                values: new object[] { 1, 630m, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundValues",
                keyColumn: "fund_id",
                keyValue: 1);
        }
    }
}
