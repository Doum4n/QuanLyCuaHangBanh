using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class inti32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_PurchaseInvoices_PurchaseInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceDetails");

            migrationBuilder.DropTable(
                name: "SalesInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_PurchaseInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_SalesInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InvoiceDetails",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "InvoiceDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesInvoice_Detail_Note",
                table: "InvoiceDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "InvoiceDetails",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "InvoiceDetails",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "SalesInvoice_Detail_Note",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseInvoiceID",
                table: "InvoiceDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "InvoiceDetails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    UnitCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_InvoiceDetails_ID",
                        column: x => x.ID,
                        principalTable: "InvoiceDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetails_InvoiceDetails_ID",
                        column: x => x.ID,
                        principalTable: "InvoiceDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_PurchaseInvoiceID",
                table: "InvoiceDetails",
                column: "PurchaseInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_SalesInvoiceID",
                table: "InvoiceDetails",
                column: "SalesInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_PurchaseInvoices_PurchaseInvoiceID",
                table: "InvoiceDetails",
                column: "PurchaseInvoiceID",
                principalTable: "PurchaseInvoices",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_SalesInvoices_SalesInvoiceID",
                table: "InvoiceDetails",
                column: "SalesInvoiceID",
                principalTable: "SalesInvoices",
                principalColumn: "ID");
        }
    }
}
