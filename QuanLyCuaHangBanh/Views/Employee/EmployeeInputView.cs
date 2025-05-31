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
using QuanLyCuaHangBanh.DTO;

namespace QuanLyCuaHangBanh.Views.Employee
{
    public partial class EmployeeInputView : Form
    {
        private EmployeeDTO? employee;
        public EmployeeInputView(EmployeeDTO? employee = null)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void EmployeeInputView_Load(object sender, EventArgs e)
        {
            List<string> roles = new List<string>()
            {
                "Quản lý",
                "Nhân viên bán hàng",
                "Nhân viên kho"
            };
            cbb_Role.Items.Clear();
            cbb_Role.DataSource = roles;

            if (employee != null)
            {
                tb_EmployeeName.Text = employee.Name;
                tb_PhoneNumber.Text = employee.PhoneNumber;
                rtb_Address.Text = employee.Address;
                tb_Username.Text = employee.Username;
                // tb_Password.Text = employee.Password; // Không hiển thị mật khẩu
                cbb_Role.Text = employee.Role;
            }
        }

        private bool isValidateEmployeeInput()
        {
            if (string.IsNullOrEmpty(tb_EmployeeName.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(tb_PhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_PhoneNumber.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số điện thoại không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(tb_Username.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(tb_Password.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tb_Password.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_Password.Text, @".*[A-Z].*"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một ký tự viết hoa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_Password.Text, @".*[a-z].*"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một ký tự viết thường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_Password.Text, @".*[0-9].*"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cbb_Role.Text))
            {
                MessageBox.Show("Vai trò không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(!isValidateEmployeeInput()){
                return;
            }

            Models.Employee addedEmployee = new Models.Employee()
            {
                Name = tb_EmployeeName.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Address = rtb_Address.Text,
                Username = tb_Username.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(tb_Password.Text),
                Role = cbb_Role.Text
            };

            if(employee != null){
                addedEmployee.ID = employee.ID;
            }

            this.Tag = addedEmployee;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
