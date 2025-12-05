using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class fet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UVOption",
                table: "features",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LaminationType",
                table: "features",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FoilOption",
                table: "features",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DieCutOption",
                table: "features",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UVOption",
                table: "features",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LaminationType",
                table: "features",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FoilOption",
                table: "features",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DieCutOption",
                table: "features",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
