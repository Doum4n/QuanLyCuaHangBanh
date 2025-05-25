using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Views.Manufacturer
{
    public partial class IManufacturerInputView : Form
    {
        private Models.Manufacturer? _manufacturer;
        public IManufacturerInputView(Models.Manufacturer? manufacturer = null)
        {
            InitializeComponent();
            _manufacturer = manufacturer;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Manufacturer manufacturer = new Models.Manufacturer
            {
                Name = tb_Name.Text.Trim(),
                Description = rtb_Description.Text.Trim()
            };

            if (_manufacturer != null)
            {
                manufacturer.ID = _manufacturer.ID; // Preserve ID if editing existing manufacturer
            }

            this.Tag = manufacturer;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IManufacturerInputView_Load(object sender, EventArgs e)
        {
            if (_manufacturer != null)
            {
                tb_Name.Text = _manufacturer.Name;
                rtb_Description.Text = _manufacturer.Description;
            }
        }

        private void rtb_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.PerformClick(); // Trigger the save button click event
            }
        }
    }
}
