namespace QuanLyCuaHangBanh.Views
{
    partial class CustomerInputView
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
            tb_CustomerName = new MaterialSkin.Controls.MaterialTextBox();
            tb_PhoneNumer = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            mttb_Address = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(45, 42);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(68, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Họ và tên";
            // 
            // tb_CustomerName
            // 
            tb_CustomerName.AnimateReadOnly = false;
            tb_CustomerName.BorderStyle = BorderStyle.None;
            tb_CustomerName.Depth = 0;
            tb_CustomerName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tb_CustomerName.LeadingIcon = null;
            tb_CustomerName.Location = new Point(45, 78);
            tb_CustomerName.MaxLength = 50;
            tb_CustomerName.MouseState = MaterialSkin.MouseState.OUT;
            tb_CustomerName.Multiline = false;
            tb_CustomerName.Name = "tb_CustomerName";
            tb_CustomerName.Size = new Size(303, 50);
            tb_CustomerName.TabIndex = 1;
            tb_CustomerName.Text = "";
            tb_CustomerName.TrailingIcon = null;
            // 
            // tb_PhoneNumer
            // 
            tb_PhoneNumer.AnimateReadOnly = false;
            tb_PhoneNumer.BorderStyle = BorderStyle.None;
            tb_PhoneNumer.Depth = 0;
            tb_PhoneNumer.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            tb_PhoneNumer.LeadingIcon = null;
            tb_PhoneNumer.Location = new Point(45, 185);
            tb_PhoneNumer.MaxLength = 50;
            tb_PhoneNumer.MouseState = MaterialSkin.MouseState.OUT;
            tb_PhoneNumer.Multiline = false;
            tb_PhoneNumer.Name = "tb_PhoneNumer";
            tb_PhoneNumer.Size = new Size(303, 50);
            tb_PhoneNumer.TabIndex = 3;
            tb_PhoneNumer.Text = "";
            tb_PhoneNumer.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(45, 149);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(94, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Số diện thoại";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(421, 41);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(50, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Địa chỉ";
            // 
            // mttb_Address
            // 
            mttb_Address.AnimateReadOnly = false;
            mttb_Address.BackgroundImageLayout = ImageLayout.None;
            mttb_Address.CharacterCasing = CharacterCasing.Normal;
            mttb_Address.Depth = 0;
            mttb_Address.HideSelection = true;
            mttb_Address.Location = new Point(421, 78);
            mttb_Address.MaxLength = 32767;
            mttb_Address.MouseState = MaterialSkin.MouseState.OUT;
            mttb_Address.Name = "mttb_Address";
            mttb_Address.PasswordChar = '\0';
            mttb_Address.ReadOnly = false;
            mttb_Address.ScrollBars = ScrollBars.None;
            mttb_Address.SelectedText = "";
            mttb_Address.SelectionLength = 0;
            mttb_Address.SelectionStart = 0;
            mttb_Address.ShortcutsEnabled = true;
            mttb_Address.Size = new Size(318, 157);
            mttb_Address.TabIndex = 5;
            mttb_Address.TabStop = false;
            mttb_Address.TextAlign = HorizontalAlignment.Left;
            mttb_Address.UseSystemPasswordChar = false;
            mttb_Address.KeyDown += mttb_Address_KeyDown;
            // 
            // btn_Save
            // 
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(304, 277);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(158, 36);
            btn_Save.TabIndex = 6;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // CustomerInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 355);
            Controls.Add(btn_Save);
            Controls.Add(mttb_Address);
            Controls.Add(materialLabel3);
            Controls.Add(tb_PhoneNumer);
            Controls.Add(materialLabel2);
            Controls.Add(tb_CustomerName);
            Controls.Add(materialLabel1);
            Name = "CustomerInputView";
            Text = "Thêm khách hàng";
            Load += CustomerInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox tb_CustomerName;
        private MaterialSkin.Controls.MaterialTextBox tb_PhoneNumer;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mttb_Address;
        private MaterialSkin.Controls.MaterialButton btn_Save;
    }
}