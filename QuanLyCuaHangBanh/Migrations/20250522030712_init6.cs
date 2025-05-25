using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SalesInvoiceID",
                table: "SalesInvoiceDetails",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "SalesInvoiceID",
                table: "SalesInvoiceDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "SalesInvoiceDetails",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
