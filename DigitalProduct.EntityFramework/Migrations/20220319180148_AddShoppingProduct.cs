using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalProduct.EntityFramework.Migrations
{
    public partial class AddShoppingProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shoppings_ShoppingId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ShoppingProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    ShoppingId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingProducts_Shoppings_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shoppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingProducts_ProductId",
                table: "ShoppingProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingProducts_ShoppingId",
                table: "ShoppingProducts",
                column: "ShoppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingProducts");

            migrationBuilder.AddColumn<long>(
                name: "ShoppingId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingId",
                table: "Products",
                column: "ShoppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shoppings_ShoppingId",
                table: "Products",
                column: "ShoppingId",
                principalTable: "Shoppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
