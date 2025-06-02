namespace QuanLyCuaHangBanh.Views
{
    partial class GoodsReceiptNoteInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceiptNoteInputView));
            dgv_ProductList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            PurchasePrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            ProductionDate = new DataGridViewTextBoxColumn();
            ExpirationDate = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            cbb_Status = new ComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker = new DateTimePicker();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            rtb_Note = new RichTextBox();
            cbb_Suppliers = new ComboBox();
            label1 = new Label();
            CreatorName = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            panel3 = new Panel();
            panel1 = new Panel();
            btn_Cancel = new Button();
            btn_DeleteProduct = new Button();
            btn_UpdateProduct = new Button();
            btn_Add = new Button();
            label3 = new Label();
            dtp_ExpirationDate = new DateTimePicker();
            nmr_PurchasePrice = new NumericUpDown();
            label10 = new Label();
            nmr_ConversionRate = new NumericUpDown();
            cbb_Products = new ComboBox();
            dtp_ProductionDate = new DateTimePicker();
            label9 = new Label();
            rtb_ProductNote = new RichTextBox();
            label8 = new Label();
            label7 = new Label();
            nmr_Quantity = new NumericUpDown();
            label6 = new Label();
            cbb_Units = new ComboBox();
            label5 = new Label();
            cbb_Categories = new ComboBox();
            label4 = new Label();
            textbox34 = new Label();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_PurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            SuspendLayout();
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, PurchasePrice, Quantity, Note, ProductionDate, ExpirationDate });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(3, 23);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1484, 233);
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
            // ProductionDate
            // 
            ProductionDate.DataPropertyName = "ProductionDate";
            ProductionDate.HeaderText = "Ngày sản xuất";
            ProductionDate.MinimumWidth = 6;
            ProductionDate.Name = "ProductionDate";
            ProductionDate.ReadOnly = true;
            // 
            // ExpirationDate
            // 
            ExpirationDate.DataPropertyName = "ExpirationDate";
            ExpirationDate.HeaderText = "Ngày hết hạn";
            ExpirationDate.MinimumWidth = 6;
            ExpirationDate.Name = "ExpirationDate";
            ExpirationDate.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_ProductList);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 362);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1490, 259);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = " Danh sách sản phẩm";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbb_Status);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(dateTimePicker);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(rtb_Note);
            groupBox1.Controls.Add(cbb_Suppliers);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CreatorName);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(materialLabel3);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1490, 176);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(250, 56);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(202, 28);
            cbb_Status.TabIndex = 1;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(251, 34);
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
            dateTimePicker.Location = new Point(250, 124);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(202, 27);
            dateTimePicker.TabIndex = 3;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(250, 101);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(64, 19);
            materialLabel1.TabIndex = 28;
            materialLabel1.Text = "Ngày lập";
            // 
            // rtb_Note
            // 
            rtb_Note.BorderStyle = BorderStyle.None;
            rtb_Note.Location = new Point(493, 53);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(338, 98);
            rtb_Note.TabIndex = 4;
            rtb_Note.Text = "";
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(19, 56);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(202, 28);
            cbb_Suppliers.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 101);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 25;
            label1.Text = "Tên người lập";
            // 
            // CreatorName
            // 
            CreatorName.Enabled = false;
            CreatorName.Location = new Point(19, 124);
            CreatorName.Name = "CreatorName";
            CreatorName.Size = new Size(202, 27);
            CreatorName.TabIndex = 2;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(493, 31);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(55, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Ghi chú";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(20, 34);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(99, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Nhà cung cấp";
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(477, 19);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(188, 42);
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
            panel3.Location = new Point(0, 621);
            panel3.Name = "panel3";
            panel3.Size = new Size(1490, 81);
            panel3.TabIndex = 26;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Cancel);
            panel1.Controls.Add(btn_DeleteProduct);
            panel1.Controls.Add(btn_UpdateProduct);
            panel1.Controls.Add(btn_Add);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtp_ExpirationDate);
            panel1.Controls.Add(nmr_PurchasePrice);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(nmr_ConversionRate);
            panel1.Controls.Add(cbb_Products);
            panel1.Controls.Add(dtp_ProductionDate);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(rtb_ProductNote);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(nmr_Quantity);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbb_Units);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbb_Categories);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textbox34);
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 176);
            panel1.Name = "panel1";
            panel1.Size = new Size(1490, 186);
            panel1.TabIndex = 27;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(1345, 62);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(91, 29);
            btn_Cancel.TabIndex = 11;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.Location = new Point(1345, 104);
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.Size = new Size(94, 29);
            btn_DeleteProduct.TabIndex = 12;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.UseVisualStyleBackColor = true;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.Location = new Point(1234, 104);
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.Size = new Size(94, 29);
            btn_UpdateProduct.TabIndex = 10;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(1234, 62);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(94, 29);
            btn_Add.TabIndex = 9;
            btn_Add.Text = "Thêm";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(699, 90);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 44;
            label3.Text = "Ngày hết hạn";
            // 
            // dtp_ExpirationDate
            // 
            dtp_ExpirationDate.CustomFormat = "dd/MM/yyyy";
            dtp_ExpirationDate.Format = DateTimePickerFormat.Custom;
            dtp_ExpirationDate.Location = new Point(699, 115);
            dtp_ExpirationDate.Name = "dtp_ExpirationDate";
            dtp_ExpirationDate.Size = new Size(147, 27);
            dtp_ExpirationDate.TabIndex = 7;
            // 
            // nmr_PurchasePrice
            // 
            nmr_PurchasePrice.Location = new Point(493, 56);
            nmr_PurchasePrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_PurchasePrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_PurchasePrice.Name = "nmr_PurchasePrice";
            nmr_PurchasePrice.Size = new Size(150, 27);
            nmr_PurchasePrice.TabIndex = 4;
            nmr_PurchasePrice.ThousandsSeparator = true;
            nmr_PurchasePrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(699, 31);
            label10.Name = "label10";
            label10.Size = new Size(102, 20);
            label10.TabIndex = 42;
            label10.Text = "Ngày sản xuất";
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Enabled = false;
            nmr_ConversionRate.Location = new Point(255, 118);
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 3;
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(19, 118);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 1;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // dtp_ProductionDate
            // 
            dtp_ProductionDate.CustomFormat = "dd/MM/yyyy";
            dtp_ProductionDate.Format = DateTimePickerFormat.Custom;
            dtp_ProductionDate.Location = new Point(699, 56);
            dtp_ProductionDate.Name = "dtp_ProductionDate";
            dtp_ProductionDate.Size = new Size(147, 27);
            dtp_ProductionDate.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(909, 32);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 15;
            label9.Text = "Ghi chú";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(909, 56);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(264, 89);
            rtb_ProductNote.TabIndex = 8;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(493, 95);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 13;
            label8.Text = "Số lượng";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(493, 32);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 12;
            label7.Text = "Giá tiền";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(493, 118);
            nmr_Quantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nmr_Quantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 5;
            nmr_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(255, 93);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 8;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(255, 58);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 2;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(255, 36);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(19, 58);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 0;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 36);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 4;
            label4.Text = "Tên danh mục";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(19, 95);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 2;
            textbox34.Text = "Tên sản phẩm";
            // 
            // groupBox3
            // 
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1490, 186);
            groupBox3.TabIndex = 45;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin sản phẩm";
            // 
            // GoodsReceiptNoteInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1490, 702);
            Controls.Add(groupBox2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GoodsReceiptNoteInputView";
            Text = "Phiếu nhập";
            Load += GoodsReceiptNoteInputView_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_PurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgv_ProductList;
        private GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private TextBox CreatorName;
        private ComboBox cbb_Suppliers;
        private Label label1;
        private RichTextBox rtb_Note;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DateTimePicker dateTimePicker;
        private ComboBox cbb_Status;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Panel panel3;
        private Panel panel1;
        private Label label4;
        private Label textbox34;
        private Label label6;
        private ComboBox cbb_Units;
        private Label label5;
        private ComboBox cbb_Categories;
        private Label label7;
        private NumericUpDown nmr_Quantity;
        private RichTextBox rtb_ProductNote;
        private Label label8;
        private Label label9;
        private ComboBox cbb_Products;
        private NumericUpDown nmr_ConversionRate;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn PurchasePrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
        private NumericUpDown nmr_PurchasePrice;
        private Label label3;
        private DateTimePicker dtp_ExpirationDate;
        private Label label10;
        private DateTimePicker dtp_ProductionDate;
        private Button btn_UpdateProduct;
        private Button btn_Add;
        private Button btn_Cancel;
        private Button btn_DeleteProduct;
        private DataGridViewTextBoxColumn ProductionDate;
        private DataGridViewTextBoxColumn ExpirationDate;
        private GroupBox groupBox3;
    }
}