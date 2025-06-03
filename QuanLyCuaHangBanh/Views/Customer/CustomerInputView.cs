using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form nhập liệu cho khách hàng
    /// Cho phép thêm mới và chỉnh sửa thông tin khách hàng, bao gồm:
    /// - Tên khách hàng
    /// - Số điện thoại
    /// - Địa chỉ
    /// - Loại khách hàng
    /// </summary>
    public partial class CustomerInputView : Form
    {
        #region Fields

        /// <summary>
        /// Đối tượng khách hàng cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly Models.Customer? customer;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form nhập liệu khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng cần chỉnh sửa (null nếu thêm mới)</param>
        public CustomerInputView(Models.Customer? customer = null)
        {
            InitializeComponent();
            this.customer = customer;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện load form
        /// - Khởi tạo danh sách loại khách hàng
        /// - Nạp thông tin khách hàng nếu ở chế độ chỉnh sửa
        /// </summary>
        private void CustomerInputView_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách loại khách hàng
            List<string> types =
            [
                "Cá nhân",
                "Doanh nghiệp"// Regular customer
            ];

            cbb_CustomerTypes.DataSource = types;

            // Nạp thông tin khách hàng nếu ở chế độ chỉnh sửa
            if (customer != null)
            {
                LoadExistingCustomer();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Kiểm tra dữ liệu hợp lệ
        /// - Tạo đối tượng khách hàng mới
        /// - Đóng form và trả về kết quả
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            Models.Customer customer = new Models.Customer
            {
                Name = tb_CustomerName.Text,
                PhoneNumber = tb_PhoneNumer.Text,
                Address = mttb_Address.Text,
                Type = cbb_CustomerTypes.Text
            };

            this.Tag = customer;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong textbox địa chỉ
        /// - Tự động kích hoạt nút Lưu
        /// </summary>
        private void mttb_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Nạp thông tin khách hàng hiện có khi ở chế độ chỉnh sửa
        /// </summary>
        private void LoadExistingCustomer()
        {
            tb_CustomerName.Text = customer.Name;
            tb_PhoneNumer.Text = customer.PhoneNumber;
            mttb_Address.Text = customer.Address;
            cbb_CustomerTypes.Text = customer.Type;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập
        /// </summary>
        /// <returns>True nếu dữ liệu hợp lệ, False nếu không</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(tb_CustomerName.Text))
            {
                ShowError("Tên khách hàng không được để trống");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_PhoneNumer.Text, @"^\d+$"))
            {
                ShowError("Số điện thoại không được chứa ký tự");
                return false;
            }

            if (tb_PhoneNumer.Text.Length != 10)
            {
                ShowError("Số điện thoại phải có 10 số");
                return false;
            }

            if (string.IsNullOrEmpty(mttb_Address.Text))
            {
                ShowError("Địa chỉ không được để trống");
                return false;
            }

            if (string.IsNullOrEmpty(cbb_CustomerTypes.Text))
            {
                ShowError("Loại khách hàng không được để trống");
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
