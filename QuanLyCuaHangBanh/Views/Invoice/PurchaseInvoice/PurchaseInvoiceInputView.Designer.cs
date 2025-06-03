namespace QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice
{
    partial class PurchaseInvoiceInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseInvoiceInputView));
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            panel3 = new Panel();
            dgv_ProductList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btn_SelectReceiptNote = new MaterialSkin.Controls.MaterialButton();
            cbb_Suppliers = new ComboBox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            cbb_PaymentMethod = new ComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            cbb_Status = new ComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker = new DateTimePicker();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            rtb_Note = new RichTextBox();
            label1 = new Label();
            CreatorName = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            pane_Payment = new Panel();
            dtp_PaymentDate = new DateTimePicker();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            label11 = new Label();
            nmr_TotalAmountOwed = new NumericUpDown();
            nmr_TotalPaid = new NumericUpDown();
            dtp_DueDate = new DateTimePicker();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            dtp_TransactionDate = new DateTimePicker();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            label10 = new Label();
            nmr_TotalPaymentRequired = new NumericUpDown();
            label7 = new Label();
            textbox34 = new Label();
            label4 = new Label();
            cbb_Categories = new ComboBox();
            label5 = new Label();
            cbb_Units = new ComboBox();
            label6 = new Label();
            nmr_Quantity = new NumericUpDown();
            label8 = new Label();
            rtb_ProductNote = new RichTextBox();
            label9 = new Label();
            cbb_Products = new ComboBox();
            nmr_ConversionRate = new NumericUpDown();
            nmr_Price = new NumericUpDown();
            label3 = new Label();
            panel1 = new Panel();
            btn_Cancel = new Button();
            btn_DeleteProduct = new Button();
            btn_UpdateProduct = new Button();
            btn_AddProduct = new Button();
            panel2 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            groupBox1.SuspendLayout();
            pane_Payment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalAmountOwed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(589, 16);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(132, 42);
            btn_Save.TabIndex = 0;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_Save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 812);
            panel3.Name = "panel3";
            panel3.Size = new Size(1310, 52);
            panel3.TabIndex = 41;
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, Price, Quantity, Note });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(0, 475);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1310, 275);
            dgv_ProductList.TabIndex = 0;
            dgv_ProductList.RowPrePaint += dgv_ProductList_RowPrePaint;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Tên sản phẩm";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "CategoryName";
            CategoryName.HeaderText = "Tên danh mục";
            CategoryName.MinimumWidth = 6;
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            // 
            // UnitName
            // 
            UnitName.DataPropertyName = "UnitName";
            UnitName.HeaderText = "Tên đơn vị tính";
            UnitName.MinimumWidth = 6;
            UnitName.Name = "UnitName";
            UnitName.ReadOnly = true;
            // 
            // ConversionRate
            // 
            ConversionRate.DataPropertyName = "ConversionRate";
            ConversionRate.HeaderText = "Tỷ lệ chuyển đổi";
            ConversionRate.MinimumWidth = 6;
            ConversionRate.Name = "ConversionRate";
            ConversionRate.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            Price.DefaultCellStyle = dataGridViewCellStyle1;
            Price.HeaderText = "Giá tiền";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Số lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Note
            // 
            Note.DataPropertyName = "Note";
            Note.HeaderText = "Ghi chú";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            Note.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_SelectReceiptNote);
            groupBox1.Controls.Add(cbb_Suppliers);
            groupBox1.Controls.Add(materialLabel6);
            groupBox1.Controls.Add(cbb_PaymentMethod);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(cbb_Status);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(dateTimePicker);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(rtb_Note);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CreatorName);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1310, 171);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hóa đơn";
            // 
            // btn_SelectReceiptNote
            // 
            btn_SelectReceiptNote.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_SelectReceiptNote.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_SelectReceiptNote.Depth = 0;
            btn_SelectReceiptNote.HighEmphasis = true;
            btn_SelectReceiptNote.Icon = null;
            btn_SelectReceiptNote.Location = new Point(36, 113);
            btn_SelectReceiptNote.Margin = new Padding(4, 6, 4, 6);
            btn_SelectReceiptNote.MouseState = MaterialSkin.MouseState.HOVER;
            btn_SelectReceiptNote.Name = "btn_SelectReceiptNote";
            btn_SelectReceiptNote.NoAccentTextColor = Color.Empty;
            btn_SelectReceiptNote.Size = new Size(152, 36);
            btn_SelectReceiptNote.TabIndex = 6;
            btn_SelectReceiptNote.Text = "Chọn phiếu nhập";
            btn_SelectReceiptNote.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_SelectReceiptNote.UseAccentColor = false;
            btn_SelectReceiptNote.UseVisualStyleBackColor = true;
            btn_SelectReceiptNote.Click += btn_SelectReceiptNote_Click;
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(335, 54);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(250, 28);
            cbb_Suppliers.TabIndex = 1;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(336, 32);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(99, 19);
            materialLabel6.TabIndex = 39;
            materialLabel6.Text = "Nhà cung cấp";
            // 
            // cbb_PaymentMethod
            // 
            cbb_PaymentMethod.FormattingEnabled = true;
            cbb_PaymentMethod.Location = new Point(335, 121);
            cbb_PaymentMethod.Name = "cbb_PaymentMethod";
            cbb_PaymentMethod.Size = new Size(250, 28);
            cbb_PaymentMethod.TabIndex = 2;
            cbb_PaymentMethod.SelectedIndexChanged += cbb_PaymentMethod_SelectedIndexChanged;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(336, 99);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(174, 19);
            materialLabel4.TabIndex = 37;
            materialLabel4.Text = "Phương thức thanh toán";
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(628, 54);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(250, 28);
            cbb_Status.TabIndex = 3;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(629, 32);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(74, 19);
            materialLabel2.TabIndex = 31;
            materialLabel2.Text = "Trạng thái";
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "dd/MM/yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(627, 122);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 4;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(627, 99);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(64, 19);
            materialLabel1.TabIndex = 28;
            materialLabel1.Text = "Ngày lập";
            // 
            // rtb_Note
            // 
            rtb_Note.BorderStyle = BorderStyle.None;
            rtb_Note.Location = new Point(916, 51);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(362, 98);
            rtb_Note.TabIndex = 5;
            rtb_Note.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 32);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 25;
            label1.Text = "Tên người lập";
            // 
            // CreatorName
            // 
            CreatorName.Location = new Point(36, 55);
            CreatorName.Name = "CreatorName";
            CreatorName.Size = new Size(256, 27);
            CreatorName.TabIndex = 0;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(916, 32);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(55, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Ghi chú";
            // 
            // pane_Payment
            // 
            pane_Payment.Controls.Add(dtp_PaymentDate);
            pane_Payment.Controls.Add(materialLabel8);
            pane_Payment.Controls.Add(label11);
            pane_Payment.Controls.Add(nmr_TotalAmountOwed);
            pane_Payment.Controls.Add(nmr_TotalPaid);
            pane_Payment.Controls.Add(dtp_DueDate);
            pane_Payment.Controls.Add(materialLabel7);
            pane_Payment.Controls.Add(dtp_TransactionDate);
            pane_Payment.Controls.Add(materialLabel3);
            pane_Payment.Controls.Add(label10);
            pane_Payment.Dock = DockStyle.Top;
            pane_Payment.Location = new Point(0, 171);
            pane_Payment.Name = "pane_Payment";
            pane_Payment.Size = new Size(1310, 114);
            pane_Payment.TabIndex = 43;
            // 
            // dtp_PaymentDate
            // 
            dtp_PaymentDate.CustomFormat = "dd/MM/yyyy";
            dtp_PaymentDate.Enabled = false;
            dtp_PaymentDate.Format = DateTimePickerFormat.Custom;
            dtp_PaymentDate.Location = new Point(830, 47);
            dtp_PaymentDate.Name = "dtp_PaymentDate";
            dtp_PaymentDate.Size = new Size(175, 27);
            dtp_PaymentDate.TabIndex = 3;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(830, 25);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(119, 19);
            materialLabel8.TabIndex = 62;
            materialLabel8.Text = "Ngày thanh toán";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1094, 25);
            label11.Name = "label11";
            label11.Size = new Size(121, 20);
            label11.TabIndex = 48;
            label11.Text = "Tổng tiền còn nợ";
            // 
            // nmr_TotalAmountOwed
            // 
            nmr_TotalAmountOwed.Enabled = false;
            nmr_TotalAmountOwed.Location = new Point(1094, 47);
            nmr_TotalAmountOwed.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalAmountOwed.Name = "nmr_TotalAmountOwed";
            nmr_TotalAmountOwed.Size = new Size(175, 27);
            nmr_TotalAmountOwed.TabIndex = 4;
            nmr_TotalAmountOwed.ThousandsSeparator = true;
            // 
            // nmr_TotalPaid
            // 
            nmr_TotalPaid.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nmr_TotalPaid.Location = new Point(49, 48);
            nmr_TotalPaid.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalPaid.Name = "nmr_TotalPaid";
            nmr_TotalPaid.Size = new Size(175, 27);
            nmr_TotalPaid.TabIndex = 0;
            nmr_TotalPaid.ThousandsSeparator = true;
            // 
            // dtp_DueDate
            // 
            dtp_DueDate.CustomFormat = "dd/MM/yyyy";
            dtp_DueDate.Enabled = false;
            dtp_DueDate.Format = DateTimePickerFormat.Custom;
            dtp_DueDate.Location = new Point(570, 48);
            dtp_DueDate.Name = "dtp_DueDate";
            dtp_DueDate.Size = new Size(175, 27);
            dtp_DueDate.TabIndex = 2;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(570, 26);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(101, 19);
            materialLabel7.TabIndex = 45;
            materialLabel7.Text = "Ngày đáo hạn";
            // 
            // dtp_TransactionDate
            // 
            dtp_TransactionDate.CustomFormat = "dd/MM/yyyy";
            dtp_TransactionDate.Enabled = false;
            dtp_TransactionDate.Format = DateTimePickerFormat.Custom;
            dtp_TransactionDate.Location = new Point(312, 48);
            dtp_TransactionDate.Name = "dtp_TransactionDate";
            dtp_TransactionDate.Size = new Size(175, 27);
            dtp_TransactionDate.TabIndex = 1;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(312, 26);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(107, 19);
            materialLabel3.TabIndex = 42;
            materialLabel3.Text = "Ngày giao dịch";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 26);
            label10.Name = "label10";
            label10.Size = new Size(168, 20);
            label10.TabIndex = 43;
            label10.Text = "Tổng tiền đã thanh toán";
            // 
            // nmr_TotalPaymentRequired
            // 
            nmr_TotalPaymentRequired.Enabled = false;
            nmr_TotalPaymentRequired.Location = new Point(1085, 18);
            nmr_TotalPaymentRequired.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalPaymentRequired.Name = "nmr_TotalPaymentRequired";
            nmr_TotalPaymentRequired.Size = new Size(210, 27);
            nmr_TotalPaymentRequired.TabIndex = 49;
            nmr_TotalPaymentRequired.ThousandsSeparator = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(893, 22);
            label7.Name = "label7";
            label7.Size = new Size(177, 20);
            label7.TabIndex = 0;
            label7.Text = "Tổng tiền cần thanh toán:";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(39, 11);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 2;
            textbox34.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 67);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 4;
            label4.Text = "Tên danh mục";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(39, 89);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 1;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 121);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên đơn vị tính";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(39, 143);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 2;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(299, 11);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 8;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(299, 90);
            nmr_Quantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmr_Quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 4;
            nmr_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Quantity.ValueChanged += nmr_Quantity_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(299, 67);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 13;
            label8.Text = "Số lượng";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(509, 33);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(341, 138);
            rtb_ProductNote.TabIndex = 6;
            rtb_ProductNote.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(509, 9);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 15;
            label9.Text = "Ghi chú";
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(39, 34);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 0;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Location = new Point(299, 36);
            nmr_ConversionRate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmr_ConversionRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 3;
            nmr_ConversionRate.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmr_Price
            // 
            nmr_Price.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nmr_Price.Location = new Point(299, 144);
            nmr_Price.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Price.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Price.Name = "nmr_Price";
            nmr_Price.Size = new Size(150, 27);
            nmr_Price.TabIndex = 5;
            nmr_Price.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 121);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 25;
            label3.Text = "Giá bán";
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Cancel);
            panel1.Controls.Add(btn_DeleteProduct);
            panel1.Controls.Add(btn_UpdateProduct);
            panel1.Controls.Add(btn_AddProduct);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nmr_Price);
            panel1.Controls.Add(nmr_ConversionRate);
            panel1.Controls.Add(cbb_Products);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(rtb_ProductNote);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(nmr_Quantity);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbb_Units);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbb_Categories);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textbox34);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(1310, 190);
            panel1.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(1103, 56);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 9;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.Location = new Point(1103, 102);
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.Size = new Size(94, 29);
            btn_DeleteProduct.TabIndex = 10;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.UseVisualStyleBackColor = true;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.Location = new Point(994, 102);
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.Size = new Size(94, 29);
            btn_UpdateProduct.TabIndex = 8;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.Location = new Point(994, 55);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(94, 29);
            btn_AddProduct.TabIndex = 7;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.UseVisualStyleBackColor = true;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(nmr_TotalPaymentRequired);
            panel2.Controls.Add(label7);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 750);
            panel2.Name = "panel2";
            panel2.Size = new Size(1310, 62);
            panel2.TabIndex = 10;
            // 
            // PurchaseInvoiceInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1310, 864);
            Controls.Add(dgv_ProductList);
            Controls.Add(panel1);
            Controls.Add(pane_Payment);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PurchaseInvoiceInputView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa đơn nhập hàng";
            Load += PurchaseInvoiceInputView_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pane_Payment.ResumeLayout(false);
            pane_Payment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalAmountOwed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaid).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private Panel panel3;
        private DataGridView dgv_ProductList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
        private GroupBox groupBox1;
        private ComboBox cbb_PaymentMethod;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private ComboBox cbb_Status;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private DateTimePicker dateTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private RichTextBox rtb_Note;
        private Label label1;
        private TextBox CreatorName;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Panel pane_Payment;
        private Label textbox34;
        private Label label4;
        private ComboBox cbb_Categories;
        private Label label5;
        private ComboBox cbb_Units;
        private Label label6;
        private NumericUpDown nmr_Quantity;
        private Label label8;
        private RichTextBox rtb_ProductNote;
        private Label label9;
        private ComboBox cbb_Products;
        private NumericUpDown nmr_ConversionRate;
        private NumericUpDown nmr_Price;
        private Label label3;
        private Panel panel1;
        private ComboBox cbb_Suppliers;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialButton btn_SelectReceiptNote;
        private Label label10;
        private Label label7;
        private DateTimePicker dtp_DueDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private DateTimePicker dtp_TransactionDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Label label11;
        private NumericUpDown nmr_TotalAmountOwed;
        private NumericUpDown nmr_TotalPaid;
        private NumericUpDown nmr_TotalPaymentRequired;
        private DateTimePicker dtp_PaymentDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private Button btn_Cancel;
        private Button btn_DeleteProduct;
        private Button btn_UpdateProduct;
        private Button btn_AddProduct;
        private Panel panel2;
    }
}