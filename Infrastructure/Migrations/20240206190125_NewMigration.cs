using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsToppings_Products_ProductId",
                table: "ProductsToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsToppings_Toppings_ToppingId",
                table: "ProductsToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsToppings",
                table: "ProductsToppings");

            migrationBuilder.RenameTable(
                name: "ProductsToppings",
                newName: "ToppingsProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsToppings_ToppingId",
                table: "ToppingsProducts",
                newName: "IX_ToppingsProducts_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToppingsProducts",
                table: "ToppingsProducts",
                columns: new[] { "ProductId", "ToppingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToppingsProducts_Products_ProductId",
                table: "ToppingsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToppingsProducts_Toppings_ToppingId",
                table: "ToppingsProducts",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToppingsProducts_Products_ProductId",
                table: "ToppingsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ToppingsProducts_Toppings_ToppingId",
                table: "ToppingsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToppingsProducts",
                table: "ToppingsProducts");

            migrationBuilder.RenameTable(
                name: "ToppingsProducts",
                newName: "ProductsToppings");

            migrationBuilder.RenameIndex(
                name: "IX_ToppingsProducts_ToppingId",
                table: "ProductsToppings",
                newName: "IX_ProductsToppings_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsToppings",
                table: "ProductsToppings",
                columns: new[] { "ProductId", "ToppingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsToppings_Products_ProductId",
                table: "ProductsToppings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsToppings_Toppings_ToppingId",
                table: "ProductsToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
