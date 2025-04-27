using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Helpers
{
    public static class MessageBoxHelper
    {
        public static bool ConfirmDelete(string itemName)
        {
            var msg = MessageBox.Show(
                $"Bạn có muốn xóa {itemName}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return msg == DialogResult.Yes;
        }
    }
}
