using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Inventories_InventoryID",
                table: "ProductUnits");

            migrationBuilder.DropIndex(
                name: "IX_ProductUnits_InventoryID",
                table: "ProductUnits");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "ProductUnits");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductUnitID",
                table: "Inventories",
                column: "ProductUnitID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_ProductUnits_ProductUnitID",
                table: "Inventories",
                column: "ProductUnitID",
                principalTable: "ProductUnits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_ProductUnits_ProductUnitID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductUnitID",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "ProductUnits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_InventoryID",
                table: "ProductUnits",
                column: "InventoryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Inventories_InventoryID",
                table: "ProductUnits",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
