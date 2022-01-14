using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class addedfundseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fund_id",
                table: "Fund",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Fund",
                columns: new[] { "Id", "description", "name" },
                values: new object[] { 1, "testDescription1", "testName1" });

            migrationBuilder.InsertData(
                table: "Fund",
                columns: new[] { "Id", "description", "name" },
                values: new object[] { 2, "testDescription2", "testName2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fund",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fund",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fund",
                newName: "fund_id");
        }
    }
}
