using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSSCodingChallenge.Migrations
{
    public partial class dbchangename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fund",
                keyColumn: "Id",
                keyValue: 2,
                column: "description",
                value: "testDescription3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Fund",
                keyColumn: "Id",
                keyValue: 2,
                column: "description",
                value: "testDescription2");
        }
    }
}
