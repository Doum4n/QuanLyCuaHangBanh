namespace QuanLyCuaHangBanh.Views
{
    partial class GoodsReceiptNoteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceiptNoteView));
            tsbnt_Export = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Search = new ToolStripButton();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStrip1 = new ToolStrip();
            tsbtn_Import = new ToolStripButton();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            dgv_PurchaseReceiptList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CreatorName = new DataGridViewTextBoxColumn();
            SupplierName = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_PurchaseReceiptList).BeginInit();
            SuspendLayout();
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // tsbtn_Search
            // 
            tsbtn_Search.Image = (Image)resources.GetObject("tsbtn_Search.Image");
            tsbtn_Search.ImageTransparentColor = Color.Magenta;
            tsbtn_Search.Name = "tsbtn_Search";
            tsbtn_Search.Size = new Size(94, 24);
            tsbtn_Search.Text = "Tìm kiếm";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, tsbtn_Search, toolStripSeparator1, tsbtn_Import, tsbnt_Export });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1125, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
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
            // btn_Delete
            // 
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(625, 26);
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
            btn_Edit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Edit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Edit.Depth = 0;
            btn_Edit.HighEmphasis = true;
            btn_Edit.Icon = null;
            btn_Edit.Location = new Point(526, 26);
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
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(417, 25);
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
            // panel1
            // 
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 361);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 86);
            panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_PurchaseReceiptList);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1131, 450);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgv_PurchaseReceiptList
            // 
            dgv_PurchaseReceiptList.AllowUserToAddRows = false;
            dgv_PurchaseReceiptList.AllowUserToDeleteRows = false;
            dgv_PurchaseReceiptList.AllowUserToOrderColumns = true;
            dgv_PurchaseReceiptList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_PurchaseReceiptList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_PurchaseReceiptList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_PurchaseReceiptList.Columns.AddRange(new DataGridViewColumn[] { ID, CreatorName, SupplierName, CreatedDate, Status, Note });
            dgv_PurchaseReceiptList.Cursor = Cursors.Hand;
            dgv_PurchaseReceiptList.Dock = DockStyle.Fill;
            dgv_PurchaseReceiptList.Location = new Point(3, 50);
            dgv_PurchaseReceiptList.MultiSelect = false;
            dgv_PurchaseReceiptList.Name = "dgv_PurchaseReceiptList";
            dgv_PurchaseReceiptList.RowHeadersWidth = 51;
            dgv_PurchaseReceiptList.RowTemplate.Height = 30;
            dgv_PurchaseReceiptList.RowTemplate.ReadOnly = true;
            dgv_PurchaseReceiptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_PurchaseReceiptList.Size = new Size(1125, 311);
            dgv_PurchaseReceiptList.TabIndex = 2;
            dgv_PurchaseReceiptList.SelectionChanged += dgv_PurchaseReceiptList_SelectionChanged;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 14.771512F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // CreatorName
            // 
            CreatorName.DataPropertyName = "CreatorName";
            CreatorName.HeaderText = "Người lập";
            CreatorName.MinimumWidth = 6;
            CreatorName.Name = "CreatorName";
            // 
            // SupplierName
            // 
            SupplierName.DataPropertyName = "SupplierName";
            SupplierName.HeaderText = "Nhà cung cấp";
            SupplierName.MinimumWidth = 6;
            SupplierName.Name = "SupplierName";
            // 
            // CreatedDate
            // 
            CreatedDate.DataPropertyName = "CreatedDate";
            CreatedDate.HeaderText = "Ngày lập";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // Note
            // 
            Note.DataPropertyName = "Note";
            Note.HeaderText = "Ghi chú";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            // 
            // GoodsReceiptNoteView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 450);
            Controls.Add(groupBox1);
            Name = "GoodsReceiptNoteView";
            Text = "PurchargeReceiptVieww";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_PurchaseReceiptList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripButton tsbnt_Export;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtn_Search;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbtn_Import;
        private MaterialSkin.Controls.MaterialButton btn_Delete;
        private MaterialSkin.Controls.MaterialButton btn_Edit;
        private MaterialSkin.Controls.MaterialButton btn_Add;
        private Panel panel1;
        private GroupBox groupBox1;
        private DataGridView dgv_PurchaseReceiptList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CreatorName;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
    }
}