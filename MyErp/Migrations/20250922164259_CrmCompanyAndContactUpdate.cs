using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class CrmCompanyAndContactUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "CrmCompanies");

            migrationBuilder.DropColumn(
                name: "ContactPersonEmail",
                table: "CrmCompanies");

            migrationBuilder.DropColumn(
                name: "ContactPersonPhone",
                table: "CrmCompanies");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "CrmCompanies");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CrmContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CrmContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CrmContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CrmContacts",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CrmContacts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CrmContacts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CrmContacts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CrmContacts");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonEmail",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonPhone",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "CrmCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
