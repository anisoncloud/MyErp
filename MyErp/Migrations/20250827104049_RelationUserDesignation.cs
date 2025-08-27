using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyErp.Migrations
{
    /// <inheritdoc />
    public partial class RelationUserDesignation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DesignationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "AspNetUsers");
        }
    }
}
