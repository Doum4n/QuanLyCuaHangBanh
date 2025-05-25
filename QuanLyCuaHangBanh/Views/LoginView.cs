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
    public partial class LoginView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        public LoginView()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // Fix for CS0854: Extract the BCrypt.Verify call into a local variable
            var username = tb_Username.Text;
            var password = tb_password.Text;

            bool isValid = context.Employees
                .Where(u => u.Username == username)
                .AsEnumerable() // Convert to in-memory collection to allow method calls with optional arguments
                .Any(u => BCrypt.Net.BCrypt.Verify(password, u.Password));

            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }
    }
}
