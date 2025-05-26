using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPayables_Invoices_InvoiceID",
                table: "AccountsPayables");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPayables_Suppliers_SupplierID",
                table: "AccountsPayables");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsReceivables_Customers_CustomerID",
                table: "AccountsReceivables");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsReceivables_Invoices_InvoiceID",
                table: "AccountsReceivables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsReceivables",
                table: "AccountsReceivables");

            migrationBuilder.DropIndex(
                name: "IX_AccountsReceivables_InvoiceID",
                table: "AccountsReceivables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsPayables",
                table: "AccountsPayables");

            migrationBuilder.DropIndex(
                name: "IX_AccountsPayables_InvoiceID",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "AccountsReceivables");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "AccountsPayables");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "AccountsPayables");

            migrationBuilder.RenameTable(
                name: "AccountsReceivables",
                newName: "AccountsReceivable");

            migrationBuilder.RenameTable(
                name: "AccountsPayables",
                newName: "AccountsPayable");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsReceivables_CustomerID",
                table: "AccountsReceivable",
                newName: "IX_AccountsReceivable_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsPayables_SupplierID",
                table: "AccountsPayable",
                newName: "IX_AccountsPayable_SupplierID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "AccountsReceivable",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "AccountsPayable",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsReceivable",
                table: "AccountsReceivable",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsPayable",
                table: "AccountsPayable",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    InvoiceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InvoiceID",
                table: "Accounts",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPayable_Accounts_ID",
                table: "AccountsPayable",
                column: "ID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPayable_Suppliers_SupplierID",
                table: "AccountsPayable",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsReceivable_Accounts_ID",
                table: "AccountsReceivable",
                column: "ID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsReceivable_Customers_CustomerID",
                table: "AccountsReceivable",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPayable_Accounts_ID",
                table: "AccountsPayable");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsPayable_Suppliers_SupplierID",
                table: "AccountsPayable");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsReceivable_Accounts_ID",
                table: "AccountsReceivable");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsReceivable_Customers_CustomerID",
                table: "AccountsReceivable");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsReceivable",
                table: "AccountsReceivable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountsPayable",
                table: "AccountsPayable");

            migrationBuilder.RenameTable(
                name: "AccountsReceivable",
                newName: "AccountsReceivables");

            migrationBuilder.RenameTable(
                name: "AccountsPayable",
                newName: "AccountsPayables");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsReceivable_CustomerID",
                table: "AccountsReceivables",
                newName: "IX_AccountsReceivables_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountsPayable_SupplierID",
                table: "AccountsPayables",
                newName: "IX_AccountsPayables_SupplierID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "AccountsReceivables",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "AccountsReceivables",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "AccountsReceivables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "AccountsReceivables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "AccountsReceivables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "AccountsReceivables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "AccountsReceivables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "AccountsReceivables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "AccountsPayables",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "AccountsPayables",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "AccountsPayables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "AccountsPayables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "AccountsPayables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "AccountsPayables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "AccountsPayables",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "AccountsPayables",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsReceivables",
                table: "AccountsReceivables",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountsPayables",
                table: "AccountsPayables",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivables_InvoiceID",
                table: "AccountsReceivables",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsPayables_InvoiceID",
                table: "AccountsPayables",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPayables_Invoices_InvoiceID",
                table: "AccountsPayables",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsPayables_Suppliers_SupplierID",
                table: "AccountsPayables",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsReceivables_Customers_CustomerID",
                table: "AccountsReceivables",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsReceivables_Invoices_InvoiceID",
                table: "AccountsReceivables",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
