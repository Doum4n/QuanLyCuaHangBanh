namespace QuanLyCuaHangBanh.Views
{
    partial class ProductInputView
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInputView));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            pictureBox = new PictureBox();
            nmr_UnitPrice = new NumericUpDown();
            groupBox1 = new GroupBox();
            cbb_Manufacturers = new ComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            tb_ProductName = new TextBox();
            cbb_Categories = new ComboBox();
            cbb_Producers = new ComboBox();
            mttb_Description = new RichTextBox();
            label7 = new Label();
            dtp_ExpirationDate = new DateTimePicker();
            label6 = new Label();
            dtp_ProductionDate = new DateTimePicker();
            label5 = new Label();
            nmr_TotalQuantity = new NumericUpDown();
            nmr_Quantity = new NumericUpDown();
            nmr_Conversion = new NumericUpDown();
            panel1 = new Panel();
            btn_Cancel = new Button();
            btn_AddUnit = new Button();
            btn_EditUnit = new Button();
            btn_DeleteUnit = new Button();
            cbb_Units = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgv_ProductUnitList = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            IsChecked = new DataGridViewCheckBoxColumn();
            tabPage2 = new TabPage();
            dgv_ReceiptList = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            ReceiptDate = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            dgv_ReleaseList = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            ReleaseDate = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_UnitPrice).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Conversion).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ReceiptList).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ReleaseList).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(19, 46);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(103, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Tên sản phầm";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(19, 107);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(107, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Loại sản phẩm";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(228, 41);
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
            btn_Save.Location = new Point(473, 10);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(215, 42);
            btn_Save.TabIndex = 9;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(607, 34);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(42, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Mô tả";
            // 
            // pictureBox
            // 
            pictureBox.ImageLocation = "";
            pictureBox.Location = new Point(945, 34);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(200, 185);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 15;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // nmr_UnitPrice
            // 
            nmr_UnitPrice.Location = new Point(372, 53);
            nmr_UnitPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_UnitPrice.Name = "nmr_UnitPrice";
            nmr_UnitPrice.Size = new Size(150, 27);
            nmr_UnitPrice.TabIndex = 16;
            nmr_UnitPrice.ThousandsSeparator = true;
            nmr_UnitPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbb_Manufacturers);
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(tb_ProductName);
            groupBox1.Controls.Add(cbb_Categories);
            groupBox1.Controls.Add(cbb_Producers);
            groupBox1.Controls.Add(mttb_Description);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dtp_ExpirationDate);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtp_ProductionDate);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(nmr_TotalQuantity);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(materialLabel3);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1161, 249);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // cbb_Manufacturers
            // 
            cbb_Manufacturers.FormattingEnabled = true;
            cbb_Manufacturers.Location = new Point(228, 133);
            cbb_Manufacturers.Name = "cbb_Manufacturers";
            cbb_Manufacturers.Size = new Size(183, 28);
            cbb_Manufacturers.TabIndex = 46;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(228, 111);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(104, 19);
            materialLabel4.TabIndex = 45;
            materialLabel4.Text = "Hãng sản xuất";
            // 
            // tb_ProductName
            // 
            tb_ProductName.BorderStyle = BorderStyle.None;
            tb_ProductName.Location = new Point(19, 71);
            tb_ProductName.Name = "tb_ProductName";
            tb_ProductName.Size = new Size(183, 20);
            tb_ProductName.TabIndex = 44;
            // 
            // cbb_Categories
            // 
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.Location = new Point(19, 133);
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(183, 28);
            cbb_Categories.TabIndex = 43;
            // 
            // cbb_Producers
            // 
            cbb_Producers.FormattingEnabled = true;
            cbb_Producers.Location = new Point(228, 63);
            cbb_Producers.Name = "cbb_Producers";
            cbb_Producers.Size = new Size(183, 28);
            cbb_Producers.TabIndex = 42;
            // 
            // mttb_Description
            // 
            mttb_Description.BorderStyle = BorderStyle.None;
            mttb_Description.Location = new Point(607, 59);
            mttb_Description.Name = "mttb_Description";
            mttb_Description.Size = new Size(293, 97);
            mttb_Description.TabIndex = 41;
            mttb_Description.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(441, 104);
            label7.Name = "label7";
            label7.Size = new Size(97, 20);
            label7.TabIndex = 40;
            label7.Text = "Ngày hết hạn";
            // 
            // dtp_ExpirationDate
            // 
            dtp_ExpirationDate.CustomFormat = "dd/MM/yyyy";
            dtp_ExpirationDate.Format = DateTimePickerFormat.Custom;
            dtp_ExpirationDate.Location = new Point(441, 129);
            dtp_ExpirationDate.Name = "dtp_ExpirationDate";
            dtp_ExpirationDate.Size = new Size(147, 27);
            dtp_ExpirationDate.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(438, 34);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 38;
            label6.Text = "Ngày sản xuất";
            // 
            // dtp_ProductionDate
            // 
            dtp_ProductionDate.CustomFormat = "dd/MM/yyyy";
            dtp_ProductionDate.Format = DateTimePickerFormat.Custom;
            dtp_ProductionDate.Location = new Point(438, 59);
            dtp_ProductionDate.Name = "dtp_ProductionDate";
            dtp_ProductionDate.Size = new Size(147, 27);
            dtp_ProductionDate.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(750, 169);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 36;
            label5.Text = "Tổng số lượng";
            // 
            // nmr_TotalQuantity
            // 
            nmr_TotalQuantity.Enabled = false;
            nmr_TotalQuantity.Location = new Point(750, 192);
            nmr_TotalQuantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_TotalQuantity.Name = "nmr_TotalQuantity";
            nmr_TotalQuantity.Size = new Size(150, 27);
            nmr_TotalQuantity.TabIndex = 35;
            nmr_TotalQuantity.ThousandsSeparator = true;
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Enabled = false;
            nmr_Quantity.Location = new Point(546, 53);
            nmr_Quantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 21;
            nmr_Quantity.ThousandsSeparator = true;
            nmr_Quantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nmr_Conversion
            // 
            nmr_Conversion.Location = new Point(200, 53);
            nmr_Conversion.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Conversion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_Conversion.Name = "nmr_Conversion";
            nmr_Conversion.Size = new Size(150, 27);
            nmr_Conversion.TabIndex = 19;
            nmr_Conversion.ThousandsSeparator = true;
            toolTip1.SetToolTip(nmr_Conversion, "Tỷ lệ chuyển đổi giữa đơn vị này với các đơn vị cơ bản");
            nmr_Conversion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Cancel);
            panel1.Controls.Add(btn_AddUnit);
            panel1.Controls.Add(btn_EditUnit);
            panel1.Controls.Add(btn_DeleteUnit);
            panel1.Controls.Add(cbb_Units);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nmr_UnitPrice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nmr_Quantity);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nmr_Conversion);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1147, 133);
            panel1.TabIndex = 20;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(919, 75);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 39;
            btn_Cancel.Text = "Hủy";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_AddUnit
            // 
            btn_AddUnit.BackColor = SystemColors.ActiveCaption;
            btn_AddUnit.Location = new Point(919, 30);
            btn_AddUnit.Name = "btn_AddUnit";
            btn_AddUnit.Size = new Size(94, 29);
            btn_AddUnit.TabIndex = 38;
            btn_AddUnit.Text = "Thêm";
            btn_AddUnit.UseVisualStyleBackColor = false;
            btn_AddUnit.Click += btn_AddUnit_Click;
            // 
            // btn_EditUnit
            // 
            btn_EditUnit.Location = new Point(1019, 30);
            btn_EditUnit.Name = "btn_EditUnit";
            btn_EditUnit.Size = new Size(94, 29);
            btn_EditUnit.TabIndex = 37;
            btn_EditUnit.Text = "Sửa";
            btn_EditUnit.UseVisualStyleBackColor = true;
            btn_EditUnit.Click += btn_EditUnit_Click;
            // 
            // btn_DeleteUnit
            // 
            btn_DeleteUnit.BackColor = Color.Red;
            btn_DeleteUnit.ForeColor = Color.Transparent;
            btn_DeleteUnit.Location = new Point(1019, 75);
            btn_DeleteUnit.Name = "btn_DeleteUnit";
            btn_DeleteUnit.Size = new Size(94, 29);
            btn_DeleteUnit.TabIndex = 36;
            btn_DeleteUnit.Text = " Xóa";
            btn_DeleteUnit.UseVisualStyleBackColor = false;
            btn_DeleteUnit.Click += btn_DeleteUnit_Click;
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(27, 52);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(151, 28);
            cbb_Units.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 30);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 29;
            label4.Text = "Giá bán";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 30);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 28;
            label2.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 30);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 27;
            label3.Text = "Đơn vị tính";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 30);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 24;
            label1.Text = "Tỷ lệ chuyển đổi";
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_Save);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 605);
            panel2.Name = "panel2";
            panel2.Size = new Size(1161, 62);
            panel2.TabIndex = 21;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 249);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1161, 356);
            tabControl1.TabIndex = 1;
            tabControl1.TabIndexChanged += tabControl1_TabIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgv_ProductUnitList);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1153, 323);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách đơn vị tính";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_ProductUnitList
            // 
            dgv_ProductUnitList.AllowUserToAddRows = false;
            dgv_ProductUnitList.AllowUserToDeleteRows = false;
            dgv_ProductUnitList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductUnitList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductUnitList.Columns.AddRange(new DataGridViewColumn[] { ID, UnitName, ConversionRate, UnitPrice, Quantity, IsChecked });
            dgv_ProductUnitList.Dock = DockStyle.Fill;
            dgv_ProductUnitList.Location = new Point(3, 136);
            dgv_ProductUnitList.Name = "dgv_ProductUnitList";
            dgv_ProductUnitList.ReadOnly = true;
            dgv_ProductUnitList.RowHeadersWidth = 51;
            dgv_ProductUnitList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ProductUnitList.Size = new Size(1147, 184);
            dgv_ProductUnitList.TabIndex = 0;
            dgv_ProductUnitList.CellContentClick += dgv_ProductUnitList_CellContentClick;
            dgv_ProductUnitList.RowPrePaint += dgv_ProductUnitList_RowPrePaint;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
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
            // UnitPrice
            // 
            UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            UnitPrice.HeaderText = "Giá tiền";
            UnitPrice.MinimumWidth = 6;
            UnitPrice.Name = "UnitPrice";
            UnitPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Số lượng";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // IsChecked
            // 
            IsChecked.DataPropertyName = "IsChecked";
            IsChecked.HeaderText = "ĐVT cơ bản";
            IsChecked.MinimumWidth = 6;
            IsChecked.Name = "IsChecked";
            IsChecked.ReadOnly = true;
            IsChecked.Resizable = DataGridViewTriState.True;
            IsChecked.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgv_ReceiptList);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1153, 323);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Danh sách nhập hàng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_ReceiptList
            // 
            dgv_ReceiptList.AllowUserToAddRows = false;
            dgv_ReceiptList.AllowUserToDeleteRows = false;
            dgv_ReceiptList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReceiptList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ReceiptList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, TotalPrice, ReceiptDate, Note });
            dgv_ReceiptList.Dock = DockStyle.Fill;
            dgv_ReceiptList.Location = new Point(3, 3);
            dgv_ReceiptList.Name = "dgv_ReceiptList";
            dgv_ReceiptList.ReadOnly = true;
            dgv_ReceiptList.RowHeadersWidth = 51;
            dgv_ReceiptList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReceiptList.Size = new Size(1147, 317);
            dgv_ReceiptList.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "UnitName";
            dataGridViewTextBoxColumn2.HeaderText = "Tên đơn vị tính";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "ConversionRate";
            dataGridViewTextBoxColumn3.HeaderText = "Tỷ lệ chuyển đổi";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "PurchasePrice";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn4.HeaderText = "Giá nhập";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Quantity";
            dataGridViewTextBoxColumn5.HeaderText = "Số lượng";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // TotalPrice
            // 
            TotalPrice.DataPropertyName = "TotalPrice";
            TotalPrice.HeaderText = "Thành tiền";
            TotalPrice.MinimumWidth = 6;
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            // 
            // ReceiptDate
            // 
            ReceiptDate.DataPropertyName = "ReceiptDate";
            ReceiptDate.HeaderText = "Ngày nhập";
            ReceiptDate.MinimumWidth = 6;
            ReceiptDate.Name = "ReceiptDate";
            ReceiptDate.ReadOnly = true;
            // 
            // Note
            // 
            Note.DataPropertyName = "Note";
            Note.HeaderText = "Ghi chú";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            Note.ReadOnly = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgv_ReleaseList);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1153, 323);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Danh sách xuất hàng";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_ReleaseList
            // 
            dgv_ReleaseList.AllowUserToAddRows = false;
            dgv_ReleaseList.AllowUserToDeleteRows = false;
            dgv_ReleaseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReleaseList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ReleaseList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn10, ReleaseDate, dataGridViewTextBoxColumn13 });
            dgv_ReleaseList.Dock = DockStyle.Fill;
            dgv_ReleaseList.Location = new Point(3, 3);
            dgv_ReleaseList.Name = "dgv_ReleaseList";
            dgv_ReleaseList.ReadOnly = true;
            dgv_ReleaseList.RowHeadersWidth = 51;
            dgv_ReleaseList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReleaseList.Size = new Size(1147, 317);
            dgv_ReleaseList.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "ID";
            dataGridViewTextBoxColumn6.HeaderText = "ID";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
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
            // ReleaseDate
            // 
            ReleaseDate.DataPropertyName = "ReleaseDate";
            ReleaseDate.HeaderText = "Ngày nhập";
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
            // ProductInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1161, 667);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProductInputView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm sản phẩm";
            Load += ProductInputView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_UnitPrice).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_TotalQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Conversion).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ReceiptList).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ReleaseList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private PictureBox pictureBox;
        private NumericUpDown nmr_UnitPrice;
        private GroupBox groupBox1;
        private Panel panel1;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private NumericUpDown nmr_Quantity;
        private NumericUpDown nmr_Conversion;
        private DataGridViewTextBoxColumn ConvertionRate;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgv_ProductUnitList;
        private TabPage tabPage2;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
        private ComboBox cbb_Units;
        private TabPage tabPage3;
        private DataGridView dgv_ReceiptList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewTextBoxColumn ReceiptDate;
        private DataGridViewTextBoxColumn Note;
        private DataGridView dgv_ReleaseList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn ReleaseDate;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Label label5;
        private NumericUpDown nmr_TotalQuantity;
        private Label label7;
        private DateTimePicker dtp_ExpirationDate;
        private Label label6;
        private DateTimePicker dtp_ProductionDate;
        private ComboBox cbb_Categories;
        private ComboBox cbb_Producers;
        private RichTextBox mttb_Description;
        private ComboBox cbb_Manufacturers;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private TextBox tb_ProductName;
        private Button btn_DeleteUnit;
        private Button btn_Cancel;
        private Button btn_AddUnit;
        private Button btn_EditUnit;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewCheckBoxColumn IsChecked;
        private ToolTip toolTip1;
    }
}