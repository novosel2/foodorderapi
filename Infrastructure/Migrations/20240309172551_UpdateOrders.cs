using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemToppinngs_OrderedItems_OrderedItemId",
                table: "OrderedItemToppinngs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemToppinngs_Toppings_ToppingId",
                table: "OrderedItemToppinngs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItemToppinngs",
                table: "OrderedItemToppinngs");

            migrationBuilder.RenameTable(
                name: "OrderedItemToppinngs",
                newName: "OrderedItemToppings");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItemToppinngs_ToppingId",
                table: "OrderedItemToppings",
                newName: "IX_OrderedItemToppings_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItemToppinngs_OrderedItemId",
                table: "OrderedItemToppings",
                newName: "IX_OrderedItemToppings_OrderedItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItemToppings",
                table: "OrderedItemToppings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemToppings_OrderedItems_OrderedItemId",
                table: "OrderedItemToppings",
                column: "OrderedItemId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemToppings_Toppings_ToppingId",
                table: "OrderedItemToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemToppings_OrderedItems_OrderedItemId",
                table: "OrderedItemToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemToppings_Toppings_ToppingId",
                table: "OrderedItemToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItemToppings",
                table: "OrderedItemToppings");

            migrationBuilder.RenameTable(
                name: "OrderedItemToppings",
                newName: "OrderedItemToppinngs");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItemToppings_ToppingId",
                table: "OrderedItemToppinngs",
                newName: "IX_OrderedItemToppinngs_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItemToppings_OrderedItemId",
                table: "OrderedItemToppinngs",
                newName: "IX_OrderedItemToppinngs_OrderedItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItemToppinngs",
                table: "OrderedItemToppinngs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemToppinngs_OrderedItems_OrderedItemId",
                table: "OrderedItemToppinngs",
                column: "OrderedItemId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemToppinngs_Toppings_ToppingId",
                table: "OrderedItemToppinngs",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
