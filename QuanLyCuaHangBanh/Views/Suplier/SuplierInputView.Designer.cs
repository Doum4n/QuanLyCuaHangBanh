namespace QuanLyCuaHangBanh.Views
{
    partial class SuplierInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuplierInputView));
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            tb_ProducerName = new TextBox();
            tb_PhoneNumber = new TextBox();
            tb_Email = new TextBox();
            mttb_Address = new RichTextBox();
            mttb_Description = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nmr_Limit = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            nmr_CreditPeriod = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nmr_Limit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_CreditPeriod).BeginInit();
            SuspendLayout();
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(498, 203);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(1, 0);
            materialLabel3.TabIndex = 7;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(223, 536);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(158, 36);
            btn_Save.TabIndex = 14;
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
            materialLabel5.Location = new Point(580, 33);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(1, 0);
            materialLabel5.TabIndex = 16;
            // 
            // tb_ProducerName
            // 
            tb_ProducerName.BorderStyle = BorderStyle.None;
            tb_ProducerName.Location = new Point(44, 80);
            tb_ProducerName.Name = "tb_ProducerName";
            tb_ProducerName.Size = new Size(208, 20);
            tb_ProducerName.TabIndex = 0;
            // 
            // tb_PhoneNumber
            // 
            tb_PhoneNumber.BorderStyle = BorderStyle.None;
            tb_PhoneNumber.Location = new Point(44, 163);
            tb_PhoneNumber.Name = "tb_PhoneNumber";
            tb_PhoneNumber.Size = new Size(208, 20);
            tb_PhoneNumber.TabIndex = 1;
            // 
            // tb_Email
            // 
            tb_Email.BorderStyle = BorderStyle.None;
            tb_Email.Location = new Point(44, 251);
            tb_Email.Name = "tb_Email";
            tb_Email.Size = new Size(208, 20);
            tb_Email.TabIndex = 2;
            // 
            // mttb_Address
            // 
            mttb_Address.BorderStyle = BorderStyle.None;
            mttb_Address.Location = new Point(341, 73);
            mttb_Address.Name = "mttb_Address";
            mttb_Address.Size = new Size(208, 110);
            mttb_Address.TabIndex = 5;
            mttb_Address.Text = "";
            // 
            // mttb_Description
            // 
            mttb_Description.BorderStyle = BorderStyle.None;
            mttb_Description.Location = new Point(347, 251);
            mttb_Description.Name = "mttb_Description";
            mttb_Description.Size = new Size(206, 115);
            mttb_Description.TabIndex = 6;
            mttb_Description.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 47);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 22;
            label1.Text = "Tên nhà cung cấp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 128);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 23;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 220);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 24;
            label3.Text = "Email";
            // 
            // nmr_Limit
            // 
            nmr_Limit.Location = new Point(44, 339);
            nmr_Limit.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Limit.Name = "nmr_Limit";
            nmr_Limit.Size = new Size(150, 27);
            nmr_Limit.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 311);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 26;
            label4.Text = "Hạn múc công nợ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(351, 219);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 27;
            label5.Text = "Mô tả";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(347, 33);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 28;
            label6.Text = "Địa chỉ";
            // 
            // nmr_CreditPeriod
            // 
            nmr_CreditPeriod.Location = new Point(44, 431);
            nmr_CreditPeriod.Name = "nmr_CreditPeriod";
            nmr_CreditPeriod.Size = new Size(150, 27);
            nmr_CreditPeriod.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 408);
            label7.Name = "label7";
            label7.Size = new Size(133, 20);
            label7.TabIndex = 30;
            label7.Text = "Thời hạn tính dụng";
            // 
            // SuplierInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 626);
            Controls.Add(label7);
            Controls.Add(nmr_CreditPeriod);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nmr_Limit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mttb_Description);
            Controls.Add(mttb_Address);
            Controls.Add(tb_Email);
            Controls.Add(tb_PhoneNumber);
            Controls.Add(tb_ProducerName);
            Controls.Add(materialLabel5);
            Controls.Add(btn_Save);
            Controls.Add(materialLabel3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SuplierInputView";
            Text = "Nhà cung cấp";
            Load += ProducerInputView_Load;
            ((System.ComponentModel.ISupportInitialize)nmr_Limit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_CreditPeriod).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private TextBox tb_ProducerName;
        private TextBox tb_PhoneNumber;
        private TextBox tb_Email;
        private RichTextBox mttb_Address;
        private RichTextBox mttb_Description;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown nmr_Limit;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown nmr_CreditPeriod;
        private Label label7;
    }
}