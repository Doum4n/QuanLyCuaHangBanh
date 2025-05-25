using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Units_UnitID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_UnitID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "Inventories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UnitID",
                table: "Inventories",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Units_UnitID",
                table: "Inventories",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
