using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JacobRestaurant.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Burgers" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Drinks" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Desserts" });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Very big burger", "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg", "Big Burger", 9.99m },
                    { 2, 1, "Really small burger", "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg", "Small Burger", 5.50m },
                    { 3, 1, "Burger for giga chads", "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg", "Chad Burger", 21.37m },
                    { 4, 1, "Burger for vegans", "https://cdn.pixabay.com/photo/2020/10/05/19/55/hamburger-5630646_960_720.jpg", "Vegan Burger", 28.10m },
                    { 8, 2, "Just coffee", "https://cdn.pixabay.com/photo/2019/01/16/22/37/coffee-3936903_960_720.jpg", "Coffee", 6.99m },
                    { 9, 2, "Just good tea", "https://cdn.pixabay.com/photo/2017/03/01/05/12/tea-cup-2107599_960_720.jpg", "Tea", 6.99m },
                    { 10, 2, "Just water", "https://cdn.pixabay.com/photo/2017/02/02/15/15/bottle-2032980_960_720.jpg", "Water", 3.99m },
                    { 11, 2, "Just Coca-Cola", "https://cdn.pixabay.com/photo/2017/02/25/23/12/coca-cola-2099000_960_720.jpg", "Coca-Cola", 5.99m },
                    { 5, 3, "Italian tiramisu", "https://cdn.pixabay.com/photo/2017/10/28/19/07/tiramisu-2897900_960_720.jpg", "Tiramisu", 8.50m },
                    { 6, 3, "Sweet and cold", "https://cdn.pixabay.com/photo/2018/04/27/10/44/dessert-3354303_960_720.jpg", "Ice-creams", 8.20m },
                    { 7, 3, "It is worth a try", "https://cdn.pixabay.com/photo/2015/09/23/17/01/ice-cream-954101_960_720.jpg", "Granita", 8.10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
