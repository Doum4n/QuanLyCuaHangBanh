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

namespace QuanLyCuaHangBanh.Views.Employee
{
    public partial class EmployeeInputView : Form
    {
        private Models.Employee? employee;
        public EmployeeInputView(Models.Employee? employee = null)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void EmployeeInputView_Load(object sender, EventArgs e)
        {

            List<string> roles = new List<string>()
            {
                "Admin",
                "Sales",
                "WarehouseStaff"
            };
            cbb_Role.Items.Clear();
            cbb_Role.DataSource = roles;


            if (employee != null)
            {
                tb_EmployeeName.Text = employee.Name;
                tb_PhoneNumber.Text = employee.PhoneNumber;
                rtb_Address.Text = employee.Address;
                tb_Username.Text = employee.Username;
                tb_Password.Text = employee.Password;
                cbb_Role.Text = employee.Role;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Employee addedEmployee = new Models.Employee()
            {
                Name = tb_EmployeeName.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Address = rtb_Address.Text,
                Username = tb_Username.Text,
                Password = BCrypt.Net.BCrypt.HashPassword(tb_Password.Text),
                Role = cbb_Role.Text
            };

            this.Tag = addedEmployee;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
