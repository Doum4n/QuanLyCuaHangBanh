namespace QuanLyCuaHangBanh.Views.Unit
{
    partial class UnitInputView
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
            tb_Name = new TextBox();
            label2 = new Label();
            rtb_Description = new RichTextBox();
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 42);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đơn vị tính";
            // 
            // tb_Name
            // 
            tb_Name.BorderStyle = BorderStyle.None;
            tb_Name.Location = new Point(61, 74);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(168, 20);
            tb_Name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 126);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Mô tả";
            // 
            // rtb_Description
            // 
            rtb_Description.BorderStyle = BorderStyle.None;
            rtb_Description.Location = new Point(61, 163);
            rtb_Description.Name = "rtb_Description";
            rtb_Description.Size = new Size(474, 120);
            rtb_Description.TabIndex = 3;
            rtb_Description.Text = "";
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(214, 336);
            btn_Save.Margin = new Padding(4, 6, 4, 6);
            btn_Save.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Save.Name = "btn_Save";
            btn_Save.NoAccentTextColor = Color.Empty;
            btn_Save.Size = new Size(198, 45);
            btn_Save.TabIndex = 4;
            btn_Save.Text = "Lưu";
            btn_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Save.UseAccentColor = false;
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // UnitInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 434);
            Controls.Add(btn_Save);
            Controls.Add(rtb_Description);
            Controls.Add(label2);
            Controls.Add(tb_Name);
            Controls.Add(label1);
            Name = "UnitInputView";
            Load += UnitInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_Name;
        private Label label2;
        private RichTextBox rtb_Description;
        private MaterialSkin.Controls.MaterialButton btn_Save;
    }
}