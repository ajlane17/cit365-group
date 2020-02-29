using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk.Migrations
{
    public partial class workingonselectlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushType_rushTypeid",
                table: "DeskQuote");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_rushTypeid",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "rushTypeid",
                table: "DeskQuote");

            migrationBuilder.AddColumn<int>(
                name: "rushID",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rushID",
                table: "DeskQuote");

            migrationBuilder.AddColumn<int>(
                name: "rushTypeid",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_rushTypeid",
                table: "DeskQuote",
                column: "rushTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushType_rushTypeid",
                table: "DeskQuote",
                column: "rushTypeid",
                principalTable: "RushType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
