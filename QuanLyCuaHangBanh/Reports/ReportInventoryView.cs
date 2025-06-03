using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Uitls;
using System.Data;

namespace QuanLyCuaHangBanh.Reports
{
    public partial class ReportInventoryView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.InventoriesDataTable inventoriesDataTable = new QLCHBDataSet.InventoriesDataTable();

        public ReportInventoryView()
        {
            InitializeComponent();
            this.Load += ReportInventoryView_Load;
        }

        private void ReportInventoryView_Load(object sender, EventArgs e)
        {
            // Load data for the combo boxes
            var products = context.Products
                .AsNoTracking()
                .Select(p => new { p.ID, p.Name })
                .ToList();

            cbb_Products.DataSource = products;
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            var categories = context.Categories
                .AsNoTracking()
                .Select(c => new { c.ID, c.Name })
                .ToList();
            cbb_Categories.DataSource = categories;
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";

            var suppliers = context.Suppliers.AsNoTracking().Select(o => new { o.ID, o.Name }).ToList();
            cbb_Suppliers.DataSource = suppliers;
            cbb_Suppliers.DisplayMember = "Name";
            cbb_Suppliers.ValueMember = "ID";

            var manufacturers = context.Manufacturers
                .AsNoTracking()
                .Select(m => new { m.ID, m.Name })
                .ToList();
            cbb_Manufacturers.DataSource = manufacturers;
            cbb_Manufacturers.DisplayMember = "Name";
            cbb_Manufacturers.ValueMember = "ID";

            var inventoryItems = context.Inventories
                .AsNoTracking()
                .Include(o => o.GoodsReceiptNoteDetail)
                .Include(i => i.ProductUnit)
                .ThenInclude(i => i.Product)
                .Select(i => new InventoryItem
                {
                    ID = i.ID,
                    ProductName = i.ProductUnit.Product.Name,
                    CategoryName = i.ProductUnit.Product.Category.Name,
                    UnitName = i.ProductUnit.Unit.Name,
                    SupplierName = i.ProductUnit.Product.Producer.Name,
                    ManufacturerName = i.ProductUnit.Product.Manufacturer.Name,
                    ProductionDate = i.GoodsReceiptNoteDetail.ProductionDate.ToString(),
                    ExpirationDate = i.GoodsReceiptNoteDetail.ExpirationDate.ToString(),
                    ConversionRate = i.ProductUnit.ConversionRate,
                    Quantity = i.Quantity
                }).Cast<Object>()
                .ToList();

            LoadData(inventoryItems);
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            // 1. Lấy ID từ SelectedValue (an toàn và hiệu quả hơn)
            int? selectedProductId = cbb_Products.SelectedValue as int?;
            int? selectedCategoryId = cbb_Categories.SelectedValue as int?;
            int? selectedSupplierId = cbb_Suppliers.SelectedValue as int?;
            int? selectedManufacturerId = cbb_Manufacturers.SelectedValue as int?;

            // Khai báo biến inventoryItemsQuery là IQueryable<Inventory>
            // Điều này cho phép bạn gán lại kết quả của .Where() mà không gặp lỗi kiểu
            IQueryable<QuanLyCuaHangBanh.Models.Inventory> inventoryItemsQuery = context.Inventories
                .AsNoTracking() // Luôn dùng AsNoTracking cho các truy vấn chỉ đọc
                                // Áp dụng TẤT CẢ các Include trước khi áp dụng Where clauses
                .Include(i => i.ProductUnit)
                    .ThenInclude(pu => pu.Product)
                        .ThenInclude(p => p.Category)
                .Include(i => i.ProductUnit)
                    .ThenInclude(pu => pu.Unit)
                .Include(i => i.ProductUnit)
                    .ThenInclude(pu => pu.Product)
                        .ThenInclude(p => p.Producer)
                .Include(i => i.ProductUnit)
                    .ThenInclude(pu => pu.Product)
                        .ThenInclude(p => p.Manufacturer);

            // 2. Áp dụng các điều kiện lọc sau khi đã Include tất cả
            if (selectedProductId.HasValue && cb_Product.Checked)
            {
                inventoryItemsQuery = inventoryItemsQuery.Where(i => i.ProductUnit.ProductID == selectedProductId.Value);
            }
            if (selectedCategoryId.HasValue && cb_Category.Checked)
            {
                inventoryItemsQuery = inventoryItemsQuery.Where(i => i.ProductUnit.Product.CategoryID == selectedCategoryId.Value);
            }
            if (selectedSupplierId.HasValue && cb_Supplier.Checked)
            {
                // Đảm bảo Product.ProducerID tồn tại và là FK đến Supplier
                inventoryItemsQuery = inventoryItemsQuery.Where(i => i.ProductUnit.Product.ProducerID == selectedSupplierId.Value);
            }
            if (selectedManufacturerId.HasValue && cb_Manufacterer.Checked)
            {
                // Đảm bảo Product.ManufacturerID tồn tại và là FK đến Manufacturer
                inventoryItemsQuery = inventoryItemsQuery.Where(i => i.ProductUnit.Product.ManufacturerID == selectedManufacturerId.Value);
            }

            // 3. Thực hiện Select và ToList() sau tất cả các điều kiện lọc và Include
            var inventoryItems = inventoryItemsQuery
                .Select(i => new InventoryItem
                {
                    ID = i.ID,
                    ProductName = i.ProductUnit.Product.Name,
                    CategoryName = i.ProductUnit.Product.Category.Name,
                    UnitName = i.ProductUnit.Unit.Name,
                    SupplierName = i.ProductUnit.Product.Producer.Name,
                    ManufacturerName = i.ProductUnit.Product.Manufacturer.Name,
                    ProductionDate = i.GoodsReceiptNoteDetail.ProductionDate.ToString("dd/MM/yyyy"),
                    ExpirationDate = i.GoodsReceiptNoteDetail.ExpirationDate.ToString("dd/MM/yyyy"),
                    ConversionRate = i.ProductUnit.ConversionRate,
                    Quantity = i.Quantity
                }).Cast<Object>()
                .ToList();

            LoadData(inventoryItems);
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            ReportInventoryView_Load(sender, e);
        }

