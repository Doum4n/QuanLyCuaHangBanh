using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
            //    table: "SalesInvoiceDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_SalesInvoiceDetails_SalesInvoiceID",
            //    table: "SalesInvoiceDetails");

            //migrationBuilder.DropColumn(
            //    name: "SalesInvoiceID",
            //    table: "SalesInvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "InvoiceDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_SalesInvoiceID",
                table: "InvoiceDetails",
                column: "SalesInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "InvoiceDetails",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_SalesInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "InvoiceDetails");

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
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID");
        }
    }
}
