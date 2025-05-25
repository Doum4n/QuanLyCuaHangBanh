using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Views
{
    public partial class AccoutView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        public AccoutView()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var OldPassword = context.Employees.FirstOrDefault(o => o.ID == Session.EmployeeId).Password;
            if (BCrypt.Net.BCrypt.Verify(tb_OldPassword.Text, OldPassword))
            {
                if (tb_NewPassword.Text == tb_ConfirmPassword.Text && tb_NewPassword.Text.Length >= 6)
                {
                    // Update the password in the database
                    var employee = context.Employees.FirstOrDefault(o => o.ID == Session.EmployeeId);
                    if (employee != null)
                    {
                        employee.Password = BCrypt.Net.BCrypt.HashPassword(tb_NewPassword.Text);
                        context.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Close the form after saving
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
        private void tb_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.PerformClick();
            }
        }

        private void tb_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional: You can add logic here to validate the confirm password field
            // For example, check if it matches the new password
            if (tb_ConfirmPassword.Text != tb_NewPassword.Text)
            {
                lbl_ErrorMessage.Text = "mật khẩu không khớp!";
            }
            else
            {
                lbl_ErrorMessage.Text = string.Empty; // Clear error message if passwords match
            }
        }

        private void tb_NewPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional: You can add logic here to validate the new password field
            // For example, check if it meets certain criteria (length, complexity, etc.)
            if (tb_NewPassword.Text.Length < 6)
            {
                lbl_ErrorMessage.Text = "Mật khẩu phải có ít nhất 6 ký tự!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[A-Z]") ||
                     !System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[a-z]") ||
                     !System.Text.RegularExpressions.Regex.IsMatch(tb_NewPassword.Text, @"[0-9]"))
            {
                lbl_ErrorMessage.Text = "Mật khẩu phải chứ ít nhất một chữ hoa, một chữ thường, một số!";
            }
            else
            {
                lbl_ErrorMessage.Text = string.Empty; // Clear error message if password is valid
            }
        }

        private void AccoutView_Load(object sender, EventArgs e)
        {
            tb_Username.Text = Session.EmployeeName;
        }
    }
}
