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
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_BaseUnitPrice).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(53, 51);
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
            tb_ProductName.Location = new Point(53, 85);
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
            materialLabel2.Location = new Point(52, 345);
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
            materialLabel3.Location = new Point(52, 456);
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
            materialLabel4.Location = new Point(53, 162);
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
            cbb_Categories.Location = new Point(52, 378);
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
            cbb_Producers.Location = new Point(52, 490);
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
            cbb_Units.Location = new Point(53, 196);
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
            btn_Save.Location = new Point(248, 580);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(198, 45);
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
            llb_AddUnit.Location = new Point(42, 645);
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
            llb_AddCategory.Location = new Point(277, 645);
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
            llb_AddProducer.Location = new Point(515, 645);
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
            mttb_Description.Location = new Point(410, 378);
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
            mttb_Description.Size = new Size(281, 161);
            mttb_Description.TabIndex = 13;
            mttb_Description.TabStop = false;
            mttb_Description.TextAlign = HorizontalAlignment.Left;
            mttb_Description.UseSystemPasswordChar = false;
            mttb_Description.Click += mttb_Description_Click;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(410, 345);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(42, 19);
            materialLabel5.TabIndex = 14;
            materialLabel5.Text = "Mô tả";
            // 
            // pictureBox
            // 
            pictureBox.ImageLocation = "";
            pictureBox.Location = new Point(410, 51);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(281, 276);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 15;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // nmr_BaseUnitPrice
            // 
            nmr_BaseUnitPrice.Location = new Point(53, 300);
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
            materialLabel6.Location = new Point(53, 266);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(29, 19);
            materialLabel6.TabIndex = 17;
            materialLabel6.Text = " Giá";
            // 
            // ProductInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 720);
            Controls.Add(materialLabel6);
            Controls.Add(nmr_BaseUnitPrice);
            Controls.Add(pictureBox);
            Controls.Add(materialLabel5);
            Controls.Add(mttb_Description);
            Controls.Add(llb_AddProducer);
            Controls.Add(llb_AddCategory);
            Controls.Add(llb_AddUnit);
            Controls.Add(btn_Save);
            Controls.Add(cbb_Units);
            Controls.Add(cbb_Producers);
            Controls.Add(cbb_Categories);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(tb_ProductName);
            Controls.Add(materialLabel1);
            Name = "ProductInputView";
            Text = "ProductInputView";
            Load += ProductInputView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_BaseUnitPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}