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
    public partial class CustomerInputView : Form
    {

        private Models.Customer? customer;

        public CustomerInputView(Models.Customer? customer = null)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void CustomerInputView_Load(object sender, EventArgs e)
        {

            List<string> types =
            [
                "Khách hàng thường",// Regular customer
                "Khách hàng VIP", // VIP customer
                "Khách hàng thân thiết", // Loyal customer
                "Khách hàng mới", // New customer
                "Khách hàng doanh nghiệp" // Corporate customer
            ];

            cbb_CustomerTypes.DataSource = types;

            if (customer != null)
            {
                tb_CustomerName.Text = customer.Name;
                tb_PhoneNumer.Text = customer.PhoneNumber;
                mttb_Address.Text = customer.Address;
                cbb_CustomerTypes.Text = customer.Type;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_CustomerName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(System.Text.RegularExpressions.Regex.IsMatch(tb_PhoneNumer.Text, @"^\d+$")){
                MessageBox.Show("Số điện thoại không được chứa ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(tb_PhoneNumer.Text.Length != 10){
                MessageBox.Show("Số điện thoại phải có 10 số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(mttb_Address.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(cbb_CustomerTypes.Text))
            {
                MessageBox.Show("Loại khách hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void mttb_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }
    }
}
