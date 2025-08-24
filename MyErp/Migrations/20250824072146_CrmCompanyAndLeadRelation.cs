using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class CrmCompanyAndLeadRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrmCompanyId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CrmCompanyId",
                table: "Leads",
                column: "CrmCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_CrmCompanies_CrmCompanyId",
                table: "Leads",
                column: "CrmCompanyId",
                principalTable: "CrmCompanies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_CrmCompanies_CrmCompanyId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CrmCompanyId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CrmCompanyId",
                table: "Leads");
        }
    }
}
