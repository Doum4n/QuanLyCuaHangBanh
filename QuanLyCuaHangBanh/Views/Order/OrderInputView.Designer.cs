namespace QuanLyCuaHangBanh.Views.Order
{
    partial class OrderInputView
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
            rtb_DeliverAddress = new RichTextBox();
            tb_PhoneNumber = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            cbb_Customer = new ComboBox();
            dtpicker = new DateTimePicker();
            label2 = new Label();
            cbb_Status = new ComboBox();
            label3 = new Label();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            tb_TypeCustomer = new TextBox();
            label11 = new Label();
            label12 = new Label();
            cbb_PaymentMethods = new ComboBox();
            tabPage1 = new TabPage();
            dgv_ProductList = new DataGridView();
            panel2 = new Panel();
            btn_UpdateProduct = new Button();
            btn_AddProduct = new Button();
            label13 = new Label();
            nmr_Price = new NumericUpDown();
            nmr_ConversionRate = new NumericUpDown();
            label9 = new Label();
            rtb_ProductNote = new RichTextBox();
            label8 = new Label();
            nmr_Quantity = new NumericUpDown();
            label6 = new Label();
            cbb_Units = new ComboBox();
            label7 = new Label();
            groupBox1 = new GroupBox();
            btn_DeleteProduct = new Button();
            btn_Cancel = new Button();
            cbb_Products = new ComboBox();
            textbox34 = new Label();
            cbb_Categories = new ComboBox();
            label10 = new Label();
            panel4 = new Panel();
            nmr_TotalPaymentRequired = new NumericUpDown();
            label14 = new Label();
            panel3 = new Panel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dgv_ReleaseList = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            ReleasedProductName = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            CreatedBy = new DataGridViewTextBoxColumn();
            ReleaseDate = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            groupBox1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).BeginInit();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ReleaseList).BeginInit();
            SuspendLayout();
            // 
            // rtb_DeliverAddress
            // 
            rtb_DeliverAddress.BorderStyle = BorderStyle.None;
            rtb_DeliverAddress.Location = new Point(699, 55);
            rtb_DeliverAddress.Name = "rtb_DeliverAddress";
            rtb_DeliverAddress.Size = new Size(303, 91);
            rtb_DeliverAddress.TabIndex = 21;
            rtb_DeliverAddress.Text = "";
            // 
            // tb_PhoneNumber
            // 
            tb_PhoneNumber.Enabled = false;
            tb_PhoneNumber.Location = new Point(37, 119);
            tb_PhoneNumber.Name = "tb_PhoneNumber";
            tb_PhoneNumber.Size = new Size(201, 27);
            tb_PhoneNumber.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(699, 27);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 17;
            label5.Text = "Địa chỉ nhận";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 96);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 16;
            label4.Text = "Số điện thoại";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 32);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 13;
            label1.Text = "Tên khách hàng";
            // 
            // cbb_Customer
            // 
            cbb_Customer.FormattingEnabled = true;
            cbb_Customer.Location = new Point(39, 55);
            cbb_Customer.Name = "cbb_Customer";
            cbb_Customer.Size = new Size(201, 28);
            cbb_Customer.TabIndex = 26;
            cbb_Customer.SelectedIndexChanged += cbb_Customer_SelectedIndexChanged;
            // 
            // dtpicker
            // 
            dtpicker.CustomFormat = "dd/MM/yyyy";
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.Location = new Point(464, 120);
            dtpicker.Name = "dtpicker";
            dtpicker.Size = new Size(163, 27);
            dtpicker.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(464, 96);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 28;
            label2.Text = "Ngày đặt";
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(268, 119);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(168, 28);
            cbb_Status.TabIndex = 29;
            cbb_Status.SelectedIndexChanged += cbb_Status_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 96);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 30;
            label3.Text = "Trạng thái";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 181);
            panel1.TabIndex = 31;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tb_TypeCustomer);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cbb_PaymentMethods);
            groupBox2.Controls.Add(rtb_DeliverAddress);
            groupBox2.Controls.Add(dtpicker);
            groupBox2.Controls.Add(cbb_Customer);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(tb_PhoneNumber);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cbb_Status);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1266, 181);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // tb_TypeCustomer
            // 
            tb_TypeCustomer.Enabled = false;
            tb_TypeCustomer.Location = new Point(268, 57);
            tb_TypeCustomer.Name = "tb_TypeCustomer";
            tb_TypeCustomer.Size = new Size(168, 27);
            tb_TypeCustomer.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(270, 29);
            label11.Name = "label11";
            label11.Size = new Size(116, 20);
            label11.TabIndex = 33;
            label11.Text = "Loại khách hàng";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(467, 27);
            label12.Name = "label12";
            label12.Size = new Size(168, 20);
            label12.TabIndex = 32;
            label12.Text = "Phương thức thanh toán";
            // 
            // cbb_PaymentMethods
            // 
            cbb_PaymentMethods.FormattingEnabled = true;
            cbb_PaymentMethods.Location = new Point(467, 56);
            cbb_PaymentMethods.Name = "cbb_PaymentMethods";
            cbb_PaymentMethods.Size = new Size(194, 28);
            cbb_PaymentMethods.TabIndex = 31;
            cbb_PaymentMethods.SelectedIndexChanged += cbb_PaymentMethods_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgv_ProductList);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel3);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1258, 548);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sản phẩm";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, Price, Quantity, Note });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(3, 180);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1252, 244);
            dgv_ProductList.TabIndex = 34;
            dgv_ProductList.RowPrePaint += dgv_ProductList_RowPrePaint;
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_UpdateProduct);
            panel2.Controls.Add(btn_AddProduct);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(nmr_Price);
            panel2.Controls.Add(nmr_ConversionRate);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(rtb_ProductNote);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(nmr_Quantity);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbb_Units);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1252, 177);
            panel2.TabIndex = 32;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.Location = new Point(1019, 98);
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.Size = new Size(94, 29);
            btn_UpdateProduct.TabIndex = 44;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.BackColor = Color.Lime;
            btn_AddProduct.Location = new Point(1019, 57);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(94, 29);
            btn_AddProduct.TabIndex = 43;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.UseVisualStyleBackColor = false;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(266, 90);
            label13.Name = "label13";
            label13.Size = new Size(60, 20);
            label13.TabIndex = 42;
            label13.Text = "Giá bán";
            // 
            // nmr_Price
            // 
            nmr_Price.Location = new Point(266, 113);
            nmr_Price.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Price.Name = "nmr_Price";
            nmr_Price.Size = new Size(197, 27);
            nmr_Price.TabIndex = 41;
            nmr_Price.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Enabled = false;
            nmr_ConversionRate.Location = new Point(504, 57);
            nmr_ConversionRate.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nmr_ConversionRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 38;
            nmr_ConversionRate.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(692, 30);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 35;
            label9.Text = "Ghi chú";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(692, 54);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(303, 89);
            rtb_ProductNote.TabIndex = 34;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(504, 93);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 33;
            label8.Text = "Số lượng";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(504, 116);
            nmr_Quantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmr_Quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 32;
            nmr_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(504, 32);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 31;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(266, 56);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 30;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(266, 34);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 29;
            label7.Text = "Tên đơn vị tính";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_DeleteProduct);
            groupBox1.Controls.Add(btn_Cancel);
            groupBox1.Controls.Add(cbb_Products);
            groupBox1.Controls.Add(textbox34);
            groupBox1.Controls.Add(cbb_Categories);
            groupBox1.Controls.Add(label10);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1252, 177);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.BackColor = Color.Red;
            btn_DeleteProduct.Location = new Point(1145, 98);
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.Size = new Size(94, 29);
            btn_DeleteProduct.TabIndex = 45;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.UseVisualStyleBackColor = false;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.BackColor = Color.Transparent;
            btn_Cancel.Location = new Point(1145, 57);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 46;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = false;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(36, 112);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 37;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(36, 89);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 26;
            textbox34.Text = "Tên sản phẩm";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(36, 56);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 28;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 34);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 27;
            label10.Text = "Tên danh mục";
            // 
            // panel4
            // 
            panel4.Controls.Add(nmr_TotalPaymentRequired);
            panel4.Controls.Add(label14);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(3, 424);
            panel4.Name = "panel4";
            panel4.Size = new Size(1252, 48);
            panel4.TabIndex = 26;
            // 
            // nmr_TotalPaymentRequired
            // 
            nmr_TotalPaymentRequired.Enabled = false;
            nmr_TotalPaymentRequired.Location = new Point(1031, 13);
            nmr_TotalPaymentRequired.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalPaymentRequired.Name = "nmr_TotalPaymentRequired";
            nmr_TotalPaymentRequired.Size = new Size(210, 27);
            nmr_TotalPaymentRequired.TabIndex = 51;
            nmr_TotalPaymentRequired.ThousandsSeparator = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(839, 17);
            label14.Name = "label14";
            label14.Size = new Size(177, 20);
            label14.TabIndex = 50;
            label14.Text = "Tổng tiền cần thanh toán:";
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_Save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(3, 472);
            panel3.Name = "panel3";
            panel3.Size = new Size(1252, 73);
            panel3.TabIndex = 33;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(546, 18);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(158, 36);
            btn_Save.TabIndex = 25;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 181);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1266, 581);
            tabControl1.TabIndex = 47;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgv_ReleaseList);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1258, 548);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Phiếu xuất";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_ReleaseList
            // 
            dgv_ReleaseList.AllowUserToAddRows = false;
            dgv_ReleaseList.AllowUserToDeleteRows = false;
            dgv_ReleaseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReleaseList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ReleaseList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, ReleasedProductName, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn10, CreatedBy, ReleaseDate, dataGridViewTextBoxColumn13 });
            dgv_ReleaseList.Dock = DockStyle.Fill;
            dgv_ReleaseList.Location = new Point(3, 3);
            dgv_ReleaseList.Name = "dgv_ReleaseList";
            dgv_ReleaseList.ReadOnly = true;
            dgv_ReleaseList.RowHeadersWidth = 51;
            dgv_ReleaseList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReleaseList.Size = new Size(1252, 542);
            dgv_ReleaseList.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "ID";
            dataGridViewTextBoxColumn6.HeaderText = "ID";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // ReleasedProductName
            // 
            ReleasedProductName.DataPropertyName = "ReleasedProductName";
            ReleasedProductName.HeaderText = "Tên sản phẩm";
            ReleasedProductName.MinimumWidth = 6;
            ReleasedProductName.Name = "ReleasedProductName";
            ReleasedProductName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "UnitName";
            dataGridViewTextBoxColumn7.HeaderText = "Tên đơn vị tính";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "ConversionRate";
            dataGridViewTextBoxColumn8.HeaderText = "Tỷ lệ chuyển đổi";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "Quantity";
            dataGridViewTextBoxColumn10.HeaderText = "Số lượng";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // CreatedBy
            // 
            CreatedBy.DataPropertyName = "CreatedBy";
            CreatedBy.HeaderText = "Người lập";
            CreatedBy.MinimumWidth = 6;
            CreatedBy.Name = "CreatedBy";
            CreatedBy.ReadOnly = true;
            // 
            // ReleaseDate
            // 
            ReleaseDate.DataPropertyName = "ReleaseDate";
            ReleaseDate.HeaderText = "Ngày Xuất";
            ReleaseDate.MinimumWidth = 6;
            ReleaseDate.Name = "ReleaseDate";
            ReleaseDate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "Note";
            dataGridViewTextBoxColumn13.HeaderText = "Ghi chú";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
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
            // OrderInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 762);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "OrderInputView";
            Text = "Đơn đặt hàng";
            Load += OrderInputView_Load;
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Price).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalPaymentRequired).EndInit();
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ReleaseList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox rtb_DeliverAddress;
        private TextBox tb_PhoneNumber;
        private Label label5;
        private Label label4;
        private Label label1;
        private ComboBox cbb_Customer;
        private DateTimePicker dtpicker;
        private Label label2;
        private ComboBox cbb_Status;
        private Label label3;
        private Panel panel1;
        private Label label12;
        private ComboBox cbb_PaymentMethods;
        private TabPage tabPage1;
        private DataGridView dgv_ProductList;
        private Panel panel2;
        private Button btn_Cancel;
        private Button btn_DeleteProduct;
        private Button btn_UpdateProduct;
        private Button btn_AddProduct;
        private Label label13;
        private NumericUpDown nmr_Price;
        private NumericUpDown nmr_ConversionRate;
        private ComboBox cbb_Products;
        private Label label9;
        private RichTextBox rtb_ProductNote;
        private Label label8;
        private NumericUpDown nmr_Quantity;
        private Label label6;
        private ComboBox cbb_Units;
        private Label label7;
        private ComboBox cbb_Categories;
        private Label label10;
        private Label textbox34;
        private Panel panel4;
        private NumericUpDown nmr_TotalPaymentRequired;
        private Label label14;
        private Panel panel3;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private DataGridView dgv_ReleaseList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn ReleasedProductName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn CreatedBy;
        private DataGridViewTextBoxColumn ReleaseDate;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox tb_TypeCustomer;
        private Label label11;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
    }
}