namespace QuanLyCuaHangBanh.Views
{
    partial class CustomerView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerView));
            groupBox1 = new GroupBox();
            dgv_CustomerList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Limit = new DataGridViewTextBoxColumn();
            TotalAccountPayable = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            toolStrip1 = new ToolStrip();
            tstb_Search = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Import = new ToolStripButton();
            tsbnt_Export = new ToolStripButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CustomerList).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_CustomerList);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(958, 450);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách khách hàng";
            // 
            // dgv_CustomerList
            // 
            dgv_CustomerList.AllowUserToAddRows = false;
            dgv_CustomerList.AllowUserToDeleteRows = false;
            dgv_CustomerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_CustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_CustomerList.Columns.AddRange(new DataGridViewColumn[] { ID, Name, PhoneNumber, Address, Type, Limit, TotalAccountPayable });
            dgv_CustomerList.Dock = DockStyle.Fill;
            dgv_CustomerList.Location = new Point(3, 50);
            dgv_CustomerList.MultiSelect = false;
            dgv_CustomerList.Name = "dgv_CustomerList";
            dgv_CustomerList.ReadOnly = true;
            dgv_CustomerList.RowHeadersWidth = 51;
            dgv_CustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_CustomerList.Size = new Size(952, 311);
            dgv_CustomerList.TabIndex = 2;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Tên khách hàng";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "PhoneNumber";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            PhoneNumber.DefaultCellStyle = dataGridViewCellStyle1;
            PhoneNumber.HeaderText = "Số điện thoại";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Địa chỉ";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Loại khách hàng";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            Type.ReadOnly = true;
            // 
            // Limit
            // 
            Limit.DataPropertyName = "Limit";
            Limit.HeaderText = "Hạn mức công nợ";
            Limit.MinimumWidth = 6;
            Limit.Name = "Limit";
            Limit.ReadOnly = true;
            // 
            // TotalAccountPayable
            // 
            TotalAccountPayable.DataPropertyName = "TotalAccountPayable";
            TotalAccountPayable.HeaderText = "Tổng công nợ phải thu";
            TotalAccountPayable.MinimumWidth = 6;
            TotalAccountPayable.Name = "TotalAccountPayable";
            TotalAccountPayable.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 361);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 86);
            panel1.TabIndex = 3;
            // 
            // btn_Delete
            // 
            btn_Delete.Anchor = AnchorStyles.None;
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(548, 26);
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
            btn_Edit.Anchor = AnchorStyles.None;
            btn_Edit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Edit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Edit.Depth = 0;
            btn_Edit.HighEmphasis = true;
            btn_Edit.Icon = null;
            btn_Edit.Location = new Point(449, 26);
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
            btn_Add.Anchor = AnchorStyles.None;
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(340, 25);
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { tstb_Search, tsbtn_Search, toolStripSeparator1, tsbtn_Import, tsbnt_Export });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(952, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tstb_Search
            // 
            tstb_Search.Name = "tstb_Search";
            tstb_Search.Size = new Size(100, 27);
            tstb_Search.TextChanged += tstb_Search_TextChanged;
            // 
            // tsbtn_Search
            // 
            tsbtn_Search.Image = Properties.Resources.search_17730909;
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
            tsbtn_Import.Image = Properties.Resources.download_10626408;
            tsbtn_Import.ImageTransparentColor = Color.Magenta;
            tsbtn_Import.Name = "tsbtn_Import";
            tsbtn_Import.Size = new Size(78, 24);
            tsbtn_Import.Text = "Nhập...";
            tsbtn_Import.Click += tsbtn_Import_Click;
            // 
            // tsbnt_Export
            // 
            tsbnt_Export.Image = Properties.Resources.upload_10696783;
            tsbnt_Export.ImageTransparentColor = Color.Magenta;
            tsbnt_Export.Name = "tsbnt_Export";
            tsbnt_Export.Size = new Size(72, 24);
            tsbnt_Export.Text = "Xuất...";
            tsbnt_Export.Click += tsbnt_Export_Click;
            // 
            // CustomerView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 450);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách hàng";
            Load += CustomerView_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CustomerList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_CustomerList;
        private Panel panel1;
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
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Limit;
        private DataGridViewTextBoxColumn TotalAccountPayable;
    }
}