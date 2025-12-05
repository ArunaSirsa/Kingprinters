using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LONG_ID = table.Column<int>(type: "int", nullable: false),
                    OPTIONS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QTY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CARRIAGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Margin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productPrices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_features_DieCutOption",
                table: "features",
                column: "DieCutOption");

            migrationBuilder.CreateIndex(
                name: "IX_features_FoilOption",
                table: "features",
                column: "FoilOption");

            migrationBuilder.CreateIndex(
                name: "IX_features_LaminationType",
                table: "features",
                column: "LaminationType");

            migrationBuilder.CreateIndex(
                name: "IX_features_UVOption",
                table: "features",
                column: "UVOption");

            migrationBuilder.AddForeignKey(
                name: "FK_features_dieCutOptions_DieCutOption",
                table: "features",
                column: "DieCutOption",
                principalTable: "dieCutOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_features_foilOptions_FoilOption",
                table: "features",
                column: "FoilOption",
                principalTable: "foilOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_features_laminationTypes_LaminationType",
                table: "features",
                column: "LaminationType",
                principalTable: "laminationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_features_uVOptions_UVOption",
                table: "features",
                column: "UVOption",
                principalTable: "uVOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_features_dieCutOptions_DieCutOption",
                table: "features");

            migrationBuilder.DropForeignKey(
                name: "FK_features_foilOptions_FoilOption",
                table: "features");

            migrationBuilder.DropForeignKey(
                name: "FK_features_laminationTypes_LaminationType",
                table: "features");

            migrationBuilder.DropForeignKey(
                name: "FK_features_uVOptions_UVOption",
                table: "features");

            migrationBuilder.DropTable(
                name: "productPrices");

            migrationBuilder.DropIndex(
                name: "IX_features_DieCutOption",
                table: "features");

            migrationBuilder.DropIndex(
                name: "IX_features_FoilOption",
                table: "features");

            migrationBuilder.DropIndex(
                name: "IX_features_LaminationType",
                table: "features");

            migrationBuilder.DropIndex(
                name: "IX_features_UVOption",
                table: "features");
        }
    }
}
