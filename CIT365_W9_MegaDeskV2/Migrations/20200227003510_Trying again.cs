using Microsoft.EntityFrameworkCore.Migrations;

namespace CIT365_W9_MegaDeskV2.Migrations
{
    public partial class Tryingagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeskQuoteid",
                table: "SurfaceMaterial",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeskQuoteid",
                table: "RushType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurfaceMaterial_DeskQuoteid",
                table: "SurfaceMaterial",
                column: "DeskQuoteid");

            migrationBuilder.CreateIndex(
                name: "IX_RushType_DeskQuoteid",
                table: "RushType",
                column: "DeskQuoteid");

            migrationBuilder.AddForeignKey(
                name: "FK_RushType_DeskQuote_DeskQuoteid",
                table: "RushType",
                column: "DeskQuoteid",
                principalTable: "DeskQuote",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurfaceMaterial_DeskQuote_DeskQuoteid",
                table: "SurfaceMaterial",
                column: "DeskQuoteid",
                principalTable: "DeskQuote",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RushType_DeskQuote_DeskQuoteid",
                table: "RushType");

            migrationBuilder.DropForeignKey(
                name: "FK_SurfaceMaterial_DeskQuote_DeskQuoteid",
                table: "SurfaceMaterial");

            migrationBuilder.DropIndex(
                name: "IX_SurfaceMaterial_DeskQuoteid",
                table: "SurfaceMaterial");

            migrationBuilder.DropIndex(
                name: "IX_RushType_DeskQuoteid",
                table: "RushType");

            migrationBuilder.DropColumn(
                name: "DeskQuoteid",
                table: "SurfaceMaterial");

            migrationBuilder.DropColumn(
                name: "DeskQuoteid",
                table: "RushType");
        }
    }
}
