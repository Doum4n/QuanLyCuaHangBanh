using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.Data;

namespace QuanLyCuaHangBanh.Views
{
    public partial class SelectReceiptNoteView : Form
    {
        private QLCHB_DBContext? context = new QLCHB_DBContext();
        private int selectedGoodsReceiptNoteId = 0;
        public SelectReceiptNoteView()
        {
            InitializeComponent();
        }

        private void SelectGoodsReceiptNoteView_Load(object sender, EventArgs e)
        {
            dgv_GoodsReceiptNote.EditMode = DataGridViewEditMode.EditOnEnter;

            dgv_GoodsReceiptNote.DataSource = context.GoodsReceiptNotes
                .Include(o => o.Supplier)
                .Include(o => o.GoodsReceiptNoteDetails)
                .Select(
                    o => new GoodsReceiptNoteDTO(
                        o.ID,
                        o.SupplierId,
                        o.Supplier.Name,
                        o.CreatedDate,
                        o.Status,
                        o.Note,
                        o.GoodsReceiptNoteDetails.Select(g => g.Product).ToList()
                    )
                ).ToList();

            foreach (DataGridViewRow row in dgv_GoodsReceiptNote.Rows)
            {
                var goodsReceiptNote = row.DataBoundItem as GoodsReceiptNoteDTO;
                if (goodsReceiptNote != null)
                {
                    row.Cells["Select"].ReadOnly = false;
                }
            }
        }

        private void dgv_GoodsReceiptNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgv_GoodsReceiptNote.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool currentValue = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !currentValue;


                if ((bool)checkBoxCell.Value)
                {

                    selectedGoodsReceiptNoteId = Convert.ToInt32(dgv_GoodsReceiptNote.Rows[e.RowIndex].Cells[2].Value);
                    
                    // Uncheck all other checkboxes in the same column
                    foreach (DataGridViewRow row in dgv_GoodsReceiptNote.Rows)
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
                    selectedGoodsReceiptNoteId = 0;
                }
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (selectedGoodsReceiptNoteId == 0)
            {
                MessageBox.Show("Please select a Goods Receipt Note.");
                return;
            }else
            {
                this.Tag = selectedGoodsReceiptNoteId;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
