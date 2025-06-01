using QuanLyCuaHangBanh.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using QuanLyCuaHangBanh.Uitls; // Assuming you are using BCrypt for password hashing

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form đăng nhập vào hệ thống
    /// Xác thực người dùng và lưu thông tin phiên làm việc
    /// </summary>
    public partial class LoginView : Form
    {
        #region Fields
        /// <summary>
        /// Database context để truy cập dữ liệu
        /// </summary>
        private readonly QLCHB_DBContext context = new QLCHB_DBContext();
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo form đăng nhập
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện click nút đăng nhập
        /// Kiểm tra thông tin đăng nhập và lưu thông tin phiên làm việc
        /// </summary>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            var username = tb_Username.Text;
            var password = tb_password.Text;

            // Kiểm tra thông tin đăng nhập
            bool isValid = context.Employees
                .Where(u => u.Username == username)
                .AsEnumerable()
                .Any(u => BCrypt.Net.BCrypt.Verify(password, u.Password));

            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Lưu thông tin người dùng vào Session
                Session.Role = context.Employees
                    .Where(u => u.Username == username)
                    .Select(u => u.Role)
                    .FirstOrDefault();

                Session.EmployeeId = context.Employees
                    .Where(u => u.Username == username)
                    .Select(u => u.ID)
                    .FirstOrDefault();

                Session.EmployeeName = context.Employees
                    .Where(u => u.Username == username)
                    .Select(u => u.Name)
                    .FirstOrDefault();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn phím Enter trong ô mật khẩu
        /// Tự động kích hoạt nút đăng nhập
        /// </summary>
        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }
        #endregion
    }
}
