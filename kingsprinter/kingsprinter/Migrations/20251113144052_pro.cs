using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class pro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    LaminationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UVOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoilOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieCutOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextureOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_processes_Subcategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processes_SubCategoryId",
                table: "processes",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "processes");
        }
    }
}
