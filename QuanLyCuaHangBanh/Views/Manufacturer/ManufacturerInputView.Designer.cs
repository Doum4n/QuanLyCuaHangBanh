namespace QuanLyCuaHangBanh.Views.Manufacturer
{
    partial class ManufacturerInputView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManufacturerInputView));
            btn_Save = new MaterialSkin.Controls.MaterialButton();
            rtb_Description = new RichTextBox();
            label2 = new Label();
            tb_Name = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.AutoSize = false;
            btn_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Save.Depth = 0;
            btn_Save.HighEmphasis = true;
            btn_Save.Icon = null;
            btn_Save.Location = new Point(198, 329);
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
            // rtb_Description
            // 
            rtb_Description.BorderStyle = BorderStyle.None;
            rtb_Description.Location = new Point(45, 156);
            rtb_Description.Name = "rtb_Description";
            rtb_Description.Size = new Size(474, 120);
            rtb_Description.TabIndex = 1;
            rtb_Description.Text = "";
            rtb_Description.KeyDown += rtb_Description_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 119);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 7;
            label2.Text = "Mô tả";
            // 
            // tb_Name
            // 
            tb_Name.BorderStyle = BorderStyle.None;
            tb_Name.Location = new Point(45, 67);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(168, 20);
            tb_Name.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 35);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 5;
            label1.Text = "Tên hãng sản xuất";
            // 
            // ManufacturerInputView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 450);
            Controls.Add(btn_Save);
            Controls.Add(rtb_Description);
            Controls.Add(label2);
            Controls.Add(tb_Name);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManufacturerInputView";
            Text = "Hãng sản xuất";
            Load += IManufacturerInputView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btn_Save;
        private RichTextBox rtb_Description;
        private Label label2;
        private TextBox tb_Name;
        private Label label1;
    }
}