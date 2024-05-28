using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MenuMangement.API.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Lunch Menu", 1 },
                    { 2, "Dinner Menu", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MenuId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Homemade Drinks" },
                    { 2, 1, "Guten Morgen!" },
                    { 3, 1, "Getränke" },
                    { 4, 1, "im Brot" },
                    { 5, 1, "aus dem Ofen" },
                    { 6, 1, "für den Anfang" },
                    { 7, 1, "Salate" },
                    { 8, 1, "etwas kleines" },
                    { 9, 1, "aus der Pfanne" },
                    { 10, 1, "mein Grill" },
                    { 11, 1, "Holzkohlengrill" },
                    { 12, 1, "etwas Süßes?" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "LogoUrl", "MenuId", "Name" },
                values: new object[,]
                {
                    { 1, "https://my.menulogy.at/images/logo/client2/Kopie%20von%20Ohne%20Titel%20(900%20x%20128%20px)%20(600%20x%20128%20px)%20(400%20x%20128%20px)%20(1).png", 1, "Sample Restaurant 1" },
                    { 2, "https://my.menulogy.at/images/logo/client2/Kopie%20von%20Ohne%20Titel%20(900%20x%20128%20px)%20(600%20x%20128%20px)%20(400%20x%20128%20px)%20(1).png", 2, "Sample Restaurant 2" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PictureUrl", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Hausgemachte Eistee, grüner Apfel Sirup, Minze", "Eistee Grüner Apfel", "https://my.menulogy.at/images/menu/client2/product-1625749094.png", 4.90m },
                    { 2, 1, "Hausgemachte Eistee, Wassermelone Sirup, Minze", "Eistee Wassermelone", "https://my.menulogy.at/images/menu/client2/product-1647878278.png", 4.90m },
                    { 3, 1, "Hausgemachte Eistee, Maracuja Sirup, Minze", "Eistee Maracuja", "https://my.menulogy.at/images/menu/client2/product-1625749342.png", 4.90m },
                    { 4, 1, "Hausgemachte Eistee, Erdbeer Sirup, Minze", "Eistee Erdbeere", "https://my.menulogy.at/images/menu/client2/product-1625749715.png", 4.90m },
                    { 5, 1, "Hausgemachte Eistee, Waldbeeren Sirup, Minze und Waldbeeren", "Eistee Beerentraum", "https://my.menulogy.at/images/menu/client2/product-1707155060.png", 4.90m },
                    { 6, 1, "Ayran 0,5l 4,90.-\nJoghurt, Wasser und Salz", "Ayran 0,25l", "https://my.menulogy.at/images/menu/client2/product-1625748930.png", 2.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MenuId",
                table: "Categories",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurants",
                column: "MenuId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
