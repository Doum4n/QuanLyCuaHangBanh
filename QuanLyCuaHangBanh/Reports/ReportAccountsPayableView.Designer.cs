namespace QuanLyCuaHangBanh.Reports
{
    partial class ReportAccountsPayable
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
            panel1 = new Panel();
            btn_ShowAll = new MaterialSkin.Controls.MaterialButton();
            btn_Fiilter = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            cbb_Suppliers = new ComboBox();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_ShowAll);
            panel1.Controls.Add(btn_Fiilter);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbb_Suppliers);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 86);
            panel1.TabIndex = 0;
            // 
            // btn_ShowAll
            // 
            btn_ShowAll.AutoSize = false;
            btn_ShowAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_ShowAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_ShowAll.Depth = 0;
            btn_ShowAll.HighEmphasis = true;
            btn_ShowAll.Icon = null;
            btn_ShowAll.Location = new Point(392, 32);
            btn_ShowAll.Margin = new Padding(4, 6, 4, 6);
            btn_ShowAll.MouseState = MaterialSkin.MouseState.HOVER;
            btn_ShowAll.Name = "btn_ShowAll";
            btn_ShowAll.NoAccentTextColor = Color.Empty;
            btn_ShowAll.Size = new Size(129, 36);
            btn_ShowAll.TabIndex = 3;
            btn_ShowAll.Text = "Hiển thị tất cả";
            btn_ShowAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_ShowAll.UseAccentColor = false;
            btn_ShowAll.UseVisualStyleBackColor = true;
            btn_ShowAll.Click += btn_ShowAll_Click;
            // 
            // btn_Fiilter
            // 
            btn_Fiilter.AutoSize = false;
            btn_Fiilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Fiilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Fiilter.Depth = 0;
            btn_Fiilter.HighEmphasis = true;
            btn_Fiilter.Icon = null;
            btn_Fiilter.Location = new Point(255, 32);
            btn_Fiilter.Margin = new Padding(4, 6, 4, 6);
            btn_Fiilter.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Fiilter.Name = "btn_Fiilter";
            btn_Fiilter.NoAccentTextColor = Color.Empty;
            btn_Fiilter.Size = new Size(129, 36);
            btn_Fiilter.TabIndex = 2;
            btn_Fiilter.Text = "Lọc kêt quả";
            btn_Fiilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Fiilter.UseAccentColor = false;
            btn_Fiilter.UseVisualStyleBackColor = true;
            btn_Fiilter.Click += btn_Fiilter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 12);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 1;
            label1.Text = "Nhà cung cấp";
            // 
            // cbb_Suppliers
            // 
            cbb_Suppliers.FormattingEnabled = true;
            cbb_Suppliers.Location = new Point(21, 40);
            cbb_Suppliers.Name = "cbb_Suppliers";
            cbb_Suppliers.Size = new Size(151, 28);
            cbb_Suppliers.TabIndex = 0;
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(800, 450);
            reportViewer1.TabIndex = 0;
            // 
            // ReportAccountsPayable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(reportViewer1);
            Name = "ReportAccountsPayable";
            Text = "ReportAccountsPayable";
            Load += ReportAccountsPayable_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btn_ShowAll;
        private MaterialSkin.Controls.MaterialButton btn_Fiilter;
        private Label label1;
        private ComboBox cbb_Suppliers;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}