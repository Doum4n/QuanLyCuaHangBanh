using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.Data;

namespace QuanLyCuaHangBanh.Views.ReleaseNote
{
    public partial class SelectOrderView : Form
    {

        private QLCHB_DBContext? context = new QLCHB_DBContext();
        private int selectedOrderId = 0;

        public SelectOrderView()
        {
            InitializeComponent();
        }

        private void SelectOrderView_Load(object sender, EventArgs e)
        {
            dgv_OrderList.EditMode = DataGridViewEditMode.EditOnEnter;

            dgv_OrderList.DataSource = context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .Select(
                    o => new OrderDTO
                    (
                        o.ID,
                        o.Customer.Name,
                        o.Customer.PhoneNumber,
                        o.OrderDate,
                        o.OrderDetails.Sum(od => od.Price * od.Quantity),
                        o.Status,
                        o.PaymentMethod,
                        o.DeliveryAddress
                    )).ToList();

            foreach (DataGridViewRow row in dgv_OrderList.Rows)
            {
                if (row.DataBoundItem is OrderDTO orderDTO)
                {
                    row.Cells["Select"].ReadOnly = false;
                }
            }
        }

        private void dgv_OrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgv_OrderList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool currentValue = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !currentValue;


                if ((bool)checkBoxCell.Value)
                {

                    selectedOrderId = Convert.ToInt32(dgv_OrderList.Rows[e.RowIndex].Cells[2].Value);

                    // Uncheck all other checkboxes in the same column
                    foreach (DataGridViewRow row in dgv_OrderList.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell otherCheckBoxCell = (DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex];
                            otherCheckBoxCell.Value = false;
                        }
                    }
                }
                else
                {
                    selectedOrderId = 0;
                }
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            this.Tag = selectedOrderId;
            if (selectedOrderId == 0)
            {
                MessageBox.Show("Please select an Order.");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
