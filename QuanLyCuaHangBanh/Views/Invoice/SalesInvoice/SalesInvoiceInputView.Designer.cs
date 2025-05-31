namespace QuanLyCuaHangBanh.Views.Invoice
{
    partial class SalesInvoiceInputView
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
            panel2 = new Panel();
            dgv_ProductList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            cbb_PaymentMethod = new ComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            cbb_Customers = new ComboBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            groupBox3 = new GroupBox();
            rbtn_GoodsReciveNote = new RadioButton();
            rbtn_Order = new RadioButton();
            cbb_Status = new ComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker = new DateTimePicker();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            rtb_Note = new RichTextBox();
            label1 = new Label();
            CreatorName = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            panel1 = new Panel();
            label3 = new Label();
            nmr_Price = new NumericUpDown();
            nmr_ConversionRate = new NumericUpDown();
            cbb_Products = new ComboBox();
            label9 = new Label();
            rtb_ProductNote = new RichTextBox();
            label8 = new Label();
            nmr_Quantity = new NumericUpDown();
            label6 = new Label();
            cbb_Units = new ComboBox();
            label5 = new Label();
            cbb_Categories = new ComboBox();
            label4 = new Label();
            textbox34 = new Label();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            panel3 = new Panel();
            pane_Payment = new Panel();
            dtp_PaymentDate = new DateTimePicker();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            nmr_TotalPaymentRequired = new NumericUpDown();
            label11 = new Label();
            nmr_TotalPaid = new NumericUpDown();
            dtp_DueDate = new DateTimePicker();
            nmr_TotalAmountOwed = new NumericUpDown();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            dtp_TransactionDate = new DateTimePicker();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            label10 = new Label();
            label7 = new Label();
            btn_AddProduct = new Button();
            btn_UpdateProduct = new Button();
            btn_DeleteProduct = new Button();
            btn_Cancel = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            panel3.SuspendLayout();
            pane_Payment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalAmountOwed).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Controls.Add(nmr_TotalPaymentRequired);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 830);
            panel2.Name = "panel2";
            panel2.Size = new Size(1294, 50);
            panel2.TabIndex = 35;
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, Price, Quantity, Note });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(3, 23);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1288, 305);
            dgv_ProductList.TabIndex = 0;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_ProductList);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 499);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1294, 331);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = " Danh sách sản phẩm";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbb_PaymentMethod);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(cbb_Customers);
            groupBox1.Controls.Add(materialLabel3);
            groupBox1.Controls.Add(groupBox3);
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
            groupBox1.Size = new Size(1294, 210);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hóa đơn";
            // 
            // cbb_PaymentMethod
            // 
            cbb_PaymentMethod.FormattingEnabled = true;
            cbb_PaymentMethod.Location = new Point(335, 121);
            cbb_PaymentMethod.Name = "cbb_PaymentMethod";
            cbb_PaymentMethod.Size = new Size(250, 28);
            cbb_PaymentMethod.TabIndex = 38;
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
            // cbb_Customers
            // 
            cbb_Customers.FormattingEnabled = true;
            cbb_Customers.Location = new Point(334, 54);
            cbb_Customers.Name = "cbb_Customers";
            cbb_Customers.Size = new Size(250, 28);
            cbb_Customers.TabIndex = 36;
            cbb_Customers.SelectedIndexChanged += cbb_Customers_SelectedIndexChanged;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(335, 32);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(86, 19);
            materialLabel3.TabIndex = 35;
            materialLabel3.Text = "Khách hàng";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbtn_GoodsReciveNote);
            groupBox3.Controls.Add(rbtn_Order);
            groupBox3.Location = new Point(36, 99);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(269, 99);
            groupBox3.TabIndex = 34;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lập hóa đơn từ";
            // 
            // rbtn_GoodsReciveNote
            // 
            rbtn_GoodsReciveNote.AutoSize = true;
            rbtn_GoodsReciveNote.Location = new Point(16, 56);
            rbtn_GoodsReciveNote.Name = "rbtn_GoodsReciveNote";
            rbtn_GoodsReciveNote.Size = new Size(103, 24);
            rbtn_GoodsReciveNote.TabIndex = 34;
            rbtn_GoodsReciveNote.TabStop = true;
            rbtn_GoodsReciveNote.Text = "Phiếu nhập";
            rbtn_GoodsReciveNote.UseVisualStyleBackColor = true;
            // 
            // rbtn_Order
            // 
            rbtn_Order.AutoSize = true;
            rbtn_Order.Location = new Point(16, 26);
            rbtn_Order.Name = "rbtn_Order";
            rbtn_Order.Size = new Size(95, 24);
            rbtn_Order.TabIndex = 33;
            rbtn_Order.TabStop = true;
            rbtn_Order.Text = "Đơn hàng";
            rbtn_Order.UseVisualStyleBackColor = true;
            rbtn_Order.CheckedChanged += rbtn_Order_CheckedChanged;
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(628, 54);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(250, 28);
            cbb_Status.TabIndex = 32;
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
            dateTimePicker.TabIndex = 30;
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
            rtb_Note.Location = new Point(916, 58);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(289, 98);
            rtb_Note.TabIndex = 27;
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
            CreatorName.Size = new Size(269, 27);
            CreatorName.TabIndex = 24;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(916, 36);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(55, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Ghi chú";
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
            panel1.Location = new Point(0, 318);
            panel1.Name = "panel1";
            panel1.Size = new Size(1294, 181);
            panel1.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(307, 125);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 25;
            label3.Text = "Giá bán";
            // 
            // nmr_Price
            // 
            nmr_Price.Location = new Point(307, 148);
            nmr_Price.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nmr_Price.Name = "nmr_Price";
            nmr_Price.Size = new Size(150, 27);
            nmr_Price.TabIndex = 24;
            nmr_Price.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Location = new Point(307, 40);
            nmr_ConversionRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nmr_ConversionRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 21;
            nmr_ConversionRate.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(47, 38);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 20;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(517, 13);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 15;
            label9.Text = "Ghi chú";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(517, 37);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(387, 138);
            rtb_ProductNote.TabIndex = 14;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(307, 71);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 13;
            label8.Text = "Số lượng";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(307, 94);
            nmr_Quantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmr_Quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 11;
            nmr_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(307, 15);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 8;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(47, 147);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 7;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 125);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(47, 93);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 71);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 4;
            label4.Text = "Tên danh mục";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(47, 15);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 2;
            textbox34.Text = "Tên sản phẩm";
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(562, 24);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(132, 42);
            btn_Save.TabIndex = 9;
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
            panel3.Location = new Point(0, 880);
            panel3.Name = "panel3";
            panel3.Size = new Size(1294, 75);
            panel3.TabIndex = 36;
            // 
            // pane_Payment
            // 
            pane_Payment.Controls.Add(dtp_PaymentDate);
            pane_Payment.Controls.Add(materialLabel8);
            pane_Payment.Controls.Add(label11);
            pane_Payment.Controls.Add(nmr_TotalPaid);
            pane_Payment.Controls.Add(dtp_DueDate);
            pane_Payment.Controls.Add(nmr_TotalAmountOwed);
            pane_Payment.Controls.Add(materialLabel7);
            pane_Payment.Controls.Add(dtp_TransactionDate);
            pane_Payment.Controls.Add(materialLabel6);
            pane_Payment.Controls.Add(label10);
            pane_Payment.Dock = DockStyle.Top;
            pane_Payment.Location = new Point(0, 210);
            pane_Payment.Name = "pane_Payment";
            pane_Payment.Size = new Size(1294, 108);
            pane_Payment.TabIndex = 38;
            // 
            // dtp_PaymentDate
            // 
            dtp_PaymentDate.CustomFormat = "dd/MM/yyyy";
            dtp_PaymentDate.Enabled = false;
            dtp_PaymentDate.Format = DateTimePickerFormat.Custom;
            dtp_PaymentDate.Location = new Point(1072, 46);
            dtp_PaymentDate.Name = "dtp_PaymentDate";
            dtp_PaymentDate.Size = new Size(175, 27);
            dtp_PaymentDate.TabIndex = 61;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(1072, 24);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(119, 19);
            materialLabel8.TabIndex = 60;
            materialLabel8.Text = "Ngày thanh toán";
            // 
            // nmr_TotalPaymentRequired
            // 
            nmr_TotalPaymentRequired.Enabled = false;
            nmr_TotalPaymentRequired.Location = new Point(1129, 11);
            nmr_TotalPaymentRequired.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalPaymentRequired.Name = "nmr_TotalPaymentRequired";
            nmr_TotalPaymentRequired.Size = new Size(197, 27);
            nmr_TotalPaymentRequired.TabIndex = 59;
            nmr_TotalPaymentRequired.ThousandsSeparator = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(307, 24);
            label11.Name = "label11";
            label11.Size = new Size(121, 20);
            label11.TabIndex = 58;
            label11.Text = "Tổng tiền còn nợ";
            // 
            // nmr_TotalPaid
            // 
            nmr_TotalPaid.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nmr_TotalPaid.Location = new Point(47, 46);
            nmr_TotalPaid.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalPaid.Name = "nmr_TotalPaid";
            nmr_TotalPaid.Size = new Size(175, 27);
            nmr_TotalPaid.TabIndex = 51;
            nmr_TotalPaid.ThousandsSeparator = true;
            // 
            // dtp_DueDate
            // 
            dtp_DueDate.CustomFormat = "dd/MM/yyyy";
            dtp_DueDate.Enabled = false;
            dtp_DueDate.Format = DateTimePickerFormat.Custom;
            dtp_DueDate.Location = new Point(825, 46);
            dtp_DueDate.Name = "dtp_DueDate";
            dtp_DueDate.Size = new Size(175, 27);
            dtp_DueDate.TabIndex = 56;
            // 
            // nmr_TotalAmountOwed
            // 
            nmr_TotalAmountOwed.Enabled = false;
            nmr_TotalAmountOwed.Location = new Point(307, 46);
            nmr_TotalAmountOwed.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalAmountOwed.Name = "nmr_TotalAmountOwed";
            nmr_TotalAmountOwed.Size = new Size(175, 27);
            nmr_TotalAmountOwed.TabIndex = 57;
            nmr_TotalAmountOwed.ThousandsSeparator = true;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(825, 24);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(101, 19);
            materialLabel7.TabIndex = 55;
            materialLabel7.Text = "Ngày đáo hạn";
            // 
            // dtp_TransactionDate
            // 
            dtp_TransactionDate.CustomFormat = "dd/MM/yyyy";
            dtp_TransactionDate.Enabled = false;
            dtp_TransactionDate.Format = DateTimePickerFormat.Custom;
            dtp_TransactionDate.Location = new Point(571, 46);
            dtp_TransactionDate.Name = "dtp_TransactionDate";
            dtp_TransactionDate.Size = new Size(175, 27);
            dtp_TransactionDate.TabIndex = 53;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(571, 24);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(107, 19);
            materialLabel6.TabIndex = 52;
            materialLabel6.Text = "Ngày giao dịch";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(41, 24);
            label10.Name = "label10";
            label10.Size = new Size(168, 20);
            label10.TabIndex = 54;
            label10.Text = "Tổng tiền đã thanh toán";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(941, 15);
            label7.Name = "label7";
            label7.Size = new Size(177, 20);
            label7.TabIndex = 50;
            label7.Text = "Tổng tiền cần thanh toán:";
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.Location = new Point(1006, 56);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(94, 29);
            btn_AddProduct.TabIndex = 26;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.UseVisualStyleBackColor = true;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.Location = new Point(1006, 106);
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.Size = new Size(94, 29);
            btn_UpdateProduct.TabIndex = 27;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.Location = new Point(1129, 56);
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.Size = new Size(94, 29);
            btn_DeleteProduct.TabIndex = 28;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.UseVisualStyleBackColor = true;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(1129, 106);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 29;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // SalesInvoiceInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 955);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(pane_Payment);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "SalesInvoiceInputView";
            Text = "InvoiceInputView";
            Load += InvoiceInputView_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            panel3.ResumeLayout(false);
            pane_Payment.ResumeLayout(false);
            pane_Payment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaid).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalAmountOwed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgv_ProductList;
        private GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private RadioButton rbtn_GoodsReciveNote;
        private RadioButton rbtn_Order;
        private ComboBox cbb_Status;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private DateTimePicker dateTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private RichTextBox rtb_Note;
        private Label label1;
        private TextBox CreatorName;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Panel panel1;
        private NumericUpDown nmr_ConversionRate;
        private ComboBox cbb_Products;
        private Label label9;
        private RichTextBox rtb_ProductNote;
        private Label label8;
        private NumericUpDown nmr_Quantity;
        private Label label6;
        private ComboBox cbb_Units;
        private Label label5;
        private ComboBox cbb_Categories;
        private Label label4;
        private Label textbox34;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private Panel panel3;
        private ComboBox cbb_Customers;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private ComboBox cbb_PaymentMethod;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private Label label3;
        private NumericUpDown nmr_Price;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
        private Panel pane_Payment;
        private NumericUpDown nmr_TotalPaymentRequired;
        private Label label11;
        private NumericUpDown nmr_TotalAmountOwed;
        private NumericUpDown nmr_TotalPaid;
        private DateTimePicker dtp_DueDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private DateTimePicker dtp_TransactionDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private Label label10;
        private Label label7;
        private DateTimePicker dtp_PaymentDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private Button btn_DeleteProduct;
        private Button btn_UpdateProduct;
        private Button btn_AddProduct;
        private Button btn_Cancel;
    }
}