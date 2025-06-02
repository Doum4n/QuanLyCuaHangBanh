
namespace QuanLyCuaHangBanh.Views
{
    partial class ReleaseNoteInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReleaseNoteInputView));
            cbb_Status = new ComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker = new DateTimePicker();
            rtb_Note = new RichTextBox();
            panel3 = new Panel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            nmr_ConversionRate = new NumericUpDown();
            cbb_Products = new ComboBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
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
            panel1 = new Panel();
            groupBox4 = new GroupBox();
            btn_Cancel = new Button();
            btn_DeleteProduct = new Button();
            btn_UpdateProduct = new Button();
            btn_AddProduct = new Button();
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
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            rbtn_GoodsReciveNote = new RadioButton();
            rbtn_Order = new RadioButton();
            label1 = new Label();
            CreatorName = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // cbb_Status
            // 
            cbb_Status.FormattingEnabled = true;
            cbb_Status.Location = new Point(302, 60);
            cbb_Status.Name = "cbb_Status";
            cbb_Status.Size = new Size(197, 28);
            cbb_Status.TabIndex = 32;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(303, 38);
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
            dateTimePicker.Location = new Point(302, 147);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(197, 27);
            dateTimePicker.TabIndex = 30;
            // 
            // rtb_Note
            // 
            rtb_Note.BorderStyle = BorderStyle.None;
            rtb_Note.Location = new Point(562, 57);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(387, 117);
            rtb_Note.TabIndex = 27;
            rtb_Note.Text = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_Save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 694);
            panel3.Name = "panel3";
            panel3.Size = new Size(1251, 81);
            panel3.TabIndex = 31;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(551, 19);
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
            // nmr_ConversionRate
            // 
            nmr_ConversionRate.Enabled = false;
            nmr_ConversionRate.Location = new Point(481, 117);
            nmr_ConversionRate.Name = "nmr_ConversionRate";
            nmr_ConversionRate.Size = new Size(150, 27);
            nmr_ConversionRate.TabIndex = 21;
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(23, 117);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(197, 28);
            cbb_Products.TabIndex = 20;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(302, 124);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(64, 19);
            materialLabel1.TabIndex = 28;
            materialLabel1.Text = "Ngày lập";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(674, 28);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 15;
            label9.Text = "Ghi chú";
            // 
            // rtb_ProductNote
            // 
            rtb_ProductNote.BorderStyle = BorderStyle.None;
            rtb_ProductNote.Location = new Point(674, 52);
            rtb_ProductNote.Name = "rtb_ProductNote";
            rtb_ProductNote.Size = new Size(287, 117);
            rtb_ProductNote.TabIndex = 14;
            rtb_ProductNote.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(481, 34);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 13;
            label8.Text = "Số lượng";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(481, 57);
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
            label6.Location = new Point(481, 92);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 8;
            label6.Text = "Tỷ lệ chuyển đổi";
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(250, 54);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(197, 28);
            cbb_Units.TabIndex = 7;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 32);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(23, 54);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(197, 28);
            cbb_Categories.TabIndex = 5;
            cbb_Categories.SelectedIndexChanged += cbb_Categories_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 32);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 4;
            label4.Text = "Tên danh mục";
            // 
            // textbox34
            // 
            textbox34.AutoSize = true;
            textbox34.Location = new Point(23, 94);
            textbox34.Name = "textbox34";
            textbox34.Size = new Size(100, 20);
            textbox34.TabIndex = 2;
            textbox34.Text = "Tên sản phẩm";
            // 
            // panel1
            // 
            panel1.Controls.Add(nmr_ConversionRate);
            panel1.Controls.Add(cbb_Products);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(rtb_ProductNote);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(nmr_Quantity);
            panel1.Controls.Add(cbb_Categories);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textbox34);
            panel1.Controls.Add(groupBox4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 230);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 198);
            panel1.TabIndex = 32;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btn_Cancel);
            groupBox4.Controls.Add(btn_DeleteProduct);
            groupBox4.Controls.Add(btn_UpdateProduct);
            groupBox4.Controls.Add(btn_AddProduct);
            groupBox4.Controls.Add(cbb_Units);
            groupBox4.Controls.Add(label5);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1251, 198);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin sản phẩm";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(1126, 75);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 27;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_DeleteProduct
            // 
            btn_DeleteProduct.BackColor = Color.Red;
            btn_DeleteProduct.Location = new Point(1126, 119);
            btn_DeleteProduct.Name = "btn_DeleteProduct";
            btn_DeleteProduct.Size = new Size(94, 29);
            btn_DeleteProduct.TabIndex = 26;
            btn_DeleteProduct.Text = "Xóa";
            btn_DeleteProduct.UseVisualStyleBackColor = false;
            btn_DeleteProduct.Click += btn_DeleteProduct_Click;
            // 
            // btn_UpdateProduct
            // 
            btn_UpdateProduct.Location = new Point(1008, 119);
            btn_UpdateProduct.Name = "btn_UpdateProduct";
            btn_UpdateProduct.Size = new Size(94, 29);
            btn_UpdateProduct.TabIndex = 25;
            btn_UpdateProduct.Text = "Sửa";
            btn_UpdateProduct.UseVisualStyleBackColor = true;
            btn_UpdateProduct.Click += btn_UpdateProduct_Click;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.BackColor = Color.Lime;
            btn_AddProduct.Location = new Point(1008, 74);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.Size = new Size(94, 29);
            btn_AddProduct.TabIndex = 24;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.UseVisualStyleBackColor = false;
            btn_AddProduct.Click += btn_AddProduct_Click;
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
            dgv_ProductList.Size = new Size(1245, 321);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_ProductList);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 428);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1251, 347);
            groupBox2.TabIndex = 29;
            groupBox2.TabStop = false;
            groupBox2.Text = " Danh sách sản phẩm";
            // 
            // groupBox1
            // 
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
            groupBox1.Size = new Size(1251, 230);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu xuất";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbtn_GoodsReciveNote);
            groupBox3.Controls.Add(rbtn_Order);
            groupBox3.Location = new Point(24, 101);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(223, 99);
            groupBox3.TabIndex = 34;
            groupBox3.TabStop = false;
            groupBox3.Text = "Xuất hàng từ";
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
            rbtn_GoodsReciveNote.CheckedChanged += rbtn_GoodsReciveNote_CheckedChanged;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 34);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 25;
            label1.Text = "Tên người lập";
            // 
            // CreatorName
            // 
            CreatorName.Location = new Point(24, 57);
            CreatorName.Name = "CreatorName";
            CreatorName.Size = new Size(223, 27);
            CreatorName.TabIndex = 24;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(562, 35);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(55, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Ghi chú";
            // 
            // ReleaseNoteInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 775);
            Controls.Add(panel3);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReleaseNoteInputView";
            Text = "WarehouseReleaseNoteInputView";
            Load += WarehouseReleaseNoteInputView_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmr_ConversionRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductList).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbb_Status;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private DateTimePicker dateTimePicker;
        private RichTextBox rtb_Note;
        private Panel panel3;
        private NumericUpDown nmr_ConversionRate;
        private ComboBox cbb_Products;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
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
        private Panel panel1;
        private DataGridView dgv_ProductList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn PurchasePrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Note;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox CreatorName;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private GroupBox groupBox3;
        private RadioButton rbtn_GoodsReciveNote;
        private RadioButton rbtn_Order;
        private GroupBox groupBox4;
        private Button btn_Cancel;
        private Button btn_DeleteProduct;
        private Button btn_UpdateProduct;
        private Button btn_AddProduct;
        private MaterialSkin.Controls.MaterialButton btn_Save;
    }
}