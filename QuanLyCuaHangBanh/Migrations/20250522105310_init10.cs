using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Units_UnitID",
                table: "ProductUnits");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Units_UnitID",
                table: "ProductUnits",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Units_UnitID",
                table: "ProductUnits");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Units_UnitID",
                table: "ProductUnits",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
