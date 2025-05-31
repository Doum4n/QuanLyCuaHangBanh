using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SalesInvoiceID",
                table: "Accounts",
                column: "SalesInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_SalesInvoices_SalesInvoiceID",
                table: "Accounts",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_SalesInvoices_SalesInvoiceID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SalesInvoiceID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "Accounts");

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
    }
}
