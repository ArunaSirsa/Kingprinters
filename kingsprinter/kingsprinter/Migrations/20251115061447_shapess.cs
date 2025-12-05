using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kingsprinter.Migrations
{
    public partial class shapess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShapeNumber",
                table: "dieCutShapes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ShapeImage",
                table: "dieCutShapes",
                newName: "ShapeName");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "dieCutShapes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "dieCutShapes");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "dieCutShapes",
                newName: "ShapeNumber");

            migrationBuilder.RenameColumn(
                name: "ShapeName",
                table: "dieCutShapes",
                newName: "ShapeImage");
        }
    }
}
