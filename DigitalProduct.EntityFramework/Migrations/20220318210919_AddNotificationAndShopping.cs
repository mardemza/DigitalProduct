using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalProduct.EntityFramework.Migrations
{
    public partial class AddNotificationAndShopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShoppingId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Msg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoppings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoppings", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shoppings_ShoppingId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Shoppings");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingId",
                table: "Products");
        }
    }
}
