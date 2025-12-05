using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class jkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_textures_textureId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_textureId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TextureTypeid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "textureId",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextureTypeid",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "textureId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_textureId",
                table: "orders",
                column: "textureId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_textures_textureId",
                table: "orders",
                column: "textureId",
                principalTable: "textures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
