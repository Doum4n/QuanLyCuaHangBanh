using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseReleaseNotes_Employees_CreatedByID",
                table: "WarehouseReleaseNotes");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByID",
                table: "WarehouseReleaseNotes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseReleaseNotes_Employees_CreatedByID",
                table: "WarehouseReleaseNotes",
                column: "CreatedByID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseReleaseNotes_Employees_CreatedByID",
                table: "WarehouseReleaseNotes");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByID",
                table: "WarehouseReleaseNotes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseReleaseNotes_Employees_CreatedByID",
                table: "WarehouseReleaseNotes",
                column: "CreatedByID",
                principalTable: "Employees",
                principalColumn: "ID");
        }
    }
}
