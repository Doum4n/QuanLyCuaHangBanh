namespace QuanLyCuaHangBanh
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            tsmi_Login = new ToolStripMenuItem();
            tsmi_Logout = new ToolStripMenuItem();
            stmi_ChangePassword = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            tsmi_Exit = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            tsmi_Products = new ToolStripMenuItem();
            tsmi_Catogories = new ToolStripMenuItem();
            stmi_Manufacturers = new ToolStripMenuItem();
            tsmi_Producers = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            tsmi_WarehouseNotes = new ToolStripMenuItem();
            tsmi_PurchaseReceipts = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmi_Customers = new ToolStripMenuItem();
            tsmi_Employees = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmi_Units = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmi_Invoices = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            tsmi_Order = new ToolStripMenuItem();
            tsmi_Statistical = new ToolStripMenuItem();
            tsmi_ReportProduct = new ToolStripMenuItem();
            tsmi_RevenueStatistics = new ToolStripMenuItem();
            tsmi_ImportWarehouse = new ToolStripMenuItem();
            tsmi_ExportWarehouse = new ToolStripMenuItem();
            stmi_OrderStatistics = new ToolStripMenuItem();
            tsmi_InventoryStatistical = new ToolStripMenuItem();
            tsmi_AccountsPayable = new ToolStripMenuItem();
            tsmi_AccountsReceiable = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            thôngTinPhầnMềmToolStripMenuItem = new ToolStripMenuItem();
            hướngDẫnSửDụngToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tsslb_EmployeeName = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem, tsmi_Statistical, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_Login, tsmi_Logout, stmi_ChangePassword, toolStripSeparator6, tsmi_Exit });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // tsmi_Login
            // 
            tsmi_Login.Image = Properties.Resources.dang_nhap;
            tsmi_Login.Name = "tsmi_Login";
            tsmi_Login.Size = new Size(183, 26);
            tsmi_Login.Text = "Đăng &nhập...";
            tsmi_Login.Click += tsmi_Login_Click;
            // 
            // tsmi_Logout
            // 
            tsmi_Logout.Image = Properties.Resources.dang_xuat;
            tsmi_Logout.Name = "tsmi_Logout";
            tsmi_Logout.Size = new Size(183, 26);
            tsmi_Logout.Text = "Đăng &xuất";
            tsmi_Logout.Click += tsmi_Logout_Click;
            // 
            // stmi_ChangePassword
            // 
            stmi_ChangePassword.Image = Properties.Resources.doi_mat_khau;
            stmi_ChangePassword.Name = "stmi_ChangePassword";
            stmi_ChangePassword.Size = new Size(183, 26);
            stmi_ChangePassword.Text = "&Đổi mật khẩu";
            stmi_ChangePassword.Click += stmi_ChangePassword_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(180, 6);
            // 
            // tsmi_Exit
            // 
            tsmi_Exit.Image = Properties.Resources.thoat;
            tsmi_Exit.Name = "tsmi_Exit";
            tsmi_Exit.ShortcutKeys = Keys.Alt | Keys.F4;
            tsmi_Exit.Size = new Size(183, 26);
            tsmi_Exit.Text = "&Thoát";
            tsmi_Exit.Click += tsmi_Exit_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_Products, tsmi_Catogories, stmi_Manufacturers, tsmi_Producers, toolStripSeparator4, tsmi_WarehouseNotes, tsmi_PurchaseReceipts, toolStripSeparator1, tsmi_Customers, tsmi_Employees, toolStripSeparator2, tsmi_Units, toolStripSeparator3, tsmi_Invoices, toolStripSeparator5, tsmi_Order });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(73, 24);
            quảnLýToolStripMenuItem.Text = "&Quản lý";
            // 
            // tsmi_Products
            // 
            tsmi_Products.Name = "tsmi_Products";
            tsmi_Products.Size = new Size(188, 26);
            tsmi_Products.Text = "&Sản phẩm";
            tsmi_Products.Click += tsmi_Products_Click;
            // 
            // tsmi_Catogories
            // 
            tsmi_Catogories.Name = "tsmi_Catogories";
            tsmi_Catogories.Size = new Size(188, 26);
            tsmi_Catogories.Text = "&Loại sản phầm";
            tsmi_Catogories.Click += tsmi_Catogories_Click;
            // 
            // stmi_Manufacturers
            // 
            stmi_Manufacturers.Name = "stmi_Manufacturers";
            stmi_Manufacturers.Size = new Size(188, 26);
            stmi_Manufacturers.Text = "Hãng &sản xuất";
            stmi_Manufacturers.Click += stmi_Manufacturers_Click;
            // 
            // tsmi_Producers
            // 
            tsmi_Producers.Name = "tsmi_Producers";
            tsmi_Producers.Size = new Size(188, 26);
            tsmi_Producers.Text = "&Nhà cung cấp";
            tsmi_Producers.Click += tsmi_Producers_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(185, 6);
            // 
            // tsmi_WarehouseNotes
            // 
            tsmi_WarehouseNotes.Name = "tsmi_WarehouseNotes";
            tsmi_WarehouseNotes.Size = new Size(188, 26);
            tsmi_WarehouseNotes.Text = "Phiếu xuất";
            tsmi_WarehouseNotes.Click += tsmi_WarehouseNotes_Click;
            // 
            // tsmi_PurchaseReceipts
            // 
            tsmi_PurchaseReceipts.Name = "tsmi_PurchaseReceipts";
            tsmi_PurchaseReceipts.Size = new Size(188, 26);
            tsmi_PurchaseReceipts.Text = "&Phiếu nhập";
            tsmi_PurchaseReceipts.Click += tsmi_PurchaseReceipts_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(185, 6);
            // 
            // tsmi_Customers
            // 
            tsmi_Customers.Name = "tsmi_Customers";
            tsmi_Customers.Size = new Size(188, 26);
            tsmi_Customers.Text = "&Khách hàng";
            tsmi_Customers.Click += tsmi_Customers_Click;
            // 
            // tsmi_Employees
            // 
            tsmi_Employees.Name = "tsmi_Employees";
            tsmi_Employees.Size = new Size(188, 26);
            tsmi_Employees.Text = "&Nhân viên";
            tsmi_Employees.Click += tsmi_Employees_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(185, 6);
            // 
            // tsmi_Units
            // 
            tsmi_Units.Name = "tsmi_Units";
            tsmi_Units.Size = new Size(188, 26);
            tsmi_Units.Text = "&Đơn vị tính";
            tsmi_Units.Click += tsmi_Units_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(185, 6);
            // 
            // tsmi_Invoices
            // 
            tsmi_Invoices.Name = "tsmi_Invoices";
            tsmi_Invoices.Size = new Size(188, 26);
            tsmi_Invoices.Text = "&Hóa đơn";
            tsmi_Invoices.Click += tsmi_Invoices_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(185, 6);
            // 
            // tsmi_Order
            // 
            tsmi_Order.Name = "tsmi_Order";
            tsmi_Order.Size = new Size(188, 26);
            tsmi_Order.Text = "Đơn hàng";
            tsmi_Order.Click += tsmi_Order_Click;
            // 
            // tsmi_Statistical
            // 
            tsmi_Statistical.DropDownItems.AddRange(new ToolStripItem[] { tsmi_ReportProduct, tsmi_RevenueStatistics, tsmi_ImportWarehouse, tsmi_ExportWarehouse, stmi_OrderStatistics, tsmi_InventoryStatistical, tsmi_AccountsPayable, tsmi_AccountsReceiable });
            tsmi_Statistical.Name = "tsmi_Statistical";
            tsmi_Statistical.Size = new Size(152, 24);
            tsmi_Statistical.Text = "&Báo cáo - Thống kê";
            // 
            // tsmi_ReportProduct
            // 
            tsmi_ReportProduct.Name = "tsmi_ReportProduct";
            tsmi_ReportProduct.Size = new Size(269, 26);
            tsmi_ReportProduct.Text = "Thống kê sản phẩm";
            tsmi_ReportProduct.Click += tsmi_ReportProduct_Click;
            // 
            // tsmi_RevenueStatistics
            // 
            tsmi_RevenueStatistics.Name = "tsmi_RevenueStatistics";
            tsmi_RevenueStatistics.Size = new Size(269, 26);
            tsmi_RevenueStatistics.Text = "Thống kê doanh thu";
            tsmi_RevenueStatistics.Click += tsmi_RevenueStatistics_Click;
            // 
            // tsmi_ImportWarehouse
            // 
            tsmi_ImportWarehouse.Name = "tsmi_ImportWarehouse";
            tsmi_ImportWarehouse.Size = new Size(269, 26);
            tsmi_ImportWarehouse.Text = "Thống kê nhập kho";
            tsmi_ImportWarehouse.Click += tsmi_ImportWarehouse_Click;
            // 
            // tsmi_ExportWarehouse
            // 
            tsmi_ExportWarehouse.Name = "tsmi_ExportWarehouse";
            tsmi_ExportWarehouse.Size = new Size(269, 26);
            tsmi_ExportWarehouse.Text = "Thống kê xuất kho";
            tsmi_ExportWarehouse.Click += tsmi_ExportWarehouse_Click;
            // 
            // stmi_OrderStatistics
            // 
            stmi_OrderStatistics.Name = "stmi_OrderStatistics";
            stmi_OrderStatistics.Size = new Size(269, 26);
            stmi_OrderStatistics.Text = "Thống kê đơn hàng";
            stmi_OrderStatistics.Click += stmi_OrderStatistics_Click;
            // 
            // tsmi_InventoryStatistical
            // 
            tsmi_InventoryStatistical.Name = "tsmi_InventoryStatistical";
            tsmi_InventoryStatistical.Size = new Size(269, 26);
            tsmi_InventoryStatistical.Text = "Thống kê tồn kho";
            tsmi_InventoryStatistical.Click += tsmi_InventoryStatistical_Click;
            // 
            // tsmi_AccountsPayable
            // 
            tsmi_AccountsPayable.Name = "tsmi_AccountsPayable";
            tsmi_AccountsPayable.Size = new Size(269, 26);
            tsmi_AccountsPayable.Text = "Thống kê công nợ phải trả";
            tsmi_AccountsPayable.Click += tsmi_AccountsPayable_Click;
            // 
            // tsmi_AccountsReceiable
            // 
            tsmi_AccountsReceiable.Name = "tsmi_AccountsReceiable";
            tsmi_AccountsReceiable.Size = new Size(269, 26);
            tsmi_AccountsReceiable.Text = "Thống kê công nợ phải thu";
            tsmi_AccountsReceiable.Click += tsmi_AccountsReceiable_Click;
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinPhầnMềmToolStripMenuItem, hướngDẫnSửDụngToolStripMenuItem });
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // thôngTinPhầnMềmToolStripMenuItem
            // 
            thôngTinPhầnMềmToolStripMenuItem.Name = "thôngTinPhầnMềmToolStripMenuItem";
            thôngTinPhầnMềmToolStripMenuItem.Size = new Size(277, 26);
            thôngTinPhầnMềmToolStripMenuItem.Text = "Thông tin &phần mềm";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            hướngDẫnSửDụngToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F1;
            hướngDẫnSửDụngToolStripMenuItem.Size = new Size(277, 26);
            hướngDẫnSửDụngToolStripMenuItem.Text = "&Hướng dẫn sử dụng";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslb_EmployeeName, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 462);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslb_EmployeeName
            // 
            tsslb_EmployeeName.Name = "tsslb_EmployeeName";
            tsslb_EmployeeName.Size = new Size(628, 20);
            tsslb_EmployeeName.Spring = true;
            tsslb_EmployeeName.Text = " Chưa đăng nhập";
            tsslb_EmployeeName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.IsLink = true;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(157, 20);
            toolStripStatusLabel2.Text = "@ Khoa CNTT - ĐHAG";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 488);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainView";
            Text = "Quản lý cửa hàng bánh";
            WindowState = FormWindowState.Maximized;
            FormClosed += MainView_FormClosed;
            Load += MainView_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem tsmi_Statistical;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem tsmi_Products;
        private ToolStripMenuItem tsmi_Catogories;
        private ToolStripMenuItem tsmi_Producers;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmi_Customers;
        private ToolStripMenuItem tsmi_Employees;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmi_Units;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsmi_Invoices;
        private ToolStripMenuItem tsmi_PurchaseReceipts;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem tsmi_WarehouseNotes;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem tsmi_Order;
        private ToolStripMenuItem tsmi_ReportProduct;
        private ToolStripMenuItem tsmi_RevenueStatistics;
        private ToolStripMenuItem tsmi_ImportWarehouse;
        private ToolStripMenuItem tsmi_ExportWarehouse;
        private ToolStripMenuItem stmi_OrderStatistics;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslb_EmployeeName;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem tsmi_Login;
        private ToolStripMenuItem stmi_Manufacturers;
        private ToolStripMenuItem tsmi_Logout;
        private ToolStripMenuItem stmi_ChangePassword;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem tsmi_Exit;
        private ToolStripMenuItem tsmi_InventoryStatistical;
        private ToolStripMenuItem thôngTinPhầnMềmToolStripMenuItem;
        private ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private ToolStripMenuItem tsmi_AccountsPayable;
        private ToolStripMenuItem tsmi_AccountsReceiable;
    }
}
