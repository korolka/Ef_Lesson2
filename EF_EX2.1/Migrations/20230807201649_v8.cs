using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX2._1.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_ProductAlterId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductAlterId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductAlterId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_ProductAlterId",
                table: "Products",
                column: "ProductAlterId");
        }
    }
}
