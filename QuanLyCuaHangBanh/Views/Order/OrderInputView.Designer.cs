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
            btn_Save = new MaterialSkin.Controls.MaterialButton();
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
            label12 = new Label();
            cbb_PaymentMethods = new ComboBox();
            panel2 = new Panel();
            btn_DeleteProduct = new MaterialSkin.Controls.MaterialButton();
            btn_UpdateProduct = new MaterialSkin.Controls.MaterialButton();
            nmr_ConversionRate = new NumericUpDown();
            btn_AddProduct = new MaterialSkin.Controls.MaterialButton();
            cbb_Products = new ComboBox();
            label9 = new Label();
            rtb_ProductNote = new RichTextBox();
            label8 = new Label();
            nmr_Quantity = new NumericUpDown();
            label6 = new Label();
            cbb_Units = new ComboBox();
            label7 = new Label();
            cbb_Categories = new ComboBox();
            label10 = new Label();
            textbox34 = new Label();
            tb_Id = new TextBox();
            label11 = new Label();
            panel3 = new Panel();
            dgv_ProductList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            PurchasePrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
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
            // rtb_DeliverAddress
            // 
            rtb_DeliverAddress.BorderStyle = BorderStyle.None;
            rtb_DeliverAddress.Location = new Point(791, 60);
            rtb_DeliverAddress.Name = "rtb_DeliverAddress";
            rtb_DeliverAddress.Size = new Size(228, 110);
            rtb_DeliverAddress.TabIndex = 21;
            rtb_DeliverAddress.Text = "";
            // 
            // tb_PhoneNumber
            // 
            tb_PhoneNumber.Location = new Point(16, 134);
            tb_PhoneNumber.Name = "tb_PhoneNumber";
            tb_PhoneNumber.Size = new Size(213, 27);
            tb_PhoneNumber.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(791, 26);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 17;
            label5.Text = "Địa chỉ nhận";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 95);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 16;
            label4.Text = "Số điện thoại";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 21);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 13;
            label1.Text = "Tên khách hàng";
            // 
            // cbb_Customer
            // 
            cbb_Customer.FormattingEnabled = true;
            cbb_Customer.Location = new Point(16, 55);
            cbb_Customer.Name = "cbb_Customer";
            cbb_Customer.Size = new Size(213, 28);
            cbb_Customer.TabIndex = 26;
            // 
            // dtpicker
            // 
            dtpicker.CustomFormat = "dd/MM/yyyy";
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.Location = new Point(300, 55);
            dtpicker.Name = "dtpicker";
            dtpicker.Size = new Size(163, 27);
            dtpicker.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 25);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 28;
            label2.Text = "Ngày đặt";
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(300, 134);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(151, 28);
            cbb_Status.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 95);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 30;
            label3.Text = "Trạng thái";
            // 
            // panel1
            // 
            panel1.Controls.Add(label12);
            panel1.Controls.Add(cbb_PaymentMethods);
            panel1.Controls.Add(dtpicker);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbb_Status);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(tb_PhoneNumber);
            panel1.Controls.Add(cbb_Customer);
            panel1.Controls.Add(rtb_DeliverAddress);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 215);
            panel1.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(546, 25);
            label12.Name = "label12";
            label12.Size = new Size(168, 20);
            label12.TabIndex = 32;
            label12.Text = "Phương thức thanh toán";
            // 
            // cbb_PaymentMethods
            // 
            cbb_PaymentMethods.FormattingEnabled = true;
            cbb_PaymentMethods.Location = new Point(546, 54);
            cbb_PaymentMethods.Name = "cbb_PaymentMethods";
            cbb_PaymentMethods.Size = new Size(151, 28);
            cbb_PaymentMethods.TabIndex = 31;
            cbb_PaymentMethods.SelectedIndexChanged += cbb_PaymentMethods_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_DeleteProduct);
            panel2.Controls.Add(btn_UpdateProduct);
            panel2.Controls.Add(nmr_ConversionRate);
            panel2.Controls.Add(btn_AddProduct);
            panel2.Controls.Add(cbb_Products);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(rtb_ProductNote);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(nmr_Quantity);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbb_Units);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cbb_Categories);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textbox34);
            panel2.Controls.Add(tb_Id);
            panel2.Controls.Add(label11);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 215);
            panel2.Name = "panel2";
            panel2.Size = new Size(1251, 181);
            panel2.TabIndex = 32;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.AutoSize = false;
            btn_DeleteProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DeleteProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_DeleteProduct.Depth = 0;
            btn_DeleteProduct.HighEmphasis = true;
            btn_DeleteProduct.Icon = null;
            btn_DeleteProduct.Location = new Point(1134, 118);
            btn_DeleteProduct.Margin = new Padding(4, 6, 4, 6);
            btn_DeleteProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.NoAccentTextColor = Color.Empty;
            btn_DeleteProduct.Size = new Size(79, 32);
            btn_DeleteProduct.TabIndex = 40;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_DeleteProduct.UseAccentColor = false;
            btn_DeleteProduct.UseVisualStyleBackColor = true;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.AutoSize = false;
            btn_UpdateProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_UpdateProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_UpdateProduct.Depth = 0;
            btn_UpdateProduct.HighEmphasis = true;
            btn_UpdateProduct.Icon = null;
            btn_UpdateProduct.Location = new Point(1134, 74);
            btn_UpdateProduct.Margin = new Padding(4, 6, 4, 6);
            btn_UpdateProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.NoAccentTextColor = Color.Empty;
            btn_UpdateProduct.Size = new Size(79, 32);
            btn_UpdateProduct.TabIndex = 39;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_UpdateProduct.UseAccentColor = false;
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Location = new Point(504, 57);
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 38;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.AutoSize = false;
            btn_AddProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_AddProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_AddProduct.Depth = 0;
            btn_AddProduct.HighEmphasis = true;
            btn_AddProduct.Icon = null;
            btn_AddProduct.Location = new Point(1134, 33);
            btn_AddProduct.Margin = new Padding(4, 6, 4, 6);
            btn_AddProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.NoAccentTextColor = Color.Empty;
            btn_AddProduct.Size = new Size(79, 32);
            btn_AddProduct.TabIndex = 36;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_AddProduct.UseAccentColor = false;
            btn_AddProduct.UseVisualStyleBackColor = true;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(37, 110);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 37;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
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
            rtb_ProductNote.Size = new Size(387, 84);
            rtb_ProductNote.TabIndex = 34;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(504, 88);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 33;
            label8.Text = "Số lượng";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(504, 111);
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
            cbb_Units.Location = new Point(263, 108);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 30;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(263, 86);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 29;
            label7.Text = "Tên đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(263, 54);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(263, 32);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 27;
            label10.Text = "Tên danh mục";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(37, 87);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 26;
            textbox34.Text = "Tên sản phẩm";
            // 
            // tb_Id
            // 
            tb_Id.Enabled = false;
            tb_Id.Location = new Point(37, 56);
            tb_Id.Name = "tb_Id";
            tb_Id.Size = new Size(125, 27);
            tb_Id.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 33);
            label11.Name = "label11";
            label11.Size = new Size(30, 20);
            label11.TabIndex = 24;
            label11.Text = "Mã";
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_Save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 617);
            panel3.Name = "panel3";
            panel3.Size = new Size(1251, 73);
            panel3.TabIndex = 33;
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, PurchasePrice, Quantity, Note });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(0, 396);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1251, 221);
            dgv_ProductList.TabIndex = 34;
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
            // PurchasePrice
            // 
            PurchasePrice.DataPropertyName = "PurchasePrice";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            PurchasePrice.DefaultCellStyle = dataGridViewCellStyle1;
            PurchasePrice.HeaderText = "Giá tiền";
            PurchasePrice.MinimumWidth = 6;
            PurchasePrice.Name = "PurchasePrice";
            PurchasePrice.ReadOnly = true;
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
            ClientSize = new Size(1251, 690);
            Controls.Add(dgv_ProductList);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "OrderInputView";
            Text = "Đơn đặt hàng";
            Load += OrderInputView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btn_Save;
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
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgv_ProductList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn PurchasePrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
        private MaterialSkin.Controls.MaterialButton btn_DeleteProduct;
        private MaterialSkin.Controls.MaterialButton btn_UpdateProduct;
        private NumericUpDown nmr_ConversionRate;
        private MaterialSkin.Controls.MaterialButton btn_AddProduct;
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
        private TextBox tb_Id;
        private Label label11;
        private Label label12;
        private ComboBox cbb_PaymentMethods;
    }
}