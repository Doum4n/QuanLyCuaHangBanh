using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "GoodsReceiptNoteDetailID",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "GoodsReceiptNoteDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ProductionDate",
                table: "GoodsReceiptNoteDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_GoodsReceiptNoteDetailID",
                table: "Inventories",
                column: "GoodsReceiptNoteDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_GoodsReceiptNoteDetails_GoodsReceiptNoteDetailID",
                table: "Inventories",
                column: "GoodsReceiptNoteDetailID",
                principalTable: "GoodsReceiptNoteDetails",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_GoodsReceiptNoteDetails_GoodsReceiptNoteDetailID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_GoodsReceiptNoteDetailID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "GoodsReceiptNoteDetailID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "GoodsReceiptNoteDetails");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "GoodsReceiptNoteDetails");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpirationDate",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ProductionDate",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
