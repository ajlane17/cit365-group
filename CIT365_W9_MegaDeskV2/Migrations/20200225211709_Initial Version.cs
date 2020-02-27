using Microsoft.EntityFrameworkCore.Migrations;

namespace CIT365_W9_MegaDeskV2.Migrations
{
    public partial class InitialVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RushType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false),
                    tier1Cost = table.Column<float>(nullable: false),
                    tier2Cost = table.Column<float>(nullable: false),
                    tier3Cost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SurfaceMaterial",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(maxLength: 30, nullable: false),
                    cost = table.Column<float>(nullable: false),
                    imageFile = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceMaterial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    width = table.Column<double>(nullable: false),
                    depth = table.Column<double>(nullable: false),
                    drawers = table.Column<int>(nullable: false),
                    surfaceMaterialid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.id);
                    table.ForeignKey(
                        name: "FK_Desk_SurfaceMaterial_surfaceMaterialid",
                        column: x => x.surfaceMaterialid,
                        principalTable: "SurfaceMaterial",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(maxLength: 50, nullable: false),
                    deskid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_deskid",
                        column: x => x.deskid,
                        principalTable: "Desk",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_surfaceMaterialid",
                table: "Desk",
                column: "surfaceMaterialid");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_deskid",
                table: "DeskQuote",
                column: "deskid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "RushType");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "SurfaceMaterial");
        }
    }
}
