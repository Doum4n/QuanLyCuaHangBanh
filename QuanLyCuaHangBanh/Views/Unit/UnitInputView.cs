using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Views.Unit
{
    public partial class UnitInputView : Form
    {
        private Models.Unit? Unit;
        public UnitInputView(Models.Unit unit = null)
        {
            InitializeComponent();
            Unit = unit;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Unit unit = new Models.Unit
            {
                Name = tb_Name.Text.Trim(),
                Description = rtb_Description.Text.Trim()
            };

            if (Unit != null)
            {
                unit.ID = Unit.ID; // Preserve the ID if editing an existing unit
            }

            this.Tag = unit;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UnitInputView_Load(object sender, EventArgs e)
        {
            if(Unit != null)
            {
                tb_Name.Text = Unit.Name;
                rtb_Description.Text = Unit.Description;
            }
            else
            {
                tb_Name.Text = string.Empty;
                rtb_Description.Text = string.Empty;
            }
        }
    }
}
