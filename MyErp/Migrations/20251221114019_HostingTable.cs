using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class HostingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Hostings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    CrmCompanyId = table.Column<int>(type: "int", nullable: false),
                    HostingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostingExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostingUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostingDuration = table.Column<int>(type: "int", nullable: false),
                    PricePerYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Package = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hostings_CrmCompanies_CrmCompanyId",
                        column: x => x.CrmCompanyId,
                        principalTable: "CrmCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hostings_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hostings_CrmCompanyId",
                table: "Hostings",
                column: "CrmCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hostings_DomainId",
                table: "Hostings",
                column: "DomainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hostings");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
