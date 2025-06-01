using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form quản lý thông tin tài khoản người dùng
    /// </summary>
    public partial class AccoutView : Form
    {
        #region Fields
        /// <summary>
        /// Database context
        /// </summary>
        private readonly QLCHB_DBContext context = new QLCHB_DBContext();
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo form quản lý tài khoản
        /// </summary>
        public AccoutView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện khi form được load
        /// </summary>
        private void AccoutView_Load(object sender, EventArgs e)
        {
            tb_Username.Text = Session.EmployeeName;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            var OldPassword = context.Employees.FirstOrDefault(o => o.ID == Session.EmployeeId)?.Password;
            if (OldPassword != null && BCrypt.Net.BCrypt.Verify(tb_OldPassword.Text, OldPassword))
            {
                if (tb_NewPassword.Text == tb_ConfirmPassword.Text && tb_NewPassword.Text.Length >= 6)
                {
                    // Cập nhật mật khẩu trong database
                    var employee = context.Employees.FirstOrDefault(o => o.ID == Session.EmployeeId);
                    if (employee != null)
                    {
                        employee.Password = BCrypt.Net.BCrypt.HashPassword(tb_NewPassword.Text);
                        context.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    lbl_ErrorMessage.Text = "Mật khẩu mới và xác nhận mật khẩu không khớp hoặc quá ngắn!";
                }
            }
            else
            {
                lbl_ErrorMessage.Text = "Mật khẩu cũ không đúng!";
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong ô xác nhận mật khẩu
        /// </summary>
        private void tb_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.PerformClick();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi nội dung ô xác nhận mật khẩu
        /// </summary>
        private void tb_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (tb_ConfirmPassword.Text != tb_NewPassword.Text)
            {
                lbl_ErrorMessage.Text = "Mật khẩu không khớp!";
            }
            else
            {
                lbl_ErrorMessage.Text = string.Empty;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi nội dung ô mật khẩu mới
        /// </summary>
        private void tb_NewPassword_TextChanged(object sender, EventArgs e)
        {
            if (tb_NewPassword.Text.Length < 6)
            {
                lbl_ErrorMessage.Text = "Mật khẩu phải có ít nhất 6 ký tự!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[A-Z]") ||
                     !System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[a-z]") ||
                     !System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[0-9]"))
            {
                lbl_ErrorMessage.Text = "Mật khẩu phải chứa ít nhất một chữ hoa, một chữ thường, một số!";
            }
            else
            {
                lbl_ErrorMessage.Text = string.Empty;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào label (không cần thiết)
        /// </summary>
        private void label4_Click(object sender, EventArgs e)
        {
            // Không cần xử lý
        }
        #endregion
    }
}
