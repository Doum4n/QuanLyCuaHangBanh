namespace QuanLyCuaHangBanh.Views
{
    partial class AddProducts
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
            cbb_Units = new ComboBox();
            label2 = new Label();
            cbb_Products = new ComboBox();
            btn_AddProduct = new MaterialSkin.Controls.MaterialButton();
            nmr_Quantity = new NumericUpDown();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            nmr_PurchasePrice = new NumericUpDown();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            rtb_Note = new RichTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmr_PurchasePrice).BeginInit();
            SuspendLayout();
            // 
            // cbb_Units
            // 
            cbb_Units.FormattingEnabled = true;
            cbb_Units.Location = new Point(22, 135);
            cbb_Units.Name = "cbb_Units";
            cbb_Units.Size = new Size(253, 28);
            cbb_Units.TabIndex = 36;
            cbb_Units.SelectedIndexChanged += cbb_Units_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 24);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 35;
            label2.Text = "Tên sản phẩm";
            // 
            // cbb_Products
            // 
            cbb_Products.FormattingEnabled = true;
            cbb_Products.Location = new Point(22, 58);
            cbb_Products.Name = "cbb_Products";
            cbb_Products.Size = new Size(265, 28);
            cbb_Products.TabIndex = 34;
            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.AutoSize = false;
            btn_AddProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_AddProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_AddProduct.Depth = 0;
            btn_AddProduct.HighEmphasis = true;
            btn_AddProduct.Icon = null;
            btn_AddProduct.Location = new Point(52, 513);
            btn_AddProduct.Margin = new Padding(4, 6, 4, 6);
            btn_AddProduct.MouseState = MaterialSkin.MouseState.HOVER;
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.NoAccentTextColor = Color.Empty;
            btn_AddProduct.Size = new Size(188, 45);
            btn_AddProduct.TabIndex = 30;
            btn_AddProduct.Text = "Thêm";
            btn_AddProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_AddProduct.UseAccentColor = false;
            btn_AddProduct.UseVisualStyleBackColor = true;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // nmr_Quantity
            // 
            nmr_Quantity.Location = new Point(22, 284);
            nmr_Quantity.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_Quantity.Name = "nmr_Quantity";
            nmr_Quantity.Size = new Size(253, 27);
            nmr_Quantity.TabIndex = 32;
            nmr_Quantity.ThousandsSeparator = true;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(22, 101);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(77, 19);
            materialLabel4.TabIndex = 28;
            materialLabel4.Text = "Đơn vị tính";
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(22, 253);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(69, 19);
            materialLabel10.TabIndex = 33;
            materialLabel10.Text = " Số lượng";
            // 
            // nmr_PurchasePrice
            // 
            nmr_PurchasePrice.Location = new Point(22, 206);
            nmr_PurchasePrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmr_PurchasePrice.Name = "nmr_PurchasePrice";
            nmr_PurchasePrice.Size = new Size(253, 27);
            nmr_PurchasePrice.TabIndex = 31;
            nmr_PurchasePrice.ThousandsSeparator = true;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(22, 175);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(29, 19);
            materialLabel6.TabIndex = 29;
            materialLabel6.Text = " Giá";
            // 
            // rtb_Note
            // 
            rtb_Note.BorderStyle = BorderStyle.None;
            rtb_Note.Location = new Point(22, 364);
            rtb_Note.Name = "rtb_Note";
            rtb_Note.Size = new Size(253, 120);
            rtb_Note.TabIndex = 37;
            rtb_Note.Text = "";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(22, 329);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 38;
            materialLabel1.Text = "Ghi chú";
            // 
            // AddProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 583);
            Controls.Add(materialLabel1);
            Controls.Add(rtb_Note);
            Controls.Add(cbb_Units);
            Controls.Add(label2);
            Controls.Add(cbb_Products);
            Controls.Add(btn_AddProduct);
            Controls.Add(nmr_Quantity);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel10);
            Controls.Add(nmr_PurchasePrice);
            Controls.Add(materialLabel6);
            Name = "AddProducts";
            Text = "AddProducts";
            Load += AddProducts_Load;
            ((System.ComponentModel.ISupportInitialize)nmr_Quantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmr_PurchasePrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbb_Units;
        private Label label2;
        private ComboBox cbb_Products;
        private MaterialSkin.Controls.MaterialButton btn_AddProduct;
        private NumericUpDown nmr_Quantity;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private NumericUpDown nmr_PurchasePrice;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private RichTextBox rtb_Note;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}