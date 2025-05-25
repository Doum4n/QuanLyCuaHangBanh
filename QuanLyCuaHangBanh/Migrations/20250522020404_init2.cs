using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Products_ProductID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SalesInvoices");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "InvoiceDetails",
                newName: "Product_UnitID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_ProductID",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_Product_UnitID");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "SalesInvoiceDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "SalesInvoiceDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetails_SalesInvoiceID",
                table: "SalesInvoiceDetails",
                column: "SalesInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_ProductUnits_Product_UnitID",
                table: "InvoiceDetails",
                column: "Product_UnitID",
                principalTable: "ProductUnits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_ProductUnits_Product_UnitID",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceDetails_SalesInvoiceID",
                table: "SalesInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "SalesInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "SalesInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "Product_UnitID",
                table: "InvoiceDetails",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetails_Product_UnitID",
                table: "InvoiceDetails",
                newName: "IX_InvoiceDetails_ProductID");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "SalesInvoices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_ProductID",
                table: "InvoiceDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
