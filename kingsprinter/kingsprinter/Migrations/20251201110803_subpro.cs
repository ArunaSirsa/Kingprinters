using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class subpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Subcategories_SubCategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Subcatid",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Subcategories_SubCategoryId",
                table: "products",
                column: "SubCategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Subcategories_SubCategoryId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Subcatid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Subcategories_SubCategoryId",
                table: "products",
                column: "SubCategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id");
        }
    }
}
