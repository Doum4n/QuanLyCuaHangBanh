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
            if (customer != null)
            {
                tb_CustomerName.Text = customer.Name;
                tb_PhoneNumer.Text = customer.PhoneNumber;
                mttb_Address.Text = customer.Address;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Customer customer = new Models.Customer
            {
                Name = tb_CustomerName.Text,
                PhoneNumber = tb_PhoneNumer.Text,
                Address = mttb_Address.Text
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
