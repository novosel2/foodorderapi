using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Orders_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Orders_OrderId",
                table: "OrderedItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