        private void cbb_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show all products in the selected category
            var selectedCategory = cbb_Categories.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedCategory)) return;
            cbb_Products.Items.Clear();
            var products = context.Products
                .Where(p => p.Category.Name == selectedCategory)
                .Select(p => p.Name)
                .ToList();
            cbb_Products.DataSource = products;
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";
        }

        private void LoadData(List<Object> objectss)
        {
            ReportHanler.LoadData(
                reportViewer1,
                objectss,
                inventoriesDataTable,
                "rptInventory.rdlc",
                "dsInventories",
                (row, entity) =>
                {
                    row["ID"] = ((InventoryItem)entity).ID;
                    row["ProductName"] = ((InventoryItem)entity).ProductName;
                    row["CategoryName"] = ((InventoryItem)entity).CategoryName;
                    row["UnitName"] = ((InventoryItem)entity).UnitName;
                    row["SupplierName"] = ((InventoryItem)entity).SupplierName;
                    row["ManufacturerName"] = ((InventoryItem)entity).ManufacturerName;
                    row["ProductionDate"] = ((InventoryItem)entity).ProductionDate;
                    row["ExpirationDate"] = ((InventoryItem)entity).ExpirationDate;
                    row["Quantity"] = ((InventoryItem)entity).Quantity;
                    row["ConversionRate"] = ((InventoryItem)entity).ConversionRate;
                }
            );
        }

        private void cbb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_Suppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show all products from the selected supplier
            var selectedSupplier = cbb_Suppliers.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedSupplier)) return;
            cbb_Products.Items.Clear();
            var products = context.Products
                .Where(p => p.Producer.Name == selectedSupplier)
                .Select(p => p.Name)
                .ToList();
            cbb_Products.DataSource = products;
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";
        }

        private void cbb_Manufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show all products from the selected manufacturer
            var selectedManufacturer = cbb_Manufacturers.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedManufacturer)) return;
            cbb_Products.Items.Clear();
            var products = context.Products
                .Where(p => p.Manufacturer.Name == selectedManufacturer)
                .Select(p => p.Name)
                .ToList();
            cbb_Products.DataSource = products;
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    public class InventoryItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductionDate { get; set; }
        public string ExpirationDate { get; set; }
        public decimal ConversionRate { get; set; }
        public int Quantity { get; set; }
    }
}
