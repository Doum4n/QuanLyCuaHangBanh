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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            tb_ProductName = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            cbb_Categories = new MaterialSkin.Controls.MaterialComboBox();
            cbb_Producers = new MaterialSkin.Controls.MaterialComboBox();
            cbb_Units = new MaterialSkin.Controls.MaterialComboBox();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            llb_AddUnit = new LinkLabel();
            llb_AddCategory = new LinkLabel();
            llb_AddProducer = new LinkLabel();
            mttb_Description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            pictureBox = new PictureBox();
            nmr_BaseUnitPrice = new NumericUpDown();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            groupBox1 = new GroupBox();
            linkLabel1 = new LinkLabel();
            nmr_Quantity = new NumericUpDown();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            numericUpDown1 = new NumericUpDown();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox2 = new GroupBox();
            dgv_ProductUnitList = new DataGridView();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            numericUpDown3 = new NumericUpDown();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            panel2 = new Panel();
            ID = new DataGridViewTextBoxColumn();
            UnitName = new DataGridViewTextBoxColumn();
            ConversionRate = new DataGridViewTextBoxColumn();
            UnitPrice = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_BaseUnitPrice).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            panel2.SuspendLayout();
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
            // tb_ProductName
            // 
            tb_ProductName.AnimateReadOnly = false;
            tb_ProductName.BackgroundImageLayout = ImageLayout.None;
            tb_ProductName.CharacterCasing = CharacterCasing.Normal;
            tb_ProductName.Depth = 0;
            tb_ProductName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tb_ProductName.HideSelection = true;
            tb_ProductName.LeadingIcon = null;
            tb_ProductName.Location = new Point(19, 68);
            tb_ProductName.MaxLength = 32767;
            tb_ProductName.MouseState = MaterialSkin.MouseState.OUT;
            tb_ProductName.Name = "tb_ProductName";
            tb_ProductName.PasswordChar = '\0';
            tb_ProductName.PrefixSuffixText = null;
            tb_ProductName.ReadOnly = false;
            tb_ProductName.RightToLeft = RightToLeft.No;
            tb_ProductName.SelectedText = "";
            tb_ProductName.SelectionLength = 0;
            tb_ProductName.SelectionStart = 0;
            tb_ProductName.ShortcutsEnabled = true;
            tb_ProductName.Size = new Size(293, 48);
            tb_ProductName.TabIndex = 2;
            tb_ProductName.TabStop = false;
            tb_ProductName.TextAlign = HorizontalAlignment.Left;
            tb_ProductName.TrailingIcon = null;
            tb_ProductName.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(19, 146);
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
            materialLabel3.Location = new Point(325, 46);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(95, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Nhà sản xuất";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(19, 11);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(77, 19);
            materialLabel4.TabIndex = 5;
            materialLabel4.Text = "Đơn vị tính";
            // 
            // cbb_Categories
            // 
            cbb_Categories.AutoResize = false;
            cbb_Categories.BackColor = Color.FromArgb(255, 255, 255);
            cbb_Categories.Depth = 0;
            cbb_Categories.DrawMode = DrawMode.OwnerDrawVariable;
            cbb_Categories.DropDownHeight = 174;
            cbb_Categories.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_Categories.DropDownWidth = 121;
            cbb_Categories.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbb_Categories.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbb_Categories.FormattingEnabled = true;
            cbb_Categories.IntegralHeight = false;
            cbb_Categories.ItemHeight = 43;
            cbb_Categories.Location = new Point(19, 168);
            cbb_Categories.MaxDropDownItems = 4;
            cbb_Categories.MouseState = MaterialSkin.MouseState.OUT;
            cbb_Categories.Name = "cbb_Categories";
            cbb_Categories.Size = new Size(293, 49);
            cbb_Categories.StartIndex = 0;
            cbb_Categories.TabIndex = 6;
            // 
            // cbb_Producers
            // 
            cbb_Producers.AutoResize = false;
            cbb_Producers.BackColor = Color.FromArgb(255, 255, 255);
            cbb_Producers.Depth = 0;
            cbb_Producers.DrawMode = DrawMode.OwnerDrawVariable;
            cbb_Producers.DropDownHeight = 174;
            cbb_Producers.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_Producers.DropDownWidth = 121;
            cbb_Producers.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbb_Producers.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbb_Producers.FormattingEnabled = true;
            cbb_Producers.IntegralHeight = false;
            cbb_Producers.ItemHeight = 43;
            cbb_Producers.Location = new Point(325, 68);
            cbb_Producers.MaxDropDownItems = 4;
            cbb_Producers.MouseState = MaterialSkin.MouseState.OUT;
            cbb_Producers.Name = "cbb_Producers";
            cbb_Producers.Size = new Size(293, 49);
            cbb_Producers.StartIndex = 0;
            cbb_Producers.TabIndex = 7;
            // 
            // cbb_Units
            // 
            cbb_Units.AutoResize = false;
            cbb_Units.BackColor = Color.FromArgb(255, 255, 255);
            cbb_Units.Depth = 0;
            cbb_Units.DrawMode = DrawMode.OwnerDrawVariable;
            cbb_Units.DropDownHeight = 174;
            cbb_Units.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_Units.DropDownWidth = 121;
            cbb_Units.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbb_Units.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbb_Units.FormattingEnabled = true;
            cbb_Units.IntegralHeight = false;
            cbb_Units.ItemHeight = 43;
            cbb_Units.Location = new Point(325, 168);
            cbb_Units.MaxDropDownItems = 4;
            cbb_Units.MouseState = MaterialSkin.MouseState.OUT;
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(293, 49);
            cbb_Units.StartIndex = 0;
            cbb_Units.TabIndex = 8;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(637, 240);
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
            // llb_AddUnit
            // 
            llb_AddUnit.AutoSize = true;
            llb_AddUnit.Location = new Point(348, 15);
            llb_AddUnit.Name = "llb_AddUnit";
            llb_AddUnit.Size = new Size(120, 20);
            llb_AddUnit.TabIndex = 10;
            llb_AddUnit.TabStop = true;
            llb_AddUnit.Text = "Thêm đơn vị tính";
            llb_AddUnit.LinkClicked += llb_AddUnit_LinkClicked;
            // 
            // llb_AddCategory
            // 
            llb_AddCategory.AutoSize = true;
            llb_AddCategory.Location = new Point(509, 15);
            llb_AddCategory.Name = "llb_AddCategory";
            llb_AddCategory.Size = new Size(143, 20);
            llb_AddCategory.TabIndex = 11;
            llb_AddCategory.TabStop = true;
            llb_AddCategory.Text = "Thêm loại sản phẩm";
            llb_AddCategory.LinkClicked += llb_AddCategory_LinkClicked;
            // 
            // llb_AddProducer
            // 
            llb_AddProducer.AutoSize = true;
            llb_AddProducer.Location = new Point(693, 15);
            llb_AddProducer.Name = "llb_AddProducer";
            llb_AddProducer.Size = new Size(132, 20);
            llb_AddProducer.TabIndex = 12;
            llb_AddProducer.TabStop = true;
            llb_AddProducer.Text = "Thêm nhà sản xuất";
            llb_AddProducer.LinkClicked += llb_AddProducer_LinkClicked;
            // 
            // mttb_Description
            // 
            mttb_Description.AnimateReadOnly = false;
            mttb_Description.BackgroundImageLayout = ImageLayout.None;
            mttb_Description.CharacterCasing = CharacterCasing.Normal;
            mttb_Description.Depth = 0;
            mttb_Description.HideSelection = true;
            mttb_Description.Location = new Point(634, 68);
            mttb_Description.MaxLength = 32767;
            mttb_Description.MouseState = MaterialSkin.MouseState.OUT;
            mttb_Description.Name = "mttb_Description";
            mttb_Description.PasswordChar = '\0';
            mttb_Description.ReadOnly = false;
            mttb_Description.ScrollBars = ScrollBars.None;
            mttb_Description.SelectedText = "";
            mttb_Description.SelectionLength = 0;
            mttb_Description.SelectionStart = 0;
            mttb_Description.ShortcutsEnabled = true;
            mttb_Description.Size = new Size(281, 149);
            mttb_Description.TabIndex = 13;
            mttb_Description.TabStop = false;
            mttb_Description.TextAlign = HorizontalAlignment.Left;
            mttb_Description.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(634, 46);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(42, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Mô tả";
            // 
            // pictureBox
            // 
            pictureBox.ImageLocation = "";
            pictureBox.Location = new Point(933, 34);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(215, 183);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 15;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // nmr_BaseUnitPrice
            // 
            nmr_BaseUnitPrice.Location = new Point(19, 264);
            nmr_BaseUnitPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_BaseUnitPrice.Name = "nmr_BaseUnitPrice";
            nmr_BaseUnitPrice.Size = new Size(150, 27);
            nmr_BaseUnitPrice.TabIndex = 16;
            nmr_BaseUnitPrice.ThousandsSeparator = true;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(365, 44);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(29, 19);
            materialLabel6.TabIndex = 17;
            materialLabel6.Text = " Giá";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(nmr_Quantity);
            groupBox1.Controls.Add(nmr_BaseUnitPrice);
            groupBox1.Controls.Add(cbb_Units);
            groupBox1.Controls.Add(btn_Save);
            groupBox1.Controls.Add(materialLabel9);
            groupBox1.Controls.Add(materialLabel8);
            groupBox1.Controls.Add(materialLabel7);
            groupBox1.Controls.Add(mttb_Description);
            groupBox1.Controls.Add(materialLabel1);
            groupBox1.Controls.Add(tb_ProductName);
            groupBox1.Controls.Add(pictureBox);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(cbb_Producers);
            groupBox1.Controls.Add(cbb_Categories);
            groupBox1.Controls.Add(materialLabel2);
            groupBox1.Controls.Add(materialLabel3);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1173, 318);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(973, 271);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(175, 20);
            linkLabel1.TabIndex = 23;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Bổ xung thêm đơn vị tính";
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(325, 264);
            nmr_Quantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 21;
            nmr_Quantity.ThousandsSeparator = true;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(325, 242);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(69, 19);
            materialLabel9.TabIndex = 22;
            materialLabel9.Text = " Số lượng";
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(19, 240);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(29, 19);
            materialLabel8.TabIndex = 20;
            materialLabel8.Text = " Giá";
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(325, 146);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(129, 19);
            materialLabel7.TabIndex = 19;
            materialLabel7.Text = "Đơn vị tính cơ bản";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(415, 44);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 19;
            numericUpDown1.ThousandsSeparator = true;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Location = new Point(12, 45);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(293, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 20;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_ProductUnitList);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 428);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1173, 242);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = " Danh sách đơn vị tính";
            // 
            // dgv_ProductUnitList
            // 
            dgv_ProductUnitList.AllowUserToAddRows = false;
            dgv_ProductUnitList.AllowUserToDeleteRows = false;
            dgv_ProductUnitList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductUnitList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductUnitList.Columns.AddRange(new DataGridViewColumn[] { ID, UnitName, ConversionRate, UnitPrice, Quantity });
            dgv_ProductUnitList.Dock = DockStyle.Fill;
            dgv_ProductUnitList.Location = new Point(3, 23);
            dgv_ProductUnitList.Name = "dgv_ProductUnitList";
            dgv_ProductUnitList.ReadOnly = true;
            dgv_ProductUnitList.RowHeadersWidth = 51;
            dgv_ProductUnitList.Size = new Size(1167, 216);
            dgv_ProductUnitList.TabIndex = 0;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(877, 46);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(198, 45);
            materialButton1.TabIndex = 18;
            materialButton1.Text = "Thêm đơn vị tính";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(numericUpDown3);
            panel1.Controls.Add(materialButton1);
            panel1.Controls.Add(materialLabel10);
            panel1.Controls.Add(materialLabel4);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(materialComboBox1);
            panel1.Controls.Add(materialLabel6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 318);
            panel1.Name = "panel1";
            panel1.Size = new Size(1173, 110);
            panel1.TabIndex = 20;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(675, 44);
            numericUpDown3.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 27);
            numericUpDown3.TabIndex = 23;
            numericUpDown3.ThousandsSeparator = true;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(583, 46);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(69, 19);
            materialLabel10.TabIndex = 24;
            materialLabel10.Text = " Số lượng";
            // 
            // panel2
            // 
            panel2.Controls.Add(llb_AddUnit);
            panel2.Controls.Add(llb_AddCategory);
            panel2.Controls.Add(llb_AddProducer);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 670);
            panel2.Name = "panel2";
            panel2.Size = new Size(1173, 50);
            panel2.TabIndex = 21;
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
            // ProductInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 720);
            Controls.Add(groupBox2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "ProductInputView";
            Text = "Thêm sản phẩm";
            Load += ProductInputView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_BaseUnitPrice).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 tb_ProductName;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialComboBox cbb_Categories;
        private MaterialSkin.Controls.MaterialComboBox cbb_Producers;
        private MaterialSkin.Controls.MaterialComboBox cbb_Units;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private LinkLabel llb_AddUnit;
        private LinkLabel llb_AddCategory;
        private LinkLabel llb_AddProducer;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mttb_Description;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private PictureBox pictureBox;
        private NumericUpDown nmr_BaseUnitPrice;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgv_ProductUnitList;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private NumericUpDown nmr_Quantity;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private NumericUpDown numericUpDown1;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private NumericUpDown numericUpDown3;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private LinkLabel linkLabel1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConvertionRate;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn ConversionRate;
    }
}