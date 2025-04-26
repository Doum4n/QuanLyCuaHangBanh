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
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            tsmi_Products = new ToolStripMenuItem();
            tsmi_Catogories = new ToolStripMenuItem();
            tsmi_Producers = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmi_Customers = new ToolStripMenuItem();
            tsmi_Employees = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmi_Units = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tsmi_Invoices = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem, báoCáoToolStripMenuItem, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmi_Products, tsmi_Catogories, tsmi_Producers, toolStripSeparator1, tsmi_Customers, tsmi_Employees, toolStripSeparator2, tsmi_Units, toolStripSeparator3, tsmi_Invoices });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(73, 24);
            quảnLýToolStripMenuItem.Text = "&Quản lý";
            // 
            // tsmi_Products
            // 
            tsmi_Products.Name = "tsmi_Products";
            tsmi_Products.Size = new Size(224, 26);
            tsmi_Products.Text = "&Sản phẩm";
            tsmi_Products.Click += tsmi_Products_Click;
            // 
            // tsmi_Catogories
            // 
            tsmi_Catogories.Name = "tsmi_Catogories";
            tsmi_Catogories.Size = new Size(224, 26);
            tsmi_Catogories.Text = "&Loại sản phầm";
            // 
            // tsmi_Producers
            // 
            tsmi_Producers.Name = "tsmi_Producers";
            tsmi_Producers.Size = new Size(224, 26);
            tsmi_Producers.Text = "&Hãng sản xuất";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // tsmi_Customers
            // 
            tsmi_Customers.Name = "tsmi_Customers";
            tsmi_Customers.Size = new Size(224, 26);
            tsmi_Customers.Text = "&Khách hàng";
            // 
            // tsmi_Employees
            // 
            tsmi_Employees.Name = "tsmi_Employees";
            tsmi_Employees.Size = new Size(224, 26);
            tsmi_Employees.Text = "&Nhân viên";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // tsmi_Units
            // 
            tsmi_Units.Name = "tsmi_Units";
            tsmi_Units.Size = new Size(224, 26);
            tsmi_Units.Text = "&Đơn vị tính";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(221, 6);
            // 
            // tsmi_Invoices
            // 
            tsmi_Invoices.Name = "tsmi_Invoices";
            tsmi_Invoices.Size = new Size(224, 26);
            tsmi_Invoices.Text = "&Hóa đơn bán hàng";
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(152, 24);
            báoCáoToolStripMenuItem.Text = "&Báo cáo - Thống kê";
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "&Trợ giúp";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainView";
            Text = "Quản lý cửa hàng bánh";
            WindowState = FormWindowState.Maximized;
            Load += MainView_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
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
    }
}
