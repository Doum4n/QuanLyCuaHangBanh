using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Uitls
{
    public class ExcelHandler
    {
        public static void ImportExcel(Action<DataRow> ImportHanler)
        {
            // Implement the logic to import data from Excel file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "";
                        DataTable table = new DataTable();

                        #region Đọc Sheet 1 và lưu dữ liệu vào một bảng tạm
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            // Đọc dòng tiêu đề (dòng đầu tiên)
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else // Đọc các dòng nội dung (các dòng tiếp theo)
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        #endregion

                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                ImportHanler.Invoke(r);
                            }
                        }
                        else
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        public static void ExportExcel(string fileName, string sheetName, DataTable dataTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = $"{fileName}_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(dataTable, sheetName);
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public static void ImportExcel(Action<DataRow> ImportInvoiceHanler, Action<DataRow> ImportInvoiceDetail)
        {
            // Implement the logic to import data from Excel file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        #region Xử lý sheet Hóa đơn (Sheet 1)
                        IXLWorksheet sheet1 = workbook.Worksheet(1);
                        bool firstRowHoaDon = true;
                        string readRangeHoaDon = "";
                        DataTable dataTable = new DataTable();
                        // Đọc Sheet 1 và lưu dữ liệu vào một bảng tạm
                        foreach (IXLRow row in sheet1.RowsUsed())
                        {
                            // Đọc dòng tiêu đề (dòng đầu tiên)
                            if (firstRowHoaDon)
                            {
                                readRangeHoaDon = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRangeHoaDon))
                                    dataTable.Columns.Add(cell.Value.ToString());
                                firstRowHoaDon = false;
                            }
                            else // Đọc các dòng nội dung
                            {
                                DataRow newRow = dataTable.NewRow();
                                int cellIndex = 0;
                                int excelCol = 1;

                                try
                                {
                                    foreach (IXLCell cell in row.Cells(readRangeHoaDon))
                                    {
                                        newRow[cellIndex] = cell.Value.ToString();
                                        cellIndex++;
                                        excelCol++;
                                    }
                                    dataTable.Rows.Add(newRow);
                                }
                                catch (Exception ex)
                                {
                                    int excelRow = row.RowNumber();
                                    MessageBox.Show($"Lỗi khi xử lý sheet 'Hóa đơn' - dòng {excelRow}, cột {excelCol}.\nChi tiết: {ex.Message}",
                                        "Lỗi nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                        }
                        // Đọc dữ liệu từ bảng tạm và lưu vào CSDL
                        // Đọc dữ liệu từ bảng tạm và lưu vào CSDL
                        if (dataTable.Rows.Count > 0)
                        {
                            int excelRow = 2; // bắt đầu từ dòng thứ 2 vì dòng 1 là tiêu đề
                            foreach (DataRow r in dataTable.Rows)
                            {
                                try
                                {
                                    ImportInvoiceHanler.Invoke(r);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Lỗi khi xử lý sheet 'Hóa đơn' tại dòng Excel số {excelRow}: {ex.Message}",
                                        "Lỗi nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                excelRow++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        #endregion

                        #region Xử lý sheet Chi tiết hóa đơn (Sheet 2)
                        IXLWorksheet sheet2 = workbook.Worksheet(2);
                        bool firstRowChiTietHoaDon = true;
                        string readRangeChiTietHoaDon = "";
                        DataTable dataTableChiTietHoaDon = new DataTable();
                        // Đọc Sheet 2 và lưu dữ liệu vào một bảng tạm
                        foreach (IXLRow row in sheet2.RowsUsed())
                        {
                            // Đọc dòng tiêu đề (dòng đầu tiên)
                            if (firstRowChiTietHoaDon)
                            {
                                readRangeChiTietHoaDon = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRangeChiTietHoaDon))
                                    dataTableChiTietHoaDon.Columns.Add(cell.Value.ToString());
                                firstRowChiTietHoaDon = false;
                            }
                            else // Đọc các dòng nội dung
                            {
                                DataRow newRow = dataTableChiTietHoaDon.NewRow();
                                int cellIndex = 0;
                                int excelCol = 1;

                                try
                                {
                                    foreach (IXLCell cell in row.Cells(readRangeChiTietHoaDon))
                                    {
                                        newRow[cellIndex] = cell.Value.ToString();
                                        cellIndex++;
                                        excelCol++;
                                    }
                                    dataTableChiTietHoaDon.Rows.Add(newRow);
                                }
                                catch (Exception ex)
                                {
                                    int excelRow = row.RowNumber();
                                    MessageBox.Show($"Lỗi khi xử lý sheet 'Chi tiết hóa đơn' - dòng {excelRow}, cột {excelCol}.\nChi tiết: {ex.Message}",
                                        "Lỗi nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                        }

                        // Đọc dữ liệu từ bảng tạm và lưu vào CSDL
                        // Đọc dữ liệu từ bảng tạm và lưu vào CSDL
                        if (dataTableChiTietHoaDon.Rows.Count > 0)
                        {
                            int excelRow = 2; // bắt đầu từ dòng thứ 2
                            foreach (DataRow r in dataTableChiTietHoaDon.Rows)
                            {
                                try
                                {
                                    ImportInvoiceDetail.Invoke(r);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Lỗi khi xử lý sheet 'Chi tiết hóa đơn' tại dòng Excel số {excelRow}: {ex.Message}",
                                                    "Lỗi nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                excelRow++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public static void ExportExcel(string fileName, string sheetName1,string sheetName2, DataTable dataTable, DataTable dataTableDetail)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = $"{fileName}_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet1 = wb.Worksheets.Add(dataTable, sheetName1);
                        sheet1.Columns().AdjustToContents();
                        var sheet2 = wb.Worksheets.Add(dataTableDetail, sheetName2);
                        sheet2.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
