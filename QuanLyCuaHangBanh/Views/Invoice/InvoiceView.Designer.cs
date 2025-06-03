namespace QuanLyCuaHangBanh.Views.Invoice
{
    partial class InvoiceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceView));
            tsbnt_Export = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtn_Search = new ToolStripButton();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStrip1 = new ToolStrip();
            tsbtn_Import = new ToolStripButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            btn_PrintInvoice = new MaterialSkin.Controls.MaterialButton();
            btn_Delete = new MaterialSkin.Controls.MaterialButton();
            btn_Edit = new MaterialSkin.Controls.MaterialButton();
            groupBox1 = new GroupBox();
            dgv_InvoiceList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            EmployeeName = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            PaymentMethod = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            TotalUnpaid = new DataGridViewTextBoxColumn();
            tabControl2 = new TabControl();
            tabPage_SalesInvoice = new TabPage();
            tabPane_PurchaseInvoice = new TabPage();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_InvoiceList).BeginInit();
            tabControl2.SuspendLayout();
            tabPage_SalesInvoice.SuspendLayout();
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
            tsbtn_Search.Click += tsbtn_Search_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            toolStripTextBox1.KeyDown += toolStripTextBox1_KeyDown;
            toolStripTextBox1.Click += toolStripTextBox1_Click;
            toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, tsbtn_Search, toolStripSeparator1, tsbtn_Import, tsbnt_Export });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1260, 27);
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
            // btn_Add
            // 
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(572, 25);
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
            panel1.Controls.Add(btn_PrintInvoice);
            panel1.Controls.Add(btn_Delete);
            panel1.Controls.Add(btn_Edit);
            panel1.Controls.Add(btn_Add);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 346);
            panel1.Name = "panel1";
            panel1.Size = new Size(1260, 86);
            panel1.TabIndex = 3;
            // 
            // btn_PrintInvoice
            // 
            btn_PrintInvoice.AutoSize = false;
            btn_PrintInvoice.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_PrintInvoice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_PrintInvoice.Depth = 0;
            btn_PrintInvoice.HighEmphasis = true;
            btn_PrintInvoice.Icon = null;
            btn_PrintInvoice.Location = new Point(416, 26);
            btn_PrintInvoice.Margin = new Padding(4, 6, 4, 6);
            btn_PrintInvoice.MouseState = MaterialSkin.MouseState.HOVER;
            btn_PrintInvoice.Name = "btn_PrintInvoice";
            btn_PrintInvoice.NoAccentTextColor = Color.Empty;
            btn_PrintInvoice.Size = new Size(115, 36);
            btn_PrintInvoice.TabIndex = 6;
            btn_PrintInvoice.Text = "In hóa đơn";
            btn_PrintInvoice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_PrintInvoice.UseAccentColor = false;
            btn_PrintInvoice.UseVisualStyleBackColor = true;
            btn_PrintInvoice.Click += btn_PrintInvoice_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Delete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Delete.Depth = 0;
            btn_Delete.HighEmphasis = true;
            btn_Delete.Icon = null;
            btn_Delete.Location = new Point(780, 26);
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
            btn_Edit.Location = new Point(681, 26);
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
            groupBox1.Controls.Add(dgv_InvoiceList);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1266, 435);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn bán hàng";
            // 
            // dgv_InvoiceList
            // 
            dgv_InvoiceList.AllowUserToAddRows = false;
            dgv_InvoiceList.AllowUserToDeleteRows = false;
            dgv_InvoiceList.AllowUserToOrderColumns = true;
            dgv_InvoiceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_InvoiceList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_InvoiceList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_InvoiceList.Columns.AddRange(new DataGridViewColumn[] { ID, EmployeeName, CreatedDate, Status, CustomerName, Type, Note, PaymentMethod, TotalAmount, TotalUnpaid });
            dgv_InvoiceList.Cursor = Cursors.Hand;
            dgv_InvoiceList.Dock = DockStyle.Fill;
            dgv_InvoiceList.Location = new Point(3, 50);
            dgv_InvoiceList.MultiSelect = false;
            dgv_InvoiceList.Name = "dgv_InvoiceList";
            dgv_InvoiceList.RowHeadersWidth = 51;
            dgv_InvoiceList.RowTemplate.Height = 30;
            dgv_InvoiceList.RowTemplate.ReadOnly = true;
            dgv_InvoiceList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_InvoiceList.Size = new Size(1260, 296);
            dgv_InvoiceList.TabIndex = 2;
            dgv_InvoiceList.SelectionChanged += dgv_InvoiceList_SelectionChanged;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // EmployeeName
            // 
            EmployeeName.DataPropertyName = "EmployeeName";
            EmployeeName.HeaderText = "Người lập";
            EmployeeName.MinimumWidth = 6;
            EmployeeName.Name = "EmployeeName";
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
            // CustomerName
            // 
            CustomerName.DataPropertyName = "CustomerName";
            CustomerName.HeaderText = "Khách hàng";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Loại khách hàng";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            // 
            // Note
            // 
            Note.DataPropertyName = "Note";
            Note.HeaderText = "Ghi chú";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            // 
            // PaymentMethod
            // 
            PaymentMethod.DataPropertyName = "PaymentMethod";
            PaymentMethod.HeaderText = "Phương thức thanh toán";
            PaymentMethod.MinimumWidth = 6;
            PaymentMethod.Name = "PaymentMethod";
            // 
            // TotalAmount
            // 
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.HeaderText = "Tổng thành tiền";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            // 
            // TotalUnpaid
            // 
            TotalUnpaid.DataPropertyName = "TotalUnpaid";
            TotalUnpaid.HeaderText = "Tổng chưa trả";
            TotalUnpaid.MinimumWidth = 6;
            TotalUnpaid.Name = "TotalUnpaid";
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage_SalesInvoice);
            tabControl2.Controls.Add(tabPane_PurchaseInvoice);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(0, 0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1280, 474);
            tabControl2.TabIndex = 5;
            tabControl2.SelectedIndexChanged += tabControl2_SelectedIndexChanged;
            // 
            // tabPage_SalesInvoice
            // 
            tabPage_SalesInvoice.Controls.Add(groupBox1);
            tabPage_SalesInvoice.Location = new Point(4, 29);
            tabPage_SalesInvoice.Name = "tabPage_SalesInvoice";
            tabPage_SalesInvoice.Padding = new Padding(3);
            tabPage_SalesInvoice.Size = new Size(1272, 441);
            tabPage_SalesInvoice.TabIndex = 0;
            tabPage_SalesInvoice.Text = "Hóa đơn bán hàng";
            tabPage_SalesInvoice.UseVisualStyleBackColor = true;
            // 
            // tabPane_PurchaseInvoice
            // 
            tabPane_PurchaseInvoice.Location = new Point(4, 29);
            tabPane_PurchaseInvoice.Name = "tabPane_PurchaseInvoice";
            tabPane_PurchaseInvoice.Padding = new Padding(3);
            tabPane_PurchaseInvoice.Size = new Size(1272, 441);
            tabPane_PurchaseInvoice.TabIndex = 1;
            tabPane_PurchaseInvoice.Text = "Hóa đơn nhập hàng";
            tabPane_PurchaseInvoice.UseVisualStyleBackColor = true;
            // 
            // InvoiceView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 474);
            Controls.Add(tabControl2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InvoiceView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn";
            Load += InvoiceView_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_InvoiceList).EndInit();
            tabControl2.ResumeLayout(false);
            tabPage_SalesInvoice.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripButton tsbnt_Export;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtn_Search;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbtn_Import;
        private MaterialSkin.Controls.MaterialButton btn_Add;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_Delete;
        private MaterialSkin.Controls.MaterialButton btn_Edit;
        private GroupBox groupBox1;
        private DataGridView dgv_InvoiceList;
        private TabControl tabControl2;
        private TabPage tabPage_SalesInvoice;
        private TabPage tabPane_PurchaseInvoice;
        private MaterialSkin.Controls.MaterialButton btn_PrintInvoice;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn EmployeeName;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewTextBoxColumn PaymentMethod;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn TotalUnpaid;
    }
}