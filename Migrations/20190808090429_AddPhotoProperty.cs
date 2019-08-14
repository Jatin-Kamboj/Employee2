using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AddPhotoProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "id", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 7, 1, "Prakash@gamisl.com", "Prakash" },
                    { 8, 3, "Pramodh@gamisl.com", "Pramodh" }
                });
        }
    }
}
