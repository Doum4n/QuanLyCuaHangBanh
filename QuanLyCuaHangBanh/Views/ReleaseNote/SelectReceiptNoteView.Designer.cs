namespace QuanLyCuaHangBanh.Views
{
    partial class SelectReceiptNoteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectReceiptNoteView));
            toolStrip1 = new ToolStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            dgv_GoodsReceiptNote = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CreatorName = new DataGridViewTextBoxColumn();
            SupplierName = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            Select = new DataGridViewCheckBoxColumn();
            panel1 = new Panel();
            btn_Done = new MaterialSkin.Controls.MaterialButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GoodsReceiptNote).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, tsbtn_Search, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1138, 27);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            // 
            // tsbtn_Search
            // 
            tsbtn_Search.Image = (Image)resources.GetObject("tsbtn_Search.Image");
            tsbtn_Search.ImageTransparentColor = Color.Magenta;
            tsbtn_Search.Name = "tsbtn_Search";
            tsbtn_Search.Size = new Size(94, 24);
            tsbtn_Search.Text = "Tìm kiếm";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // dgv_GoodsReceiptNote
            // 
            dgv_GoodsReceiptNote.AllowUserToAddRows = false;
            dgv_GoodsReceiptNote.AllowUserToDeleteRows = false;
            dgv_GoodsReceiptNote.AllowUserToOrderColumns = true;
            dgv_GoodsReceiptNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_GoodsReceiptNote.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_GoodsReceiptNote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_GoodsReceiptNote.Columns.AddRange(new DataGridViewColumn[] { ID, CreatorName, SupplierName, CreatedDate, Status, Note, Select });
            dgv_GoodsReceiptNote.Cursor = Cursors.Hand;
            dgv_GoodsReceiptNote.Dock = DockStyle.Fill;
            dgv_GoodsReceiptNote.Location = new Point(0, 27);
            dgv_GoodsReceiptNote.MultiSelect = false;
            dgv_GoodsReceiptNote.Name = "dgv_GoodsReceiptNote";
            dgv_GoodsReceiptNote.RowHeadersWidth = 51;
            dgv_GoodsReceiptNote.RowTemplate.Height = 30;
            dgv_GoodsReceiptNote.RowTemplate.ReadOnly = true;
            dgv_GoodsReceiptNote.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_GoodsReceiptNote.Size = new Size(1138, 423);
            dgv_GoodsReceiptNote.TabIndex = 5;
            dgv_GoodsReceiptNote.CellContentClick += dgv_GoodsReceiptNote_CellContentClick;
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
            // Select
            // 
            Select.HeaderText = "Chọn";
            Select.MinimumWidth = 6;
            Select.Name = "Select";
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Done);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 387);
            panel1.Name = "panel1";
            panel1.Size = new Size(1138, 63);
            panel1.TabIndex = 6;
            // 
            // btn_Done
            // 
            btn_Done.AutoSize = false;
            btn_Done.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Done.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Done.Depth = 0;
            btn_Done.HighEmphasis = true;
            btn_Done.Icon = null;
            btn_Done.Location = new Point(477, 12);
            btn_Done.Margin = new Padding(4, 6, 4, 6);
            btn_Done.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Done.Name = "btn_Done";
            btn_Done.NoAccentTextColor = Color.Empty;
            btn_Done.Size = new Size(185, 39);
            btn_Done.TabIndex = 0;
            btn_Done.Text = "Hoàn tất";
            btn_Done.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Done.UseAccentColor = false;
            btn_Done.UseVisualStyleBackColor = true;
            btn_Done.Click += btn_Done_Click;
            // 
            // SelectGoodsReceiptNoteView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 450);
            Controls.Add(panel1);
            Controls.Add(dgv_GoodsReceiptNote);
            Controls.Add(toolStrip1);
            Name = "SelectGoodsReceiptNoteView";
            Text = "SelectGoodsReciveNoteView";
            Load += SelectGoodsReceiptNoteView_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GoodsReceiptNote).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton tsbtn_Search;
        private ToolStripSeparator toolStripSeparator1;
        private DataGridView dgv_GoodsReceiptNote;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CreatorName;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewCheckBoxColumn Select;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_Done;
    }
}