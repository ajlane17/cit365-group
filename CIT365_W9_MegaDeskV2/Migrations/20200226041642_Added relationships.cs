using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk.Migrations
{
    public partial class Addedrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "customerName",
                table: "DeskQuote",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "rushTypeid",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "totalQuote",
                table: "DeskQuote",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "totalQuote",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<string>(
                name: "customerName",
                table: "DeskQuote",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
