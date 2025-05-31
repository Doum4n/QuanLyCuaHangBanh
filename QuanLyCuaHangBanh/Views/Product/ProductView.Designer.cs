namespace QuanLyCuaHangBanh.Views
{
    partial class ProductView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductView));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dgv_ProductList = new DataGridView();
            toolStrip1 = new ToolStrip();
            tstb_Search = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Import = new ToolStripButton();
            tsbnt_Export = new ToolStripButton();
            panel1 = new Panel();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            ProducerName = new DataGridViewTextBoxColumn();
            ManufacturerName = new DataGridViewTextBoxColumn();
            Unit = new DataGridViewComboBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            TotalQuantity = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Image = new DataGridViewImageColumn();
            ViewDetail = new DataGridViewLinkColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_ProductList);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Controls.Add(panel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1287, 484);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AllowUserToOrderColumns = true;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, ProducerName, ManufacturerName, Unit, UnitPrice, Quantity, TotalQuantity, Description, Image, ViewDetail });
            dgv_ProductList.Cursor = Cursors.Hand;
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_ProductList.Location = new Point(3, 50);
            dgv_ProductList.MultiSelect = false;
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.RowTemplate.Height = 30;
            dgv_ProductList.RowTemplate.ReadOnly = true;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1281, 345);
            dgv_ProductList.TabIndex = 2;
            dgv_ProductList.CellContentClick += dgv_ProductList_CellContentClick;
            dgv_ProductList.DataError += dgv_ProductList_DataError;
            dgv_ProductList.EditingControlShowing += dgv_ProductList_EditingControlShowing;
            dgv_ProductList.RowHeightChanged += dgv_ProductList_RowHeightChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tstb_Search, tsbtn_Search, toolStripSeparator1, tsbtn_Import, tsbnt_Export });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1281, 27);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // tstb_Search
            // 
            tstb_Search.Name = "tstb_Search";
            tstb_Search.Size = new Size(100, 27);
            tstb_Search.KeyDown += tstb_Search_KeyDown;
            tstb_Search.TextChanged += tstb_Search_TextChanged;
            // 
            // tsbtn_Search
            // 
            tsbtn_Search.Image = (Image)resources.GetObject("tsbtn_Search.Image");
            tsbtn_Search.ImageTransparentColor = Color.Magenta;
            tsbtn_Search.Name = "tsbtn_Search";
            tsbtn_Search.Size = new Size(94, 24);
            tsbtn_Search.Text = "Tìm kiếm";
            tsbtn_Search.Click += tsbtn_Search_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // tsbtn_Import
            // 
            tsbtn_Import.Image = (Image)resources.GetObject("tsbtn_Import.Image");
            tsbtn_Import.ImageTransparentColor = Color.Magenta;
            tsbtn_Import.Name = "tsbtn_Import";
            tsbtn_Import.Size = new Size(78, 24);
            tsbtn_Import.Text = "Nhập...";
            tsbtn_Import.Click += tsbtn_Import_Click;
            // 
            // tsbnt_Export
            // 
            tsbnt_Export.Image = (Image)resources.GetObject("tsbnt_Export.Image");
            tsbnt_Export.ImageTransparentColor = Color.Magenta;
            tsbnt_Export.Name = "tsbnt_Export";
            tsbnt_Export.Size = new Size(72, 24);
            tsbnt_Export.Text = "Xuất...";
            tsbnt_Export.Click += tsbnt_Export_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 395);
            panel1.Name = "panel1";
            panel1.Size = new Size(1281, 86);
            panel1.TabIndex = 3;
            // 
            // btn_Delete
            // 
            btn_Delete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(712, 26);
            btn_Delete.Margin = new Padding(4, 6, 4, 6);
            btn_Delete.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Delete.Name = "btn_Delete";
            btn_Delete.NoAccentTextColor = Color.Empty;
            btn_Delete.Size = new Size(64, 36);
            btn_Delete.TabIndex = 5;
            btn_Delete.Text = "Xóa";
            btn_Delete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Delete.UseAccentColor = false;
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Edit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Edit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Edit.Depth = 0;
            btn_Edit.HighEmphasis = true;
            btn_Edit.Icon = null;
            btn_Edit.Location = new Point(613, 26);
            btn_Edit.Margin = new Padding(4, 6, 4, 6);
            btn_Edit.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Edit.Name = "btn_Edit";
            btn_Edit.NoAccentTextColor = Color.Empty;
            btn_Edit.Size = new Size(64, 36);
            btn_Edit.TabIndex = 4;
            btn_Edit.Text = "Sửa...";
            btn_Edit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Edit.UseAccentColor = false;
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // btn_Add
            // 
            btn_Add.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(504, 25);
            btn_Add.Margin = new Padding(4, 6, 4, 6);
            btn_Add.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Add.Name = "btn_Add";
            btn_Add.NoAccentTextColor = Color.Empty;
            btn_Add.Size = new Size(74, 36);
            btn_Add.TabIndex = 3;
            btn_Add.Text = "Thêm...";
            btn_Add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Add.UseAccentColor = false;
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // ID
            // 
            ID.DataPropertyName = "ProductId";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Tên sản phẩm";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "CategoryName";
            CategoryName.HeaderText = "Loại sản phẩm";
            CategoryName.MinimumWidth = 6;
            CategoryName.Name = "CategoryName";
            // 
            // ProducerName
            // 
            ProducerName.DataPropertyName = "ProducerName";
            ProducerName.HeaderText = "Nhà cung cấp";
            ProducerName.MinimumWidth = 6;
            ProducerName.Name = "ProducerName";
            // 
            // ManufacturerName
            // 
            ManufacturerName.DataPropertyName = "ManufacturerName";
            ManufacturerName.HeaderText = "Hãng sản xuất";
            ManufacturerName.MinimumWidth = 6;
            ManufacturerName.Name = "ManufacturerName";
            // 
            // Unit
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Unit.DefaultCellStyle = dataGridViewCellStyle1;
            Unit.HeaderText = "Đơn vị tính";
            Unit.MinimumWidth = 6;
            Unit.Name = "Unit";
            Unit.Resizable = DataGridViewTriState.True;
            Unit.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // UnitPrice
            // 
            UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            UnitPrice.HeaderText = "Giá bán";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            Quantity.HeaderText = "Số lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            // 
            // TotalQuantity
            // 
            TotalQuantity.DataPropertyName = "TotalQuantity";
            TotalQuantity.HeaderText = "Tổng số lượng";
            TotalQuantity.MinimumWidth = 6;
            TotalQuantity.Name = "TotalQuantity";
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Mô tả";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            // 
            // Image
            // 
            Image.DataPropertyName = "Image";
            Image.HeaderText = "Hình ảnh";
            Image.MinimumWidth = 6;
            Image.Name = "Image";
            Image.Resizable = DataGridViewTriState.True;
            Image.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ViewDetail
            // 
            ViewDetail.DataPropertyName = "ViewDetail";
            ViewDetail.HeaderText = "Xem chi tiết";
            ViewDetail.MinimumWidth = 6;
            ViewDetail.Name = "ViewDetail";
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 484);
            Controls.Add(groupBox1);
            Name = "ProductView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản phẩm";
            Load += ProductView_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private DataGridView dgv_ProductList;
        private MaterialSkin.Controls.MaterialButton btn_Delete;
        private MaterialSkin.Controls.MaterialButton btn_Edit;
        private MaterialSkin.Controls.MaterialButton btn_Add;
        private ToolStrip toolStrip1;
        private ToolStripTextBox tstb_Search;
        private ToolStripButton tsbtn_Search;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtn_Import;
        private ToolStripButton tsbnt_Export;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn ProducerName;
        private DataGridViewTextBoxColumn ManufacturerName;
        private DataGridViewComboBoxColumn Unit;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn TotalQuantity;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewImageColumn Image;
        private DataGridViewLinkColumn ViewDetail;
    }
}