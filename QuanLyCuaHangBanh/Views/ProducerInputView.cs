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
    public partial class ProducerInputView : Form
    {
        private Producer? _producer;
        public ProducerInputView(Producer? producer = null)
        {
            InitializeComponent();

            _producer = producer;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Producer producer = new Producer
            {
                Name = tb_ProducerName.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Email = tb_Email.Text,
                Address = mttb_Address.Text,
                Description = mttb_Description.Text,
            };

            this.Tag = (producer);

            this.DialogResult = DialogResult.OK;
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
            }
        }
    }
}
