namespace QuanLyCuaHangBanh.Reports
{
    partial class ReportInventoryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            cb_Manufacterer = new CheckBox();
            cb_Supplier = new CheckBox();
            cb_Product = new CheckBox();
            cb_Category = new CheckBox();
            cbb_Products = new ComboBox();
            label3 = new Label();
            cbb_Categories = new ComboBox();
            cbb_Manufacturers = new ComboBox();
            label1 = new Label();
            cbb_Suppliers = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            btn_ShowAll = new MaterialSkin.Controls.MaterialButton();
            btn_Filter = new MaterialSkin.Controls.MaterialButton();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 122);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(cb_Manufacterer);
            groupBox1.Controls.Add(cb_Supplier);
            groupBox1.Controls.Add(cb_Product);
            groupBox1.Controls.Add(cb_Category);
            groupBox1.Controls.Add(cbb_Products);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbb_Categories);
            groupBox1.Controls.Add(cbb_Manufacturers);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbb_Suppliers);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(855, 104);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // cb_Manufacterer
            // 
            cb_Manufacterer.Anchor = AnchorStyles.Top;
            cb_Manufacterer.AutoSize = true;
            cb_Manufacterer.Location = new Point(639, 61);
            cb_Manufacterer.Name = "cb_Manufacterer";
            cb_Manufacterer.Size = new Size(18, 17);
            cb_Manufacterer.TabIndex = 11;
            cb_Manufacterer.UseVisualStyleBackColor = true;
            // 
            // cb_Supplier
            // 
            cb_Supplier.Anchor = AnchorStyles.Top;
            cb_Supplier.AutoSize = true;
            cb_Supplier.Location = new Point(435, 61);
            cb_Supplier.Name = "cb_Supplier";
            cb_Supplier.Size = new Size(18, 17);
            cb_Supplier.TabIndex = 10;
            cb_Supplier.UseVisualStyleBackColor = true;
            // 
            // cb_Product
            // 
            cb_Product.Anchor = AnchorStyles.Top;
            cb_Product.AutoSize = true;
            cb_Product.Location = new Point(234, 61);
            cb_Product.Name = "cb_Product";
            cb_Product.Size = new Size(18, 17);
            cb_Product.TabIndex = 9;
            cb_Product.UseVisualStyleBackColor = true;
            cb_Product.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // cb_Category
            // 
            cb_Category.Anchor = AnchorStyles.Top;
            cb_Category.AutoSize = true;
            cb_Category.Location = new Point(39, 61);
            cb_Category.Name = "cb_Category";
            cb_Category.Size = new Size(18, 17);
            cb_Category.TabIndex = 8;
            cb_Category.UseVisualStyleBackColor = true;
            // 
            // cbb_Products
            // 
            cbb_Products.Anchor = AnchorStyles.Top;
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(258, 55);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(151, 28);
            cbb_Products.TabIndex = 0;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(459, 32);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 5;
            label3.Text = "Nhà cung cấp";
            label3.Click += label3_Click;
            // 
            // cbb_Categories
            // 
            cbb_Categories.Anchor = AnchorStyles.Top;
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(64, 55);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(151, 28);
            cbb_Categories.TabIndex = 1;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // cbb_Manufacturers
            // 
            cbb_Manufacturers.Anchor = AnchorStyles.Top;
            cbb_Manufacturers.FormattingEnabled = true;
            cbb_Manufacturers.Location = new Point(663, 55);
            cbb_Manufacturers.Name = "cbb_Manufacturers";
            cbb_Manufacturers.Size = new Size(151, 28);
            cbb_Manufacturers.TabIndex = 6;
            cbb_Manufacturers.SelectedIndexChanged += cbb_Manufacturers_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(258, 32);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 2;
            label1.Text = "Tên sản phẩm";
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.Anchor = AnchorStyles.Top;
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(459, 55);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(151, 28);
            cbb_Suppliers.TabIndex = 4;
            cbb_Suppliers.SelectedIndexChanged += cbb_Suppliers_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(64, 32);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 3;
            label2.Text = "Loại sản phẩm";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(663, 32);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 7;
            label4.Text = "Hãng sản xuất";
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_ShowAll);
            panel2.Controls.Add(btn_Filter);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 53);
            panel2.TabIndex = 1;
            // 
            // btn_ShowAll
            // 
            btn_ShowAll.Anchor = AnchorStyles.None;
            btn_ShowAll.AutoSize = false;
            btn_ShowAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_ShowAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_ShowAll.Depth = 0;
            btn_ShowAll.HighEmphasis = true;
            btn_ShowAll.Icon = null;
            btn_ShowAll.Location = new Point(437, 7);
            btn_ShowAll.Margin = new Padding(4, 6, 4, 6);
            btn_ShowAll.MouseState = MaterialSkin.MouseState.HOVER;
            btn_ShowAll.Name = "btn_ShowAll";
            btn_ShowAll.NoAccentTextColor = Color.Empty;
            btn_ShowAll.Size = new Size(125, 39);
            btn_ShowAll.TabIndex = 1;
            btn_ShowAll.Text = "Hiện tất cả";
            btn_ShowAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_ShowAll.UseAccentColor = false;
            btn_ShowAll.UseVisualStyleBackColor = true;
            btn_ShowAll.Click += btn_ShowAll_Click;
            // 
            // btn_Filter
            // 
            btn_Filter.Anchor = AnchorStyles.None;
            btn_Filter.AutoSize = false;
            btn_Filter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Filter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Filter.Depth = 0;
            btn_Filter.HighEmphasis = true;
            btn_Filter.Icon = null;
            btn_Filter.Location = new Point(293, 7);
            btn_Filter.Margin = new Padding(4, 6, 4, 6);
            btn_Filter.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Filter.Name = "btn_Filter";
            btn_Filter.NoAccentTextColor = Color.Empty;
            btn_Filter.Size = new Size(125, 39);
            btn_Filter.TabIndex = 0;
            btn_Filter.Text = "Lọc kết quả";
            btn_Filter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Filter.UseAccentColor = false;
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 175);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(855, 275);
            reportViewer1.TabIndex = 0;
            // 
            // ReportInventoryView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 450);
            Controls.Add(reportViewer1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ReportInventoryView";
            Text = "ReportInventoryView";
            Load += ReportInventoryView_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ComboBox cbb_Categories;
        private ComboBox cbb_Products;
        private Label label3;
        private ComboBox cbb_Suppliers;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cbb_Manufacturers;
        private Label label4;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialButton btn_ShowAll;
        private MaterialSkin.Controls.MaterialButton btn_Filter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CheckBox cb_Category;
        private CheckBox cb_Product;
        private CheckBox cb_Manufacterer;
        private CheckBox cb_Supplier;
    }
}