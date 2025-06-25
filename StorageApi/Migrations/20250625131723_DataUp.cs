using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageApi.Migrations
{
    /// <inheritdoc />
    public partial class DataUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductDto",
                columns: new[] { "Id", "Category", "Count", "Description", "Name", "Price", "Shelf" },
                values: new object[,]
                {
                    { 1, "Sample Category", 100, "This is a sample product description.", "Sample Product", 9.99m, "A1" },
                    { 2, "Sample Category", 100, "This is a sample product description.", "Sample Product Two", 19.99m, "B1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDto",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
