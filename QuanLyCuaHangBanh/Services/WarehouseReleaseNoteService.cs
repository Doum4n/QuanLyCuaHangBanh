// QuanLyCuaHangBanh.Services/WarehouseReleaseNoteService.cs
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base; // Assuming Status is defined here
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel; // For BindingList
using System.Data; // For DataTable
using System.Linq;
using QuanLyCuaHangBanh.Base;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    public class WarehouseReleaseNoteService(IRepositoryProvider repositoryProvider, QLCHB_DBContext context)
        : IService
    {
        // For direct EF Core operations like Includes

        public async Task<IList<WarehouseReleaseNoteDTO>> GetAllReleaseNotesAsDto()
        {
            // Direct transfer of logic from LoadData
            return await repositoryProvider.GetRepository<WarehouseReleaseNote>().GetAllAsDto<WarehouseReleaseNoteDTO>(
                o => new WarehouseReleaseNoteDTO {
                    ID = o.ID,
                    CreatedBy = o.CreatedBy.Name,
                    CreatedDate = o.CreatedDate,
                    Status = o.Status,
                    Note = o.Note
                }
            );
        }

        public (DataTable releaseNoteDt, DataTable releaseNoteDetailDt) GetReleaseNoteDataTablesForExport(IList<object> bindingSourceList)
        {
            // Direct transfer of logic from OnExport
            DataTable releaseNoteDt = new DataTable();
            releaseNoteDt.Columns.Add("Mã phiếu xuất", typeof(int));
            releaseNoteDt.Columns.Add("Nhân viên lập", typeof(string));
            releaseNoteDt.Columns.Add("Ngày lập", typeof(string));
            releaseNoteDt.Columns.Add("Trạng thái", typeof(string));
            releaseNoteDt.Columns.Add("Ghi chú", typeof(string));

            DataTable releaseNoteDetailDt = new DataTable();
            releaseNoteDetailDt.Columns.Add("Mã phiếu xuất", typeof(string));
            releaseNoteDetailDt.Columns.Add("Mã sản phẩm", typeof(string));
            releaseNoteDetailDt.Columns.Add("Tên sản phẩm", typeof(string));
            releaseNoteDetailDt.Columns.Add("Mã nhà cung cấp", typeof(string)); // This column seems inconsistent with CategoryID/Name in DTO
            releaseNoteDetailDt.Columns.Add("Tên nhà cung cấp", typeof(string)); // This column seems inconsistent with CategoryID/Name in DTO
            releaseNoteDetailDt.Columns.Add("Mã ĐVT", typeof(string));
            releaseNoteDetailDt.Columns.Add("Tên ĐVT", typeof(string));
            releaseNoteDetailDt.Columns.Add("Số lượng", typeof(string));

            foreach (var item in bindingSourceList)
            {
                if (item is WarehouseReleaseNoteDTO dTO)
                {
                    var releaseNotes = context.WarehouseReleaseNotes
                        .Include(o => o.CreatedBy)
                        .Where(o => o.ID == dTO.ID)
                        .ToList();

                    foreach (var note in releaseNotes)
                    {
                        releaseNoteDt.Rows.Add(
                            note.ID,
                            note.CreatedBy?.Name ?? "",
                            note.CreatedDate.ToString(),
                            note.Status,
                            note.Note
                        );
                    }

                    var releaseNoteDetails = context.WarehouseReleaseNoteDetails
                        .Include(o => o.Product_Unit)
                            .ThenInclude(o => o.Product)
                                .ThenInclude(o => o.Category)
                        .Include(o => o.Product_Unit)
                            .ThenInclude(o => o.Unit)
                        .Where(o => o.WarehouseReleaseNoteId == dTO.ID)
                        .ToList();

                    foreach (var detail in releaseNoteDetails)
                    {
                        releaseNoteDetailDt.Rows.Add(
                            detail.WarehouseReleaseNoteId,
                            detail.Product_Unit.Product.ID,
                            detail.Product_Unit.Product.Name,
                            detail.Product_Unit.Product.CategoryID, // This is CategoryID
                            detail.Product_Unit.Product.Category.Name, // This is Category Name, not Supplier/Producer
                            detail.Product_Unit.UnitID,
                            detail.Product_Unit.Unit.Name,
                            detail.Quantity
                        );
                    }
                }
            }
            return (releaseNoteDt, releaseNoteDetailDt);
        }

        public void ImportReleaseNote(DataRow row)
        {
            // Direct transfer of logic from ImportReleaseNote
            WarehouseReleaseNote warehouseReleaseNote = new WarehouseReleaseNote()
            {
                ID = int.Parse(row["Mã phiếu xuất"].ToString()),
                CreatedDate = DateOnly.Parse(row["Ngày lập"].ToString()),
                CreatedByID = int.Parse(row["Nhân viên lập"].ToString()),
                Note = row["Ghi chú"].ToString(),
                Status = row["Trạng thái"].ToString()
            };

            repositoryProvider.GetRepository<WarehouseReleaseNote>().Add(warehouseReleaseNote);
        }

        public void ImportReleaseNoteDetail(DataRow row)
        {
            // Direct transfer of logic from ImportReleaseNoteDetail
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            // This requires casting to a specific repository type, which is generally
            // an indication that IRepositoryProvider might need a method for this,
            // or the specific repository should be injected directly.
            // For now, retaining the original logic.
            var productUnitId = ((ProductUnitRepo)repositoryProvider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            WarehouseReleaseNote_Detail warehouseReleaseNote_Detail = new WarehouseReleaseNote_Detail()
            {
                Product_UnitID = productUnitId,
                Quantity = int.Parse(row["Số lượng"].ToString()),
                Note = "",
                WarehouseReleaseNoteId = int.Parse(row["Mã phiếu xuất"].ToString())
            };

            repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>().Add(warehouseReleaseNote_Detail);
        }

        public void AddNewReleaseNote(WarehouseReleaseNote warehouseReleaseNote, BindingList<ProductReleaseDTO> products)
        {
            repositoryProvider.GetRepository<WarehouseReleaseNote>().Add(warehouseReleaseNote);

            foreach (var item in products)
            {
                // Assign the newly generated ID from the added WarehouseReleaseNote
                item.ID = 0; // Set ID to 0 to avoid foreign key constraint errors
                item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>().Add(item.ToWarehouseReleaseNoteDetail());
            }
        }

        public void UpdateReleaseNote(WarehouseReleaseNote warehouseReleaseNote, BindingList<ProductReleaseDTO> products)
        {
            repositoryProvider.GetRepository<WarehouseReleaseNote>().Update(warehouseReleaseNote);

            foreach (var item in products)
            {
                switch (item.Status)
                {
                    case Status.New:
                        item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                        repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>().Add(item.ToWarehouseReleaseNoteDetail());
                        break;
                    case Status.Modified:
                        // Ensure the ID is correctly mapped for updating an existing entity
                        item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                        repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>().Update(item.ToWarehouseReleaseNoteDetail());
                        break;
                    case Status.Deleted:
                        ((WarehouseReleaseNoteDetailRepo)repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>()).DeleteByID(item.ID);
                        break;
                    case Status.None:
                        break;
                }
            }
        }

        public async Task DeleteReleaseNote(int releaseNoteId)
        {
            // Delete details first to avoid foreign key constraint errors
            var detailsToDelete = context.WarehouseReleaseNoteDetails
                                          .Where(d => d.WarehouseReleaseNoteId == releaseNoteId)
                                          .ToList();
            foreach (var detail in detailsToDelete)
            {
                repositoryProvider.GetRepository<WarehouseReleaseNote_Detail>().Delete(detail);
            }

            // Then delete the main note
            var warehouseReleaseNote = await repositoryProvider.GetRepository<WarehouseReleaseNote>().GetByValue(releaseNoteId);
            if (warehouseReleaseNote != null)
            {
                repositoryProvider.GetRepository<WarehouseReleaseNote>().Delete(warehouseReleaseNote);
            }
        }

        public IEnumerable<Order_Detail> GetOrderDetails(int orderId)
        {
            // Preserving the specific repository cast from your original code
            return ((OrderDetailRepo)repositoryProvider.GetRepository<Order_Detail>()).GetOrderDetail(orderId);
        }

        public IEnumerable<GoodsReceiptNote_Detail> GetGoodsReceiptNoteDetails(int goodsReceiptNoteId)
        {
            // Preserving the specific repository cast from your original code
            return ((GoodsReceiptNoteDetailRepo)repositoryProvider.GetRepository<GoodsReceiptNote_Detail>()).GetReceiptNote_Details(goodsReceiptNoteId);
        }
    }
}