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
            panel2 = new Panel();
            llb_AddUnit = new LinkLabel();
            llb_AddCategory = new LinkLabel();
            llb_AddProducer = new LinkLabel();
            dgv_ProductList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            PurchasePrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
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
            btn_DeleteProduct = new MaterialSkin.Controls.MaterialButton();
            btn_UpdateProduct = new MaterialSkin.Controls.MaterialButton();
            btn_Add = new MaterialSkin.Controls.MaterialButton();
            nmr_PurchasePrice = new NumericUpDown();
            nmr_ConversionRate = new NumericUpDown();
            cbb_Products = new ComboBox();
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
            tb_Id = new TextBox();
            label2 = new Label();
            panel2.SuspendLayout();
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
            // panel2
            // 
            panel2.Controls.Add(llb_AddUnit);
            panel2.Controls.Add(llb_AddCategory);
            panel2.Controls.Add(llb_AddProducer);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 652);
            panel2.Name = "panel2";
            panel2.Size = new Size(1277, 50);
            panel2.TabIndex = 25;
            // 
            // llb_AddUnit
            // 
            llb_AddUnit.AutoSize = true;
            llb_AddUnit.Location = new Point(400, 15);
            llb_AddUnit.Name = "llb_AddUnit";
            llb_AddUnit.Size = new Size(120, 20);
            llb_AddUnit.TabIndex = 10;
            llb_AddUnit.TabStop = true;
            llb_AddUnit.Text = "Thêm đơn vị tính";
            // 
            // llb_AddCategory
            // 
            llb_AddCategory.AutoSize = true;
            llb_AddCategory.Location = new Point(561, 15);
            llb_AddCategory.Name = "llb_AddCategory";
            llb_AddCategory.Size = new Size(143, 20);
            llb_AddCategory.TabIndex = 11;
            llb_AddCategory.TabStop = true;
            llb_AddCategory.Text = "Thêm loại sản phẩm";
            // 
            // llb_AddProducer
            // 
            llb_AddProducer.AutoSize = true;
            llb_AddProducer.Location = new Point(745, 15);
            llb_AddProducer.Name = "llb_AddProducer";
            llb_AddProducer.Size = new Size(132, 20);
            llb_AddProducer.TabIndex = 12;
            llb_AddProducer.TabStop = true;
            llb_AddProducer.Text = "Thêm nhà sản xuất";
            // 
            // dgv_ProductList
            // 
            dgv_ProductList.AllowUserToAddRows = false;
            dgv_ProductList.AllowUserToDeleteRows = false;
            dgv_ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductList.Columns.AddRange(new DataGridViewColumn[] { ID, ProductName, CategoryName, UnitName, ConversionRate, PurchasePrice, Quantity, Note });
            dgv_ProductList.Dock = DockStyle.Fill;
            dgv_ProductList.Location = new Point(3, 23);
            dgv_ProductList.Name = "dgv_ProductList";
            dgv_ProductList.ReadOnly = true;
            dgv_ProductList.RowHeadersWidth = 51;
            dgv_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductList.Size = new Size(1271, 219);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_ProductList);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 326);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1277, 245);
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
            groupBox1.Size = new Size(1277, 176);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(378, 54);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(250, 28);
            cbb_Status.TabIndex = 32;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(379, 32);
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
            dateTimePicker.Location = new Point(378, 122);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 30;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(378, 99);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(64, 19);
            materialLabel1.TabIndex = 28;
            materialLabel1.Text = "Ngày lập";
            // 
            // rtb_Note
            // 
            rtb_Note.BorderStyle = BorderStyle.None;
            rtb_Note.Location = new Point(674, 51);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(338, 98);
            rtb_Note.TabIndex = 27;
            rtb_Note.Text = "";
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(14, 54);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(299, 28);
            cbb_Suppliers.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 99);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 25;
            label1.Text = "Tên người lập";
            // 
            // CreatorName
            // 
            CreatorName.Location = new Point(14, 122);
            CreatorName.Name = "CreatorName";
            CreatorName.Size = new Size(299, 27);
            CreatorName.TabIndex = 24;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(674, 29);
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
            materialLabel3.Location = new Point(15, 32);
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
            btn_Save.Location = new Point(421, 18);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(188, 42);
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
            panel3.Location = new Point(0, 571);
            panel3.Name = "panel3";
            panel3.Size = new Size(1277, 81);
            panel3.TabIndex = 26;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_DeleteProduct);
            panel1.Controls.Add(btn_UpdateProduct);
            panel1.Controls.Add(btn_Add);
            panel1.Controls.Add(nmr_PurchasePrice);
            panel1.Controls.Add(nmr_ConversionRate);
            panel1.Controls.Add(cbb_Products);
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
            panel1.Controls.Add(tb_Id);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 176);
            panel1.Name = "panel1";
            panel1.Size = new Size(1277, 150);
            panel1.TabIndex = 27;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.AutoSize = false;
            btn_DeleteProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DeleteProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_DeleteProduct.Depth = 0;
            btn_DeleteProduct.HighEmphasis = true;
            btn_DeleteProduct.Icon = null;
            btn_DeleteProduct.Location = new Point(1127, 101);
            btn_DeleteProduct.Margin = new Padding(4, 6, 4, 6);
            btn_DeleteProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.NoAccentTextColor = Color.Empty;
            btn_DeleteProduct.Size = new Size(79, 32);
            btn_DeleteProduct.TabIndex = 26;
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
            btn_UpdateProduct.Location = new Point(1127, 57);
            btn_UpdateProduct.Margin = new Padding(4, 6, 4, 6);
            btn_UpdateProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.NoAccentTextColor = Color.Empty;
            btn_UpdateProduct.Size = new Size(79, 32);
            btn_UpdateProduct.TabIndex = 25;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_UpdateProduct.UseAccentColor = false;
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_Add
            // 
            btn_Add.AutoSize = false;
            btn_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Add.Depth = 0;
            btn_Add.HighEmphasis = true;
            btn_Add.Icon = null;
            btn_Add.Location = new Point(1127, 16);
            btn_Add.Margin = new Padding(4, 6, 4, 6);
            btn_Add.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Add.Name = "btn_Add";
            btn_Add.NoAccentTextColor = Color.Empty;
            btn_Add.Size = new Size(79, 32);
            btn_Add.TabIndex = 24;
            btn_Add.Text = "Thêm";
            btn_Add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Add.UseAccentColor = false;
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // nmr_PurchasePrice
            // 
            nmr_PurchasePrice.Location = new Point(668, 33);
            nmr_PurchasePrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_PurchasePrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_PurchasePrice.Name = "nmr_PurchasePrice";
            nmr_PurchasePrice.Size = new Size(150, 27);
            nmr_PurchasePrice.TabIndex = 23;
            nmr_PurchasePrice.ThousandsSeparator = true;
            nmr_PurchasePrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Location = new Point(486, 33);
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 21;
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(19, 86);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(858, 9);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 15;
            label9.Text = "Ghi chú";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(858, 33);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(227, 80);
            rtb_ProductNote.TabIndex = 14;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(668, 62);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 13;
            label8.Text = "Số lượng";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(668, 9);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 12;
            label7.Text = "Giá tiền";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(668, 85);
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
            label6.Location = new Point(486, 8);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 8;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(245, 84);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(245, 62);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(245, 30);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(245, 8);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 4;
            label4.Text = "Tên danh mục";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(19, 63);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 2;
            textbox34.Text = "Tên sản phẩm";
            // 
            // tb_Id
            // 
            tb_Id.Enabled = false;
            tb_Id.Location = new Point(19, 32);
            tb_Id.Name = "tb_Id";
            tb_Id.Size = new Size(125, 27);
            tb_Id.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 9);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã";
            // 
            // GoodsReceiptNoteInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 702);
            Controls.Add(groupBox2);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "GoodsReceiptNoteInputView";
            Text = "GoodsReceiptNoteInputView";
            Load += GoodsReceiptNoteInputView_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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

        private Panel panel2;
        private LinkLabel llb_AddUnit;
        private LinkLabel llb_AddCategory;
        private LinkLabel llb_AddProducer;
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
        private TextBox tb_Id;
        private Label label2;
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
        private MaterialSkin.Controls.MaterialButton btn_DeleteProduct;
        private MaterialSkin.Controls.MaterialButton btn_UpdateProduct;
        private MaterialSkin.Controls.MaterialButton btn_Add;
    }
}