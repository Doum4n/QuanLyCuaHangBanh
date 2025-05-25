using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuanLyCuaHangBanh.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerID = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseReleaseNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastModifiedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    LinkedId = table.Column<int>(type: "integer", nullable: false),
                    CreatedByID = table.Column<int>(type: "integer", nullable: true),
                    LastModifiedByID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseReleaseNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WarehouseReleaseNotes_Employees_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WarehouseReleaseNotes_Employees_LastModifiedByID",
                        column: x => x.LastModifiedByID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiptNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastModifiedById = table.Column<int>(type: "integer", nullable: true),
                    LastModifiedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNotes_Employees_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNotes_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    ProducerID = table.Column<int>(type: "integer", nullable: false),
                    ProductionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    BaseUnitID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_BaseUnitID",
                        column: x => x.BaseUnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    SupplierID = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Invoices_ID",
                        column: x => x.ID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
                    CustomerID = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Invoices_ID",
                        column: x => x.ID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    UnitID = table.Column<int>(type: "integer", nullable: false),
                    ProductUnitID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUnits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    UnitID = table.Column<int>(type: "integer", nullable: false),
                    InventoryID = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductUnits_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUnits_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUnits_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false),
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
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetails_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceDetails_InvoiceDetails_ID",
                        column: x => x.ID,
                        principalTable: "InvoiceDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiptNoteDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoodsReceiptNoteId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    ProductUnitId = table.Column<int>(type: "integer", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiptNoteDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNoteDetails_GoodsReceiptNotes_GoodsReceiptNoteId",
                        column: x => x.GoodsReceiptNoteId,
                        principalTable: "GoodsReceiptNotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNoteDetails_ProductUnits_ProductUnitId",
                        column: x => x.ProductUnitId,
                        principalTable: "ProductUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNoteDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiptNoteDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Product_UnitID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductUnits_Product_UnitID",
                        column: x => x.Product_UnitID,
                        principalTable: "ProductUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseReleaseNoteDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehouseReleaseNoteId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Product_UnitID = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseReleaseNoteDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WarehouseReleaseNoteDetails_ProductUnits_Product_UnitID",
                        column: x => x.Product_UnitID,
                        principalTable: "ProductUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseReleaseNoteDetails_WarehouseReleaseNotes_Warehouse~",
                        column: x => x.WarehouseReleaseNoteId,
                        principalTable: "WarehouseReleaseNotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNoteDetails_GoodsReceiptNoteId",
                table: "GoodsReceiptNoteDetails",
                column: "GoodsReceiptNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNoteDetails_ProductId",
                table: "GoodsReceiptNoteDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNoteDetails_ProductUnitId",
                table: "GoodsReceiptNoteDetails",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNoteDetails_UnitId",
                table: "GoodsReceiptNoteDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNotes_LastModifiedById",
                table: "GoodsReceiptNotes",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptNotes_SupplierId",
                table: "GoodsReceiptNotes",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductID",
                table: "Inventories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UnitID",
                table: "Inventories",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceID",
                table: "InvoiceDetails",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductID",
                table: "InvoiceDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeID",
                table: "Invoices",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Product_UnitID",
                table: "OrderDetails",
                column: "Product_UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BaseUnitID",
                table: "Products",
                column: "BaseUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerID",
                table: "Products",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_InventoryID",
                table: "ProductUnits",
                column: "InventoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_ProductID",
                table: "ProductUnits",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_UnitID",
                table: "ProductUnits",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_SupplierID",
                table: "PurchaseInvoices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceDetails_CustomerID",
                table: "SalesInvoiceDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CustomerID",
                table: "SalesInvoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReleaseNoteDetails_Product_UnitID",
                table: "WarehouseReleaseNoteDetails",
                column: "Product_UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReleaseNoteDetails_WarehouseReleaseNoteId",
                table: "WarehouseReleaseNoteDetails",
                column: "WarehouseReleaseNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReleaseNotes_CreatedByID",
                table: "WarehouseReleaseNotes",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseReleaseNotes_LastModifiedByID",
                table: "WarehouseReleaseNotes",
                column: "LastModifiedByID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiptNoteDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceDetails");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "SalesInvoiceDetails");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "WarehouseReleaseNoteDetails");

            migrationBuilder.DropTable(
                name: "GoodsReceiptNotes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "ProductUnits");

            migrationBuilder.DropTable(
                name: "WarehouseReleaseNotes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
