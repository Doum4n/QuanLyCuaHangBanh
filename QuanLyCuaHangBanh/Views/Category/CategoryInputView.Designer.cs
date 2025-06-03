namespace QuanLyCuaHangBanh.Views
{
    partial class CategoryInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryInputView));
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            tb_Name = new MaterialSkin.Controls.MaterialTextBox2();
            mttb_Description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(75, 115);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(46, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Mô tả:";
            // 
            // tb_Name
            // 
            tb_Name.AnimateReadOnly = false;
            tb_Name.BackgroundImageLayout = ImageLayout.None;
            tb_Name.CharacterCasing = CharacterCasing.Normal;
            tb_Name.Depth = 0;
            tb_Name.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tb_Name.HideSelection = true;
            tb_Name.LeadingIcon = null;
            tb_Name.Location = new Point(159, 45);
            tb_Name.MaxLength = 32767;
            tb_Name.MouseState = MaterialSkin.MouseState.OUT;
            tb_Name.Name = "tb_Name";
            tb_Name.PasswordChar = '\0';
            tb_Name.PrefixSuffixText = null;
            tb_Name.ReadOnly = false;
            tb_Name.RightToLeft = RightToLeft.No;
            tb_Name.SelectedText = "";
            tb_Name.SelectionLength = 0;
            tb_Name.SelectionStart = 0;
            tb_Name.ShortcutsEnabled = true;
            tb_Name.Size = new Size(312, 48);
            tb_Name.TabIndex = 0;
            tb_Name.TabStop = false;
            tb_Name.TextAlign = HorizontalAlignment.Left;
            tb_Name.TrailingIcon = null;
            tb_Name.UseSystemPasswordChar = false;
            // 
            // mttb_Description
            // 
            mttb_Description.AnimateReadOnly = false;
            mttb_Description.BackgroundImageLayout = ImageLayout.None;
            mttb_Description.CharacterCasing = CharacterCasing.Normal;
            mttb_Description.Depth = 0;
            mttb_Description.HideSelection = true;
            mttb_Description.Location = new Point(159, 115);
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
            mttb_Description.Size = new Size(312, 125);
            mttb_Description.TabIndex = 1;
            mttb_Description.TabStop = false;
            mttb_Description.TextAlign = HorizontalAlignment.Left;
            mttb_Description.UseSystemPasswordChar = false;
            mttb_Description.KeyDown += mttb_Description_KeyDown;
            // 
            // btn_Save
            // 
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(159, 260);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(64, 36);
            btn_Save.TabIndex = 7;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(75, 45);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(32, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Tên:";
            // 
            // CategoryInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 328);
            Controls.Add(btn_Save);
            Controls.Add(mttb_Description);
            Controls.Add(tb_Name);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CategoryInputView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loại sản phẩm";
            Load += CategoryInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 tb_Name;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mttb_Description;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}