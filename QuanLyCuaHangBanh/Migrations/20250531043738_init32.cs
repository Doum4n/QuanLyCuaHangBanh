using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_SalesInvoices_SalesInvoiceID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AppLogs");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SalesInvoiceID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceID",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesInvoiceID",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Application = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogs", x => x.Id);
                });

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
    }
}
