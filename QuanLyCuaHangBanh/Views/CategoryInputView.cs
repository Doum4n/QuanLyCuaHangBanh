using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    public partial class CategoryInputView : Form
    {
        private Category? _category;
        public CategoryInputView(Category? category = null)
        {
            InitializeComponent();

            this._category = category;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.Tag = (tb_Name.Text, mttb_Description.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void mttb_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }

        private void CategoryInputView_Load(object sender, EventArgs e)
        {
            if (_category != null)
            {
                tb_Name.Text = _category.Name;
                mttb_Description.Text = _category.Description;
            }
        }
    }
}
