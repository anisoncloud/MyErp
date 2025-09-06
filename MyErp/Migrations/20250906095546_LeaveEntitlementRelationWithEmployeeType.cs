using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class LeaveEntitlementRelationWithEmployeeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                table: "LeaveEntitlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveEntitlements_EmployeeTypeId",
                table: "LeaveEntitlements",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveEntitlements_EmployeeTypes_EmployeeTypeId",
                table: "LeaveEntitlements",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveEntitlements_EmployeeTypes_EmployeeTypeId",
                table: "LeaveEntitlements");

            migrationBuilder.DropIndex(
                name: "IX_LeaveEntitlements_EmployeeTypeId",
                table: "LeaveEntitlements");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                table: "LeaveEntitlements");
        }
    }
}
