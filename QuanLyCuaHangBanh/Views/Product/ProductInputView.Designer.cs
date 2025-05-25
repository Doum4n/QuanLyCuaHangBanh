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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            tb_ProductName = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            cbb_Categories = new MaterialSkin.Controls.MaterialComboBox();
            cbb_Producers = new MaterialSkin.Controls.MaterialComboBox();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            llb_AddUnit = new LinkLabel();
            llb_AddCategory = new LinkLabel();
            llb_AddProducer = new LinkLabel();
            mttb_Description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            pictureBox = new PictureBox();
            nmr_UnitPrice = new NumericUpDown();
            groupBox1 = new GroupBox();
            linkLabel1 = new LinkLabel();
            nmr_Quantity = new NumericUpDown();
            nmr_Conversion = new NumericUpDown();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btn_AddUnit = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
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
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_UnitPrice).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Conversion).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).BeginInit();
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
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(945, 32);
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
            mttb_Description.Location = new Point(325, 168);
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
            mttb_Description.Size = new Size(293, 123);
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
            materialLabel5.Location = new Point(325, 146);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(42, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Mô tả";
            // 
            // pictureBox
            // 
            pictureBox.ImageLocation = "";
            pictureBox.Location = new Point(665, 34);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(215, 183);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 15;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // nmr_UnitPrice
            // 
            nmr_UnitPrice.Location = new Point(645, 44);
            nmr_UnitPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_UnitPrice.Name = "nmr_UnitPrice";
            nmr_UnitPrice.Size = new Size(150, 27);
            nmr_UnitPrice.TabIndex = 16;
            nmr_UnitPrice.ThousandsSeparator = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(btn_Save);
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
            nmr_Quantity.Location = new Point(474, 44);
            nmr_Quantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(150, 27);
            nmr_Quantity.TabIndex = 21;
            nmr_Quantity.ThousandsSeparator = true;
            // 
            // nmr_Conversion
            // 
            nmr_Conversion.Location = new Point(297, 44);
            nmr_Conversion.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Conversion.Name = "nmr_Conversion";
            nmr_Conversion.Size = new Size(150, 27);
            nmr_Conversion.TabIndex = 19;
            nmr_Conversion.ThousandsSeparator = true;
            // 
            // btn_AddUnit
            // 
            btn_AddUnit.AutoSize = false;
            btn_AddUnit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_AddUnit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_AddUnit.Depth = 0;
            btn_AddUnit.HighEmphasis = true;
            btn_AddUnit.Icon = null;
            btn_AddUnit.Location = new Point(943, 35);
            btn_AddUnit.Margin = new Padding(4, 6, 4, 6);
            btn_AddUnit.MouseState = MaterialSkin.MouseState.HOVER;
            btn_AddUnit.Name = "btn_AddUnit";
            btn_AddUnit.NoAccentTextColor = Color.Empty;
            btn_AddUnit.Size = new Size(198, 45);
            btn_AddUnit.TabIndex = 18;
            btn_AddUnit.Text = "Thêm đơn vị tính";
            btn_AddUnit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_AddUnit.UseAccentColor = false;
            btn_AddUnit.UseVisualStyleBackColor = true;
            btn_AddUnit.Click += btn_AddUnit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbb_Units);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nmr_UnitPrice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nmr_Quantity);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_AddUnit);
            panel1.Controls.Add(nmr_Conversion);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1159, 110);
            panel1.TabIndex = 20;
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
            label4.Location = new Point(645, 21);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 29;
            label4.Text = "Giá bán";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 21);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 28;
            label2.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 21);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 27;
            label3.Text = "Đơn vị tính";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 21);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 24;
            label1.Text = "Tỷ lệ chuyển đổi";
            // 
            // panel2
            // 
            panel2.Controls.Add(llb_AddUnit);
            panel2.Controls.Add(llb_AddCategory);
            panel2.Controls.Add(llb_AddProducer);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 790);
            panel2.Name = "panel2";
            panel2.Size = new Size(1173, 50);
            panel2.TabIndex = 21;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 318);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1173, 472);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgv_ProductUnitList);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1165, 439);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_ProductUnitList
            // 
            dgv_ProductUnitList.AllowUserToAddRows = false;
            dgv_ProductUnitList.AllowUserToDeleteRows = false;
            dgv_ProductUnitList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ProductUnitList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProductUnitList.Columns.AddRange(new DataGridViewColumn[] { ID, UnitName, ConversionRate, UnitPrice, Quantity });
            dgv_ProductUnitList.Dock = DockStyle.Fill;
            dgv_ProductUnitList.Location = new Point(3, 113);
            dgv_ProductUnitList.Name = "dgv_ProductUnitList";
            dgv_ProductUnitList.ReadOnly = true;
            dgv_ProductUnitList.RowHeadersWidth = 51;
            dgv_ProductUnitList.Size = new Size(1159, 323);
            dgv_ProductUnitList.TabIndex = 0;
            dgv_ProductUnitList.CellContentClick += dgv_ProductUnitList_CellContentClick;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            UnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
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
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1165, 439);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProductInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 840);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Name = "ProductInputView";
            Text = "Thêm sản phẩm";
            Load += ProductInputView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_UnitPrice).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_Conversion).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ProductUnitList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 tb_ProductName;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox cbb_Categories;
        private MaterialSkin.Controls.MaterialComboBox cbb_Producers;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private LinkLabel llb_AddUnit;
        private LinkLabel llb_AddCategory;
        private LinkLabel llb_AddProducer;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mttb_Description;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private PictureBox pictureBox;
        private NumericUpDown nmr_UnitPrice;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MaterialSkin.Controls.MaterialButton btn_AddUnit;
        private Panel panel1;
        private Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private NumericUpDown nmr_Quantity;
        private NumericUpDown nmr_Conversion;
        private LinkLabel linkLabel1;
        private DataGridViewTextBoxColumn ConvertionRate;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgv_ProductUnitList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn UnitName;
        private DataGridViewTextBoxColumn ConversionRate;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn Quantity;
        private TabPage tabPage2;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
        private ComboBox cbb_Units;
    }
}