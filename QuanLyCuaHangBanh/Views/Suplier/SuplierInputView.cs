using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    public partial class SuplierInputView : Form
    {
        private SupplierDTO? _producer;
        public SuplierInputView(SupplierDTO? producer = null)
        {
            InitializeComponent();

            _producer = producer;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateSupplierInput())
            {
                return;
            }

            Supplier producer = new Supplier
            {
                Name = tb_ProducerName.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Email = tb_Email.Text,
                Address = mttb_Address.Text,
                Description = mttb_Description.Text,
                Limit = nmr_Limit.Value,
                CreditPeriod = (int)nmr_CreditPeriod.Value
            };


            this.Tag = (producer);

            this.DialogResult = DialogResult.OK;
        }

        private bool ValidateSupplierInput()
        {
            if (string.IsNullOrEmpty(tb_ProducerName.Text))
            {
                MessageBox.Show("Tên nhà sản xuất không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(tb_PhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(tb_Email.Text))
            {
                MessageBox.Show("Email không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_Email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(mttb_Address.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (nmr_Limit.Value <= 0)
            {
                MessageBox.Show("Giới hạn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
            
        private void mttb_Note_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }

        private void ProducerInputView_Load(object sender, EventArgs e)
        {
            if (_producer != null)
            {
                tb_ProducerName.Text = _producer.Name;
                tb_PhoneNumber.Text = _producer.PhoneNumber;
                tb_Email.Text = _producer.Email;
                mttb_Address.Text = _producer.Address;
                mttb_Description.Text = _producer.Description;
                nmr_Limit.Value = _producer.Limit;
            }
        }
    }
}
