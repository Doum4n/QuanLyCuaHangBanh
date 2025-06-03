using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Utils
{
    public static class DataGridView
    {
        /// <summary>
        /// Lấy màu tương ứng với trạng thái sản phẩm
        /// </summary>
        /// <param name="status">Trạng thái sản phẩm</param>
        /// <returns>Màu tương ứng</returns>
        public static Color GetStatusColor(QuanLyCuaHangBanh.DTO.Base.Status status)
        {
            return status switch
            {
                QuanLyCuaHangBanh.DTO.Base.Status.New => Color.LightGreen,
                QuanLyCuaHangBanh.DTO.Base.Status.Modified => Color.LightYellow,
                QuanLyCuaHangBanh.DTO.Base.Status.Deleted => Color.LightPink,
                _ => Color.White
            };
        }

        public static void HideColumn(System.Windows.Forms.DataGridView dgv, string[] columnsToHide)
        {
            foreach (var columnName in columnsToHide)
            {
                if (dgv.Columns[columnName] != null)
                {
                    dgv.Columns[columnName].Visible = false;
                }
            }
        }
    }
}
