using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextureTypeid",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_TextureTypeid",
                table: "orders",
                column: "TextureTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_textures_TextureTypeid",
                table: "orders",
                column: "TextureTypeid",
                principalTable: "textures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_textures_TextureTypeid",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_TextureTypeid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TextureTypeid",
                table: "orders");
        }
    }
}
