using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form nhập liệu cho danh mục sản phẩm
    /// Cho phép thêm mới và chỉnh sửa thông tin danh mục, bao gồm:
    /// - Tên danh mục
    /// - Mô tả danh mục
    /// </summary>
    public partial class CategoryInputView : Form
    {
        #region Fields

        /// <summary>
        /// Đối tượng danh mục cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly Models.Category? _category;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form nhập liệu danh mục
        /// </summary>
        /// <param name="category">Đối tượng danh mục cần chỉnh sửa (null nếu thêm mới)</param>
        public CategoryInputView(Models.Category? category = null)
        {
            InitializeComponent();
            _category = category;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện load form
        /// - Nạp thông tin danh mục nếu ở chế độ chỉnh sửa
        /// </summary>
        private void CategoryInputView_Load(object sender, EventArgs e)
        {
            if (_category != null)
            {
                LoadExistingCategory();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Đóng form và trả về thông tin danh mục
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            this.Tag = (tb_Name.Text, mttb_Description.Text);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong textbox mô tả
        /// - Tự động kích hoạt nút Lưu
        /// </summary>
        private void mttb_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Nạp thông tin danh mục hiện có khi ở chế độ chỉnh sửa
        /// </summary>
        private void LoadExistingCategory()
        {
            tb_Name.Text = _category.Name;
            mttb_Description.Text = _category.Description;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập
        /// </summary>
        /// <returns>True nếu dữ liệu hợp lệ, False nếu không</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tb_Name.Text))
            {
                ShowError("Tên danh mục không được để trống");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Hiển thị thông báo lỗi
        /// </summary>
        /// <param name="message">Nội dung lỗi</param>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
