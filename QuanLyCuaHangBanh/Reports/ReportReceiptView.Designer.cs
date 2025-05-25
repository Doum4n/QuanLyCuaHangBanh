namespace QuanLyCuaHangBanh.Reports
{
    partial class ReportReceiptView
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
            dtp_FromDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dpt_ToDate = new DateTimePicker();
            btn_Filter = new MaterialSkin.Controls.MaterialButton();
            btn_ShowAll = new MaterialSkin.Controls.MaterialButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_ShowAll);
            panel1.Controls.Add(btn_Filter);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dpt_ToDate);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtp_FromDate);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 54);
            panel1.TabIndex = 0;
            // 
            // dtp_FromDate
            // 
            dtp_FromDate.CustomFormat = "dd/MM/yyyy";
            dtp_FromDate.Format = DateTimePickerFormat.Custom;
            dtp_FromDate.Location = new Point(152, 12);
            dtp_FromDate.Name = "dtp_FromDate";
            dtp_FromDate.Size = new Size(127, 27);
            dtp_FromDate.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 14);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 1;
            label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 15);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Đến ngày:";
            // 
            // dpt_ToDate
            // 
            dpt_ToDate.CustomFormat = "dd/MM/yyyy";
            dpt_ToDate.Format = DateTimePickerFormat.Custom;
            dpt_ToDate.Location = new Point(421, 12);
            dpt_ToDate.Name = "dpt_ToDate";
            dpt_ToDate.Size = new Size(127, 27);
            dpt_ToDate.TabIndex = 2;
            // 
            // btn_Filter
            // 
            btn_Filter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Filter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Filter.Depth = 0;
            btn_Filter.HighEmphasis = true;
            btn_Filter.Icon = null;
            btn_Filter.Location = new Point(624, 9);
            btn_Filter.Margin = new Padding(4, 6, 4, 6);
            btn_Filter.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Filter.Name = "btn_Filter";
            btn_Filter.NoAccentTextColor = Color.Empty;
            btn_Filter.Size = new Size(112, 36);
            btn_Filter.TabIndex = 4;
            btn_Filter.Text = "Lọc kết quả";
            btn_Filter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Filter.UseAccentColor = false;
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // btn_ShowAll
            // 
            btn_ShowAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_ShowAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_ShowAll.Depth = 0;
            btn_ShowAll.HighEmphasis = true;
            btn_ShowAll.Icon = null;
            btn_ShowAll.Location = new Point(769, 9);
            btn_ShowAll.Margin = new Padding(4, 6, 4, 6);
            btn_ShowAll.MouseState = MaterialSkin.MouseState.HOVER;
            btn_ShowAll.Name = "btn_ShowAll";
            btn_ShowAll.NoAccentTextColor = Color.Empty;
            btn_ShowAll.Size = new Size(109, 36);
            btn_ShowAll.TabIndex = 5;
            btn_ShowAll.Text = "Hiện tất cả";
            btn_ShowAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_ShowAll.UseAccentColor = false;
            btn_ShowAll.UseVisualStyleBackColor = true;
            btn_ShowAll.Click += btn_ShowAll_Click;
            // 
            // ReportReceiptView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 521);
            Controls.Add(panel1);
            Name = "ReportReceiptView";
            Text = "ReportReceiptView";
            Load += ReportReceiptView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Panel panel1;
        private Label label2;
        private DateTimePicker dpt_ToDate;
        private Label label1;
        private DateTimePicker dtp_FromDate;
        private MaterialSkin.Controls.MaterialButton btn_Filter;
        private MaterialSkin.Controls.MaterialButton btn_ShowAll;
    }
}