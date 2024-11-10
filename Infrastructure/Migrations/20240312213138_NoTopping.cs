using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NoTopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Products_ProductId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_ProductId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Toppings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Toppings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_ProductId",
                table: "Toppings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Products_ProductId",
                table: "Toppings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
