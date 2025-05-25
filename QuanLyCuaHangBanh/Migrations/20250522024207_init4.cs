using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceDetails_Customers_CustomerID",
                table: "SalesInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceDetails_CustomerID",
                table: "SalesInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "SalesInvoiceDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "SalesInvoiceDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetails_CustomerID",
                table: "SalesInvoiceDetails",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceDetails_Customers_CustomerID",
                table: "SalesInvoiceDetails",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
