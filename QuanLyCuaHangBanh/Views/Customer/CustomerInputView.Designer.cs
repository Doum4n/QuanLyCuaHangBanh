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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInputView));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            tb_CustomerName = new TextBox();
            tb_PhoneNumer = new TextBox();
            mttb_Address = new RichTextBox();
            cbb_CustomerTypes = new ComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
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
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(45, 125);
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
            materialLabel3.Location = new Point(303, 34);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(50, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "Địa chỉ";
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(195, 336);
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
            // tb_CustomerName
            // 
            tb_CustomerName.BorderStyle = BorderStyle.None;
            tb_CustomerName.Location = new Point(45, 78);
            tb_CustomerName.Name = "tb_CustomerName";
            tb_CustomerName.Size = new Size(194, 20);
            tb_CustomerName.TabIndex = 0;
            // 
            // tb_PhoneNumer
            // 
            tb_PhoneNumer.BorderStyle = BorderStyle.None;
            tb_PhoneNumer.Location = new Point(45, 159);
            tb_PhoneNumer.Name = "tb_PhoneNumer";
            tb_PhoneNumer.Size = new Size(194, 20);
            tb_PhoneNumer.TabIndex = 1;
            // 
            // mttb_Address
            // 
            mttb_Address.BorderStyle = BorderStyle.None;
            mttb_Address.Location = new Point(304, 78);
            mttb_Address.Name = "mttb_Address";
            mttb_Address.Size = new Size(250, 187);
            mttb_Address.TabIndex = 2;
            mttb_Address.Text = "";
            // 
            // cbb_CustomerTypes
            // 
            cbb_CustomerTypes.FormattingEnabled = true;
            cbb_CustomerTypes.Location = new Point(45, 237);
            cbb_CustomerTypes.Name = "cbb_CustomerTypes";
            cbb_CustomerTypes.Size = new Size(194, 28);
            cbb_CustomerTypes.TabIndex = 3;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(45, 202);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(119, 19);
            materialLabel4.TabIndex = 11;
            materialLabel4.Text = "Loại khách hàng";
            // 
            // CustomerInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 410);
            Controls.Add(materialLabel4);
            Controls.Add(cbb_CustomerTypes);
            Controls.Add(mttb_Address);
            Controls.Add(tb_PhoneNumer);
            Controls.Add(tb_CustomerName);
            Controls.Add(btn_Save);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CustomerInputView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm khách hàng";
            Load += CustomerInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private TextBox tb_CustomerName;
        private TextBox tb_PhoneNumer;
        private RichTextBox mttb_Address;
        private ComboBox cbb_CustomerTypes;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}