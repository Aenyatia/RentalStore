using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalStore.Api.Infrastructure.Data.Migrations
{
    public partial class PopulateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Genre", "InStock", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "...", "Adventure", 10, 20.00m, "Pandora Hearts #1" },
                    { 2, "...", "Adventure", 0, 18.00m, "Pandora Hearts #2" },
                    { 3, null, "Fantasy", 3, 19.90m, "Akame ga Kill #1" },
                    { 4, null, "Fantasy", 4, 19.90m, "Akame ga Kill #2" },
                    { 5, null, "Horror", 7, 23.50m, "Pamiętnik Przyszłości #1" },
                    { 6, null, "Horror", 20, 35.79m, "Pamiętnik Przyszłości #2" },
                    { 7, "...", "Adventure", 10, 20.00m, "Pandora Hearts #1" },
                    { 8, "...", "Adventure", 0, 18.00m, "Pandora Hearts #2" },
                    { 9, null, "Horror", 7, 23.50m, "Pamiętnik Przyszłości #1" },
                    { 10, null, "Horror", 20, 35.79m, "Pamiętnik Przyszłości #2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }
    }
}
