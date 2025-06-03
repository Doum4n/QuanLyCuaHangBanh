namespace QuanLyCuaHangBanh.Views.Order
{
    partial class OrderView
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
            groupBox1 = new GroupBox();
            dgv_OrderList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            OrderDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            PaymentMethod = new DataGridViewTextBoxColumn();
            DeliveryAddress = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            toolStrip1 = new ToolStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Import = new ToolStripButton();
            tsbnt_Export = new ToolStripButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_OrderList);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1272, 469);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách đơn hàng";
            // 
            // dgv_OrderList
            // 
            dgv_OrderList.AllowUserToAddRows = false;
            dgv_OrderList.AllowUserToDeleteRows = false;
            dgv_OrderList.AllowUserToOrderColumns = true;
            dgv_OrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_OrderList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderList.Columns.AddRange(new DataGridViewColumn[] { ID, CustomerName, OrderDate, Status, PaymentMethod, DeliveryAddress, TotalAmount });
            dgv_OrderList.Cursor = Cursors.Hand;
            dgv_OrderList.Dock = DockStyle.Fill;
            dgv_OrderList.Location = new Point(3, 50);
            dgv_OrderList.MultiSelect = false;
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.RowHeadersWidth = 51;
            dgv_OrderList.RowTemplate.Height = 30;
            dgv_OrderList.RowTemplate.ReadOnly = true;
            dgv_OrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_OrderList.Size = new Size(1266, 330);
            dgv_OrderList.TabIndex = 2;
            dgv_OrderList.SelectionChanged += dgv_OrderList_SelectionChanged;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 14.771512F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // CustomerName
            // 
            CustomerName.DataPropertyName = "CustomerName";
            CustomerName.HeaderText = "Tên khách hàng";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            // 
            // OrderDate
            // 
            OrderDate.DataPropertyName = "OrderDate";
            OrderDate.HeaderText = "Ngày đặt";
            OrderDate.MinimumWidth = 6;
            OrderDate.Name = "OrderDate";
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Trạng thái";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // PaymentMethod
            // 
            PaymentMethod.DataPropertyName = "PaymentMethod";
            PaymentMethod.HeaderText = "Phương thức thanh toán";
            PaymentMethod.MinimumWidth = 6;
            PaymentMethod.Name = "PaymentMethod";
            // 
            // DeliveryAddress
            // 
            DeliveryAddress.DataPropertyName = "DeliveryAddress";
            DeliveryAddress.HeaderText = "Địa chỉ giao hàng";
            DeliveryAddress.MinimumWidth = 6;
            DeliveryAddress.Name = "DeliveryAddress";
            // 
            // TotalAmount
            // 
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.HeaderText = "Tổng tiền";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 380);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 86);
            panel1.TabIndex = 3;
            // 
            // btn_Delete
            // 
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(705, 26);
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
            btn_Edit.Location = new Point(606, 26);
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
            btn_Add.Location = new Point(497, 25);
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
            toolStrip1.Size = new Size(1266, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            toolStripTextBox1.KeyDown += toolStripTextBox1_KeyDown;
            toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;
            // 
            // tsbtn_Search
            // 
            tsbtn_Search.Image = Properties.Resources.search_17730909;
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
            // OrderView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 469);
            Controls.Add(groupBox1);
            Name = "OrderView";
            Text = "OrderView";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private DataGridView dgv_OrderList;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_Delete;
        private MaterialSkin.Controls.MaterialButton btn_Edit;
        private MaterialSkin.Controls.MaterialButton btn_Add;
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton tsbtn_Search;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtn_Import;
        private ToolStripButton tsbnt_Export;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn OrderDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn PaymentMethod;
        private DataGridViewTextBoxColumn DeliveryAddress;
        private DataGridViewTextBoxColumn TotalAmount;
    }
}