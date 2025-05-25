namespace QuanLyCuaHangBanh.Reports
{
    partial class ReportOrderView
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1 = new Panel();
            btn_ShowAll = new MaterialSkin.Controls.MaterialButton();
            btn_Filter = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            dtp_ToDate = new DateTimePicker();
            label1 = new Label();
            dtp_FormDate = new DateTimePicker();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(815, 480);
            reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_ShowAll);
            panel1.Controls.Add(btn_Filter);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtp_ToDate);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtp_FormDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(815, 77);
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
            btn_ShowAll.Location = new Point(663, 19);
            btn_ShowAll.Margin = new Padding(4, 6, 4, 6);
            btn_ShowAll.MouseState = MaterialSkin.MouseState.HOVER;
            btn_ShowAll.Name = "btn_ShowAll";
            btn_ShowAll.NoAccentTextColor = Color.Empty;
            btn_ShowAll.Size = new Size(124, 36);
            btn_ShowAll.TabIndex = 5;
            btn_ShowAll.Text = "Hiện tất cả";
            btn_ShowAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_ShowAll.UseAccentColor = false;
            btn_ShowAll.UseVisualStyleBackColor = true;
            btn_ShowAll.Click += btn_ShowAll_Click;
            // 
            // btn_Filter
            // 
            btn_Filter.AutoSize = false;
            btn_Filter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Filter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Filter.Depth = 0;
            btn_Filter.HighEmphasis = true;
            btn_Filter.Icon = null;
            btn_Filter.Location = new Point(508, 18);
            btn_Filter.Margin = new Padding(4, 6, 4, 6);
            btn_Filter.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Filter.Name = "btn_Filter";
            btn_Filter.NoAccentTextColor = Color.Empty;
            btn_Filter.Size = new Size(128, 37);
            btn_Filter.TabIndex = 4;
            btn_Filter.Text = "Lọc kết quả";
            btn_Filter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Filter.UseAccentColor = false;
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 25);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Đến ngày:";
            // 
            // dtp_ToDate
            // 
            dtp_ToDate.CustomFormat = "dd/MM/yyyy";
            dtp_ToDate.Format = DateTimePickerFormat.Custom;
            dtp_ToDate.Location = new Point(353, 26);
            dtp_ToDate.Name = "dtp_ToDate";
            dtp_ToDate.Size = new Size(124, 27);
            dtp_ToDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 26);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 1;
            label1.Text = "Từ ngày:";
            // 
            // dtp_FormDate
            // 
            dtp_FormDate.CustomFormat = "dd/MM/yyyy";
            dtp_FormDate.Format = DateTimePickerFormat.Custom;
            dtp_FormDate.Location = new Point(105, 26);
            dtp_FormDate.Name = "dtp_FormDate";
            dtp_FormDate.Size = new Size(124, 27);
            dtp_FormDate.TabIndex = 0;
            // 
            // ReportOrderView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 480);
            Controls.Add(panel1);
            Controls.Add(reportViewer1);
            Name = "ReportOrderView";
            Text = "ReportOrderView";
            Load += ReportOrderView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Panel panel1;
        private Label label1;
        private DateTimePicker dtp_FormDate;
        private Label label2;
        private DateTimePicker dtp_ToDate;
        private MaterialSkin.Controls.MaterialButton btn_Filter;
        private MaterialSkin.Controls.MaterialButton btn_ShowAll;
    }
}