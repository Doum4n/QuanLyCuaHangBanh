using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Uitls
{
    public static class ColumnCheckBox
    {
        public static void UncheckOtherCheckBoxes(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (i != e.RowIndex)
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgv.Rows[i].Cells[e.ColumnIndex];
                    checkBoxCell.Value = false;
                }
            }
        }
    }
}
