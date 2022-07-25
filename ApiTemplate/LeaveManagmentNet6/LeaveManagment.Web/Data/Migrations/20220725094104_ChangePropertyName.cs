using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagment.Web.Data.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefauldDays",
                table: "LeaveTypes",
                newName: "DefaultDays");

            migrationBuilder.RenameColumn(
                name: "DateCreater",
                table: "LeaveAllocations",
                newName: "DateCreated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultDays",
                table: "LeaveTypes",
                newName: "DefauldDays");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "LeaveAllocations",
                newName: "DateCreater");
        }
    }
}
