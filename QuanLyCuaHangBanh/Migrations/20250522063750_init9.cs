using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "PurchaseInvoiceDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseInvoiceID",
                table: "InvoiceDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_PurchaseInvoiceID",
                table: "InvoiceDetails",
                column: "PurchaseInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_PurchaseInvoices_PurchaseInvoiceID",
                table: "InvoiceDetails",
                column: "PurchaseInvoiceID",
                principalTable: "PurchaseInvoices",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_PurchaseInvoices_PurchaseInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_PurchaseInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseInvoiceID",
                table: "InvoiceDetails");
        }
    }
}
