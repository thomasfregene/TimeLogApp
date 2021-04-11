using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadEmployeeAttendaceeSystem.Migrations
{
    public partial class addedIslogpropertyTimeLogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogin",
                table: "EmployeeTimeLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogin",
                table: "EmployeeTimeLogs");
        }
    }
}
