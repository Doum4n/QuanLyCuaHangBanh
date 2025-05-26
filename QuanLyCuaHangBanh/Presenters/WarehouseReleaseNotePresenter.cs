// QuanLyCuaHangBanh.Presenters/WarehouseReleaseNotePresenter.cs
using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views.ReleaseNote;
using System.Data;
using QuanLyCuaHangBanh.Data;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Services; // Add this namespace

namespace QuanLyCuaHangBanh.Presenters
{
    public class WarehouseReleaseNotePresenter : PresenterBase<WarehouseReleaseNote> // Change generic type to Model
    {
        // Declare the service as a readonly field

        // The QLCHB_DBContext context field is removed as it's now injected into the service.
        // private QLCHB_DBContext context = new QLCHB_DBContext(); // REMOVED

        private ProductReleaseDTO productReleaseDTO; // Retaining this as it was in original code

        // Update the constructor to accept the new service via DI
        public WarehouseReleaseNotePresenter(IWareHouseReleaseNoteView view, WarehouseReleaseNoteService service)
            : base(view, service) // Pass view and provider to the base class
        {
            // Initialize BindingSource here to prevent NullReferenceException
            BindingSource = new BindingSource();
        }

        public override void LoadData()
        {
            // Use the service to get data
            BindingSource.DataSource = ((WarehouseReleaseNoteService)Service).GetAllReleaseNotesAsDto();
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            // Get data from service
            (DataTable releaseNoteDt, DataTable releaseNoteDetailDt) = ((WarehouseReleaseNoteService)Service).GetReleaseNoteDataTablesForExport((IList<object>)BindingSource.List);

            // Use ExcelHandler (assuming it's a static utility or injected)
            ExcelHandler.ExportExcel("Phiếu xuất", "Phiếu xuất", "Chi tiết phiếu xuất", releaseNoteDt, releaseNoteDetailDt);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            // Pass service methods as callbacks to ExcelHandler
            ExcelHandler.ImportExcel(
                ((WarehouseReleaseNoteService)Service).ImportReleaseNote,
                ((WarehouseReleaseNoteService)Service).ImportReleaseNoteDetail
            );
        }

        // ImportReleaseNote and ImportReleaseNoteDetail methods are now in the service.
        // private void ImportReleaseNote(DataRow row) { ... } // REMOVED
        // private void ImportReleaseNoteDetail(DataRow row) { ... } // REMOVED


