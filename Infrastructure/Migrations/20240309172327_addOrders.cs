using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    DateTimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedItemToppinngs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItemToppinngs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedItemToppinngs_OrderedItems_OrderedItemId",
                        column: x => x.OrderedItemId,
                        principalTable: "OrderedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItemToppinngs_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ProductId",
                table: "OrderedItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemToppinngs_OrderedItemId",
                table: "OrderedItemToppinngs",
                column: "OrderedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemToppinngs_ToppingId",
                table: "OrderedItemToppinngs",
                column: "ToppingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedItemToppinngs");

            migrationBuilder.DropTable(
                name: "OrderedItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
