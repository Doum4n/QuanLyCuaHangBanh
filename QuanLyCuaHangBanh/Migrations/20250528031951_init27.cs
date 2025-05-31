using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit",
                table: "AccountsPayable");

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "Suppliers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Suppliers");

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "AccountsPayable",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
