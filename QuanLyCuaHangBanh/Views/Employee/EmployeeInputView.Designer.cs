namespace QuanLyCuaHangBanh.Views.Employee
{
    partial class EmployeeInputView
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tb_EmployeeName = new TextBox();
            tb_PhoneNumber = new TextBox();
            rtb_Address = new RichTextBox();
            cbb_Role = new ComboBox();
            tb_Username = new TextBox();
            tb_Password = new TextBox();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 20);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 20);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 94);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 94);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 173);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 4;
            label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(296, 173);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 5;
            label6.Text = "Vai trò";
            // 
            // tb_EmployeeName
            // 
            tb_EmployeeName.Location = new Point(24, 55);
            tb_EmployeeName.Name = "tb_EmployeeName";
            tb_EmployeeName.Size = new Size(213, 27);
            tb_EmployeeName.TabIndex = 6;
            // 
            // tb_PhoneNumber
            // 
            tb_PhoneNumber.Location = new Point(24, 133);
            tb_PhoneNumber.Name = "tb_PhoneNumber";
            tb_PhoneNumber.Size = new Size(213, 27);
            tb_PhoneNumber.TabIndex = 7;
            // 
            // rtb_Address
            // 
            rtb_Address.BorderStyle = BorderStyle.None;
            rtb_Address.Location = new Point(22, 210);
            rtb_Address.Name = "rtb_Address";
            rtb_Address.Size = new Size(215, 165);
            rtb_Address.TabIndex = 8;
            rtb_Address.Text = "";
            // 
            // cbb_Role
            // 
            cbb_Role.FormattingEnabled = true;
            cbb_Role.Location = new Point(296, 207);
            cbb_Role.Name = "cbb_Role";
            cbb_Role.Size = new Size(213, 28);
            cbb_Role.TabIndex = 9;
            // 
            // tb_Username
            // 
            tb_Username.Location = new Point(296, 55);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new Size(213, 27);
            tb_Username.TabIndex = 10;
            // 
            // tb_Password
            // 
            tb_Password.Location = new Point(296, 133);
            tb_Password.Name = "tb_Password";
            tb_Password.Size = new Size(213, 27);
            tb_Password.TabIndex = 11;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(195, 400);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(158, 36);
            btn_Save.TabIndex = 12;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // EmployeeInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 451);
            Controls.Add(btn_Save);
            Controls.Add(tb_Password);
            Controls.Add(tb_Username);
            Controls.Add(cbb_Role);
            Controls.Add(rtb_Address);
            Controls.Add(tb_PhoneNumber);
            Controls.Add(tb_EmployeeName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeInputView";
            Text = "Nhân viên";
            Load += EmployeeInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tb_EmployeeName;
        private TextBox tb_PhoneNumber;
        private RichTextBox rtb_Address;
        private ComboBox cbb_Role;
        private TextBox tb_Username;
        private TextBox tb_Password;
        private MaterialSkin.Controls.MaterialButton btn_Save;
    }
}