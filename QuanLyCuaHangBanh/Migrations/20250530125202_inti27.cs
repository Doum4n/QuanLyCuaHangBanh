using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class inti27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "AccountsReceivable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivable_SalesInvoiceID",
                table: "AccountsReceivable",
                column: "SalesInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsReceivable_SalesInvoices_SalesInvoiceID",
                table: "AccountsReceivable",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsReceivable_SalesInvoices_SalesInvoiceID",
                table: "AccountsReceivable");

            migrationBuilder.DropIndex(
                name: "IX_AccountsReceivable_SalesInvoiceID",
                table: "AccountsReceivable");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "AccountsReceivable");
        }
    }
}
