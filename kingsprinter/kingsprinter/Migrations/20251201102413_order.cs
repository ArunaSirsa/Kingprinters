using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Printing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whitebase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotUV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoilColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diecutshapeid = table.Column<int>(type: "int", nullable: false),
                    FileOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    laminationTypeid = table.Column<int>(type: "int", nullable: false),
                    textureId = table.Column<int>(type: "int", nullable: false),
                    TextureTypeid = table.Column<int>(type: "int", nullable: false),
                    PrivacyPacking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterPressline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountPayable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_dieCutShapes_diecutshapeid",
                        column: x => x.diecutshapeid,
                        principalTable: "dieCutShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_laminationTypes_laminationTypeid",
                        column: x => x.laminationTypeid,
                        principalTable: "laminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_textures_textureId",
                        column: x => x.textureId,
                        principalTable: "textures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_diecutshapeid",
                table: "orders",
                column: "diecutshapeid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_laminationTypeid",
                table: "orders",
                column: "laminationTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Productid",
                table: "orders",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_textureId",
                table: "orders",
                column: "textureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
