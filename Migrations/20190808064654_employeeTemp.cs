using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class employeeTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Prakash@gamisl.com", "Prakash" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Pramodh@gamisl.com", "Pramodh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Radhe@gamisl.com", "Radhe" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Rakesh@gamisl.com", "Rakesh" });
        }
    }
}
