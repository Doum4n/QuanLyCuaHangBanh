namespace QuanLyCuaHangBanh.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            label1 = new Label();
            tb_Username = new TextBox();
            tb_password = new TextBox();
            label2 = new Label();
            btn_Login = new MaterialSkin.Controls.MaterialButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 50);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Text = " Tên đăng nhập";
            // 
            // tb_Username
            // 
            tb_Username.BorderStyle = BorderStyle.None;
            tb_Username.Location = new Point(324, 50);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new Size(182, 20);
            tb_Username.TabIndex = 0;
            // 
            // tb_password
            // 
            tb_password.BorderStyle = BorderStyle.None;
            tb_password.Location = new Point(324, 105);
            tb_password.Name = "tb_password";
            tb_password.Size = new Size(182, 20);
            tb_password.TabIndex = 1;
            tb_password.KeyDown += tb_password_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 105);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu";
            // 
            // btn_Login
            // 
            btn_Login.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Login.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Login.Depth = 0;
            btn_Login.HighEmphasis = true;
            btn_Login.Icon = null;
            btn_Login.Location = new Point(324, 166);
            btn_Login.Margin = new Padding(4, 6, 4, 6);
            btn_Login.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Login.Name = "btn_Login";
            btn_Login.NoAccentTextColor = Color.Empty;
            btn_Login.Size = new Size(105, 36);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Đăng nhập";
            btn_Login.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Login.UseAccentColor = false;
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.access_control_system_abstract_concept;
            pictureBox1.Location = new Point(20, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 251);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Login);
            Controls.Add(tb_password);
            Controls.Add(label2);
            Controls.Add(tb_Username);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginView";
            Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_Username;
        private TextBox tb_password;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton btn_Login;
        private PictureBox pictureBox1;
    }
}