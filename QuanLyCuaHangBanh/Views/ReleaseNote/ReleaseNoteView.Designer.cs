namespace QuanLyCuaHangBanh.Views
{
    partial class ReleaseNoteView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleaseNoteView));
            dgv_WarehouseNoteList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CreatorName = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            toolStrip1 = new ToolStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Import = new ToolStripButton();
            tsbnt_Export = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgv_WarehouseNoteList).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_WarehouseNoteList
            // 
            dgv_WarehouseNoteList.AllowUserToAddRows = false;
            dgv_WarehouseNoteList.AllowUserToDeleteRows = false;
            dgv_WarehouseNoteList.AllowUserToOrderColumns = true;
            dgv_WarehouseNoteList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_WarehouseNoteList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_WarehouseNoteList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_WarehouseNoteList.Columns.AddRange(new DataGridViewColumn[] { ID, CreatorName, CreatedDate, Status, Note });
            dgv_WarehouseNoteList.Cursor = Cursors.Hand;
            dgv_WarehouseNoteList.Dock = DockStyle.Fill;
            dgv_WarehouseNoteList.Location = new Point(3, 50);
            dgv_WarehouseNoteList.MultiSelect = false;
            dgv_WarehouseNoteList.Name = "dgv_WarehouseNoteList";
            dgv_WarehouseNoteList.RowHeadersWidth = 51;
            dgv_WarehouseNoteList.RowTemplate.Height = 30;
            dgv_WarehouseNoteList.RowTemplate.ReadOnly = true;
            dgv_WarehouseNoteList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_WarehouseNoteList.Size = new Size(917, 358);
            dgv_WarehouseNoteList.TabIndex = 2;
            dgv_WarehouseNoteList.SelectionChanged += dgv_WarehouseNoteList_SelectionChanged;
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
            // btn_Delete
            // 
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(530, 26);
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
            btn_Edit.Location = new Point(431, 26);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_WarehouseNoteList);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(923, 497);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách phiếu xuất";
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 408);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 86);
            panel1.TabIndex = 3;
            // 
            // btn_Add
            // 
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(322, 25);
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
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, tsbtn_Search, toolStripSeparator1, tsbtn_Import, tsbnt_Export });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(917, 27);
            toolStrip1.TabIndex = 1;
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
            // ReleaseNoteView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 497);
            Controls.Add(groupBox1);
            Name = "ReleaseNoteView";
            Text = "Phiếu xuất";
            ((System.ComponentModel.ISupportInitialize)dgv_WarehouseNoteList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgv_WarehouseNoteList;
        private MaterialSkin.Controls.MaterialButton btn_Delete;
        private MaterialSkin.Controls.MaterialButton btn_Edit;
        private GroupBox groupBox1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_Add;
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton tsbtn_Search;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtn_Import;
        private ToolStripButton tsbnt_Export;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CreatorName;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
    }
}