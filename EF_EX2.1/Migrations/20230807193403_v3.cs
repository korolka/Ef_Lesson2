using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_EX2._1.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_ProductAlterId",
                table: "Products",
                column: "ProductAlterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_ProductAlterId",
                table: "Products");
        }
    }
}
