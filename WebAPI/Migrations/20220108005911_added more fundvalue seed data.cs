using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addedmorefundvalueseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FundValues",
                table: "FundValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundValues",
                table: "FundValues",
                columns: new[] { "fund_id", "value_date" });

            migrationBuilder.InsertData(
                table: "FundValues",
                columns: new[] { "fund_id", "value_date", "value" },
                values: new object[] { 2, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 930m });

            migrationBuilder.InsertData(
                table: "FundValues",
                columns: new[] { "fund_id", "value_date", "value" },
                values: new object[] { 2, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1231m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FundValues",
                table: "FundValues");

            migrationBuilder.DeleteData(
                table: "FundValues",
                keyColumns: new[] { "fund_id", "value_date" },
                keyValues: new object[] { 2, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "FundValues",
                keyColumns: new[] { "fund_id", "value_date" },
                keyValues: new object[] { 2, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundValues",
                table: "FundValues",
                column: "fund_id");
        }
    }
}
