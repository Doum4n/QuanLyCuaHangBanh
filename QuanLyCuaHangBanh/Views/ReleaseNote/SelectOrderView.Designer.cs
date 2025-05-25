namespace QuanLyCuaHangBanh.Views.ReleaseNote
{
    partial class SelectOrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectOrderView));
            toolStrip1 = new ToolStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            tsbtn_Search = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            btn_Done = new MaterialSkin.Controls.MaterialButton();
            dgv_OrderList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            OrderDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            PaymentMethod = new DataGridViewTextBoxColumn();
            DeliverAddress = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            Select = new DataGridViewCheckBoxColumn();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, tsbtn_Search, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(909, 27);
            toolStrip1.TabIndex = 7;
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
            // panel1
            // 
            panel1.Controls.Add(btn_Done);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 387);
            panel1.Name = "panel1";
            panel1.Size = new Size(909, 63);
            panel1.TabIndex = 9;
            // 
            // btn_Done
            // 
            btn_Done.AutoSize = false;
            btn_Done.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Done.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Done.Depth = 0;
            btn_Done.HighEmphasis = true;
            btn_Done.Icon = null;
            btn_Done.Location = new Point(362, 12);
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
            // dgv_OrderList
            // 
            dgv_OrderList.AllowUserToAddRows = false;
            dgv_OrderList.AllowUserToDeleteRows = false;
            dgv_OrderList.AllowUserToOrderColumns = true;
            dgv_OrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_OrderList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderList.Columns.AddRange(new DataGridViewColumn[] { ID, CustomerName, OrderDate, Status, PaymentMethod, DeliverAddress, TotalAmount, Select });
            dgv_OrderList.Cursor = Cursors.Hand;
            dgv_OrderList.Dock = DockStyle.Fill;
            dgv_OrderList.Location = new Point(0, 27);
            dgv_OrderList.MultiSelect = false;
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.RowHeadersWidth = 51;
            dgv_OrderList.RowTemplate.Height = 30;
            dgv_OrderList.RowTemplate.ReadOnly = true;
            dgv_OrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_OrderList.Size = new Size(909, 360);
            dgv_OrderList.TabIndex = 10;
            dgv_OrderList.CellContentClick += dgv_OrderList_CellContentClick;
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
            // DeliverAddress
            // 
            DeliverAddress.DataPropertyName = "DeliverAddress";
            DeliverAddress.HeaderText = "Địa chỉ giao hàng";
            DeliverAddress.MinimumWidth = 6;
            DeliverAddress.Name = "DeliverAddress";
            // 
            // TotalAmount
            // 
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.HeaderText = "Tổng tiền";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            // 
            // Select
            // 
            Select.DataPropertyName = "Select";
            Select.HeaderText = "Chọn";
            Select.MinimumWidth = 6;
            Select.Name = "Select";
            Select.Resizable = DataGridViewTriState.True;
            Select.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // SelectOrderView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 450);
            Controls.Add(dgv_OrderList);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "SelectOrderView";
            Text = "SelectOrderView";
            Load += SelectOrderView_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton tsbtn_Search;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_Done;
        private DataGridView dgv_OrderList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn OrderDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn PaymentMethod;
        private DataGridViewTextBoxColumn DeliverAddress;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewCheckBoxColumn Select;
    }
}