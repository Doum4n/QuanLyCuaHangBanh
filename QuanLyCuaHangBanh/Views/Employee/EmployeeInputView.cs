using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using QuanLyCuaHangBanh.DTO;

namespace QuanLyCuaHangBanh.Views.Employee
{
    /// <summary>
    /// Form nhập liệu cho nhân viên
    /// Cho phép thêm mới và chỉnh sửa thông tin nhân viên, bao gồm:
    /// - Thông tin cá nhân (tên, số điện thoại, địa chỉ)
    /// - Thông tin tài khoản (username, password)
    /// - Vai trò trong hệ thống
    /// </summary>
    public partial class EmployeeInputView : Form
    {
        #region Fields

        /// <summary>
        /// Đối tượng nhân viên cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly EmployeeDTO? employee;

        /// <summary>
        /// Danh sách vai trò trong hệ thống
        /// </summary>
        private readonly List<string> roles = new()
        {
            "Quản lý",
            "Nhân viên bán hàng",
            "Nhân viên kho"
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form nhập liệu nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần chỉnh sửa (null nếu thêm mới)</param>
        public EmployeeInputView(EmployeeDTO? employee = null)
        {
            InitializeComponent();
            this.employee = employee;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện load form
        /// - Khởi tạo danh sách vai trò
        /// - Nạp thông tin nhân viên nếu ở chế độ chỉnh sửa
        /// </summary>
        private void EmployeeInputView_Load(object sender, EventArgs e)
        {
            InitializeRoles();
            if (employee != null)
            {
                LoadExistingEmployee();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Kiểm tra dữ liệu hợp lệ
        /// - Tạo đối tượng nhân viên mới
        /// - Đóng form và trả về kết quả
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInput())
            {
                return;
            }

            Models.Employee addedEmployee = new()
            {
                Name = tb_EmployeeName.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Address = rtb_Address.Text,
                Username = tb_Username.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(tb_Password.Text),
                Role = cbb_Role.Text,
                ID = employee?.ID ?? 0
            };

            this.Tag = addedEmployee;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Khởi tạo danh sách vai trò cho combobox
        /// </summary>
        private void InitializeRoles()
        {
            cbb_Role.Items.Clear();
            cbb_Role.DataSource = roles;
        }

        /// <summary>
        /// Nạp thông tin nhân viên hiện có khi ở chế độ chỉnh sửa
        /// </summary>
        private void LoadExistingEmployee()
        {
            tb_EmployeeName.Text = employee.Name;
            tb_PhoneNumber.Text = employee.PhoneNumber;
            rtb_Address.Text = employee.Address;
            tb_Username.Text = employee.Username;
            cbb_Role.Text = employee.Role;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập
        /// </summary>
        /// <returns>True nếu dữ liệu hợp lệ, False nếu không</returns>
        private bool ValidateEmployeeInput()
        {
            if (string.IsNullOrEmpty(tb_EmployeeName.Text))
            {
                ShowError("Tên nhân viên không được để trống");
                return false;
            }

            if (string.IsNullOrEmpty(tb_PhoneNumber.Text))
            {
                ShowError("Số điện thoại không được để trống");
                return false;
            }

            if (!Regex.IsMatch(tb_PhoneNumber.Text, @"^[0-9]+$"))
            {
                ShowError("Số điện thoại không đúng định dạng");
                return false;
            }

            if (string.IsNullOrEmpty(tb_Username.Text))
            {
                ShowError("Tên tài khoản không được để trống");
                return false;
            }

            if (string.IsNullOrEmpty(tb_Password.Text))
            {
                ShowError("Mật khẩu không được để trống");
                return false;
            }

            if (!ValidatePassword(tb_Password.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(cbb_Role.Text))
            {
                ShowError("Vai trò không được để trống");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của mật khẩu
        /// - Độ dài tối thiểu 6 ký tự
        /// - Chứa ít nhất 1 chữ hoa
        /// - Chứa ít nhất 1 chữ thường
        /// - Chứa ít nhất 1 số
        /// </summary>
        /// <param name="password">Mật khẩu cần kiểm tra</param>
        /// <returns>True nếu mật khẩu hợp lệ, False nếu không</returns>
        private bool ValidatePassword(string password)
        {
            if (password.Length < 6)
            {
                ShowError("Mật khẩu phải có ít nhất 6 ký tự");
                return false;
            }

            if (!Regex.IsMatch(password, @".*[A-Z].*"))
            {
                ShowError("Mật khẩu phải chứa ít nhất một ký tự viết hoa");
                return false;
            }

            if (!Regex.IsMatch(password, @".*[a-z].*"))
            {
                ShowError("Mật khẩu phải chứa ít nhất một ký tự viết thường");
                return false;
            }

            if (!Regex.IsMatch(password, @".*[0-9].*"))
            {
                ShowError("Mật khẩu phải chứa ít nhất một chữ số");
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
