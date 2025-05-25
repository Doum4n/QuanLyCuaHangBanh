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
            groupBox2 = new GroupBox();
            dtp_FromDate = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            dtp_ToDate = new DateTimePicker();
            groupBox1 = new GroupBox();
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
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 183);
            panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtp_FromDate);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dtp_ToDate);
            groupBox2.Location = new Point(0, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(855, 79);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ngày nhập";
            // 
            // dtp_FromDate
            // 
            dtp_FromDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_FromDate.CustomFormat = "dd/MM/yyyy";
            dtp_FromDate.Format = DateTimePickerFormat.Custom;
            dtp_FromDate.Location = new Point(267, 38);
            dtp_FromDate.Name = "dtp_FromDate";
            dtp_FromDate.Size = new Size(151, 27);
            dtp_FromDate.TabIndex = 8;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(437, 15);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 11;
            label6.Text = "Đến ngày";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(267, 15);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 9;
            label5.Text = "Từ ngày";
            // 
            // dtp_ToDate
            // 
            dtp_ToDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_ToDate.CustomFormat = "dd/MM/yyyy";
            dtp_ToDate.Format = DateTimePickerFormat.Custom;
            dtp_ToDate.Location = new Point(437, 38);
            dtp_ToDate.Name = "dtp_ToDate";
            dtp_ToDate.Size = new Size(151, 27);
            dtp_ToDate.TabIndex = 10;
            // 
            // groupBox1
            // 
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
            // cbb_Products
            // 
            cbb_Products.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(268, 50);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(151, 28);
            cbb_Products.TabIndex = 0;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(432, 27);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 5;
            label3.Text = "Nhà cung cấp";
            // 
            // cbb_Categories
            // 
            cbb_Categories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(105, 50);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(151, 28);
            cbb_Categories.TabIndex = 1;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // cbb_Manufacturers
            // 
            cbb_Manufacturers.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbb_Manufacturers.FormattingEnabled = true;
            cbb_Manufacturers.Location = new Point(598, 50);
            cbb_Manufacturers.Name = "cbb_Manufacturers";
            cbb_Manufacturers.Size = new Size(151, 28);
            cbb_Manufacturers.TabIndex = 6;
            cbb_Manufacturers.SelectedIndexChanged += cbb_Manufacturers_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(268, 27);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 2;
            label1.Text = "Tên sản phẩm";
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(432, 50);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(151, 28);
            cbb_Suppliers.TabIndex = 4;
            cbb_Suppliers.SelectedIndexChanged += cbb_Suppliers_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(105, 27);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 3;
            label2.Text = "Loại sản phẩm";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(598, 27);
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
            panel2.Location = new Point(0, 183);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 53);
            panel2.TabIndex = 1;
            // 
            // btn_ShowAll
            // 
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
            reportViewer1.Location = new Point(0, 236);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(855, 214);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ComboBox cbb_Manufacturers;
        private Label label4;
        private DateTimePicker dtp_FromDate;
        private Label label5;
        private Label label6;
        private DateTimePicker dtp_ToDate;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialButton btn_ShowAll;
        private MaterialSkin.Controls.MaterialButton btn_Filter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}