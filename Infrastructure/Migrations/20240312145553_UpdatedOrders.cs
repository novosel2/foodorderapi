using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProductToppings_Orders_OrderId",
                table: "OrderedProductToppings");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProductToppings_OrderId",
                table: "OrderedProductToppings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderedProductToppings");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductToppings_OrderedProductId",
                table: "OrderedProductToppings",
                column: "OrderedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProductToppings_OrderedProducts_OrderedProductId",
                table: "OrderedProductToppings",
                column: "OrderedProductId",
                principalTable: "OrderedProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProductToppings_OrderedProducts_OrderedProductId",
                table: "OrderedProductToppings");

            migrationBuilder.DropIndex(
                name: "IX_OrderedProductToppings_OrderedProductId",
                table: "OrderedProductToppings");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "OrderedProductToppings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductToppings_OrderId",
                table: "OrderedProductToppings",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProductToppings_Orders_OrderId",
                table: "OrderedProductToppings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
