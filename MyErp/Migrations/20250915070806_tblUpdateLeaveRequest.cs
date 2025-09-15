using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class tblUpdateLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ManagerEmail",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerEmail",
                table: "LeaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "LeaveType",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
