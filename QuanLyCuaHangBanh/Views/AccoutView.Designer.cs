namespace QuanLyCuaHangBanh.Views
{
    partial class AccoutView
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
            tb_Username = new TextBox();
            tb_OldPassword = new TextBox();
            label2 = new Label();
            tb_NewPassword = new TextBox();
            label3 = new Label();
            tb_ConfirmPassword = new TextBox();
            label4 = new Label();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            lbl_ErrorMessage = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 52);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // tb_Username
            // 
            tb_Username.Location = new Point(225, 49);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new Size(158, 27);
            tb_Username.TabIndex = 1;
            // 
            // tb_OldPassword
            // 
            tb_OldPassword.Location = new Point(225, 101);
            tb_OldPassword.Name = "tb_OldPassword";
            tb_OldPassword.Size = new Size(158, 27);
            tb_OldPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 101);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu cũ";
            // 
            // tb_NewPassword
            // 
            tb_NewPassword.Location = new Point(225, 157);
            tb_NewPassword.Name = "tb_NewPassword";
            tb_NewPassword.Size = new Size(158, 27);
            tb_NewPassword.TabIndex = 5;
            tb_NewPassword.TextChanged += tb_NewPassword_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 157);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu mới";
            // 
            // tb_ConfirmPassword
            // 
            tb_ConfirmPassword.Location = new Point(225, 216);
            tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            tb_ConfirmPassword.Size = new Size(158, 27);
            tb_ConfirmPassword.TabIndex = 7;
            tb_ConfirmPassword.TextChanged += tb_ConfirmPassword_TextChanged;
            tb_ConfirmPassword.KeyDown += tb_ConfirmPassword_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 216);
            label4.Name = "label4";
            label4.Size = new Size(160, 20);
            label4.TabIndex = 6;
            label4.Text = "Nhập lại mật khẩu mới";
            label4.Click += label4_Click;
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(174, 280);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(93, 36);
            btn_Save.TabIndex = 8;
            btn_Save.Text = " Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // lbl_ErrorMessage
            // 
            lbl_ErrorMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_ErrorMessage.AutoSize = true;
            lbl_ErrorMessage.Location = new Point(199, 333);
            lbl_ErrorMessage.Name = "lbl_ErrorMessage";
            lbl_ErrorMessage.Size = new Size(50, 20);
            lbl_ErrorMessage.TabIndex = 9;
            lbl_ErrorMessage.Text = "label5";
            // 
            // AccoutView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 373);
            Controls.Add(lbl_ErrorMessage);
            Controls.Add(btn_Save);
            Controls.Add(tb_ConfirmPassword);
            Controls.Add(label4);
            Controls.Add(tb_NewPassword);
            Controls.Add(label3);
            Controls.Add(tb_OldPassword);
            Controls.Add(label2);
            Controls.Add(tb_Username);
            Controls.Add(label1);
            Name = "AccoutView";
            Text = "AccoutView";
            Load += AccoutView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_Username;
        private TextBox tb_OldPassword;
        private Label label2;
        private TextBox tb_NewPassword;
        private Label label3;
        private TextBox tb_ConfirmPassword;
        private Label label4;
        private MaterialSkin.Controls.MaterialButton btn_Save;
        private Label lbl_ErrorMessage;
    }
}