        public override void OnAddNew(object? sender, EventArgs e)
        {
            ReleaseNoteInputView inputView = new ReleaseNoteInputView();

            // Keep event subscriptions as they are for UI interaction
            inputView.AddProductEvent += (productReleaseDTO) =>
            {
                inputView.AddProduct(productReleaseDTO);
            };

            inputView.ShowSelectGoodsReciveNoteForm += (s, e) => ShowSelectGoodsReciveNoteForm(inputView);
            inputView.ShowSelectOrderForm += (s, e) => ShowSelectOrderForm(inputView);

            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is WarehouseReleaseNote warehouseReleaseNote)
                {
                    // Use the service to add the new release note and its details
                    ((WarehouseReleaseNoteService)Service).AddNewReleaseNote(warehouseReleaseNote, inputView.Products);

                    View.Message = "Thêm phiếu xuất thành công!";
                    LoadData(); // Reload data after add
                }
            }
        }

        private int ShowSelectOrderForm(ReleaseNoteInputView inputView)
        {
            SelectOrderView selectOrderForm = new SelectOrderView();
            if (selectOrderForm.ShowDialog() == DialogResult.OK)
            {
                if (selectOrderForm.Tag is int orderId)
                {
                    // Use the service to get order details
                    var order = ((WarehouseReleaseNoteService)Service).GetOrderDetails(orderId);
                    if (order != null)
                    {
                        foreach (var item in order)
                        {
                            foreach (var unit in item.Product_Unit.Product.ProductUnits) // This might need careful review if ProductUnits is always loaded
                            {
                                var product = new ProductReleaseDTO(
                                    item.Product_Unit.Product.ID,
                                    item.Product_Unit.Product.Name,
                                    item.Product_Unit.Product.CategoryID,
                                    item.Product_Unit.Product.Category.Name,
                                    unit.Unit.Name,
                                    item.Product_UnitID,
                                    item.Product_Unit.ConversionRate,
                                    item.Quantity,
                                    item.Note
                                );
                                inputView.RaiseAddProductEvent(product);
                            }
                        }
                    }
                    MessageBox.Show(orderId.ToString());
                    return orderId;
                }
            }
            return 0;
        }

        private int ShowSelectGoodsReciveNoteForm(ReleaseNoteInputView inputView)
        {
            SelectReceiptNoteView selectGoodsReciveNoteForm = new SelectReceiptNoteView();
            if (selectGoodsReciveNoteForm.ShowDialog() == DialogResult.OK)
            {
                if (selectGoodsReciveNoteForm.Tag is int goodsReceiptNoteId)
                {
                    // Use the service to get goods receipt note details
                    var goodsReceiptNote = ((WarehouseReleaseNoteService)Service).GetGoodsReceiptNoteDetails(goodsReceiptNoteId);
                    if (goodsReceiptNote != null)
                    {
                        foreach (var item in goodsReceiptNote)
                        {
                            // Original code had commented out foreach (var unit in item.ProductUnit),
                            // retaining the direct access logic to item.Product.ID, etc.
                            // Ensure 'item.Product' and 'item.Unit' are loaded (e.g., via Include in service)
                            var product = new ProductReleaseDTO(
                                item.Product.ID,
                                item.Product.Name,
                                item.Product.CategoryID,
                                item.Product.Category.Name,
                                item.Unit.Name, // Direct access to item.Unit.Name, assuming it's loaded
                                item.ProductUnitId,
                                item.ProductUnit.ConversionRate,
                                item.Quantity,
                                item.Note
                            );

                            MessageBox.Show(product.ProductUnitId.ToString());

                            inputView.RaiseAddProductEvent(product);
                        }
                    }
                    MessageBox.Show(goodsReceiptNoteId.ToString());
                    return goodsReceiptNoteId;
                }
            }
            return 0;
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is WarehouseReleaseNoteDTO selectedItem)
            {
                // Use the service to delete the release note
                ((WarehouseReleaseNoteService)Service).DeleteReleaseNote(selectedItem.ID);
                View.Message = "Xóa phiếu xuất thành công!";
                LoadData(); // Reload data after delete
            }
            else
            {
                View.Message = "Vui lòng chọn phiếu xuất để xóa!";
            }
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            // Ensure View.SelectedItem is handled safely if it could be null or wrong type
            if (View.SelectedItem is not WarehouseReleaseNoteDTO selectedReleaseNoteDto)
            {
                View.Message = "Vui lòng chọn phiếu xuất để chỉnh sửa!";
                return;
            }

            ReleaseNoteInputView inputView = new ReleaseNoteInputView(selectedReleaseNoteDto);

            inputView.AddProductEvent += (productReleaseDTO) =>
            {
                inputView.AddProduct(productReleaseDTO);
            };

            inputView.ShowSelectGoodsReciveNoteForm += (s, e) => ShowSelectGoodsReciveNoteForm(inputView);
            inputView.ShowSelectOrderForm += (s, e) => ShowSelectOrderForm(inputView); // Added missing event subscription

            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is WarehouseReleaseNote warehouseReleaseNote)
                {
                    // Use the service to update the release note and its details
                    ((WarehouseReleaseNoteService)Service).UpdateReleaseNote(warehouseReleaseNote, inputView.Products);

                    View.Message = "Cập nhật phiếu xuất thành công!";
                    LoadData(); // Reload data after update
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}