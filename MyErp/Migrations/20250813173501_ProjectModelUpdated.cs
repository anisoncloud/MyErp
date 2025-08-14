using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class ProjectModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Advanced",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DemoStartDate",
                table: "Projects",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectDays",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ProjectDeliveryDate",
                table: "Projects",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectDetails",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectValue",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkOrderDate",
                table: "Projects",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advanced",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DemoStartDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDays",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDeliveryDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDetails",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectValue",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "WorkOrderDate",
                table: "Projects");
        }
    }
}
