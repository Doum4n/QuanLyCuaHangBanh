using Microsoft.EntityFrameworkCore.Query;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangBanh.DTO;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int ProducerId { get; set; }
    public string ProducerName { get; set; }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public List<UnitDTO> Units { get; set; } // Giữ nguyên kiểu List<UnitDTO>
    public decimal UnitPrice { get; set; }
    public int InventoryId { get; set; }
    public int Quantity { get; set; }
    public int TotalQuantity { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string ViewDetail { get; set; } // Giả định đây là một string hiển thị "Xem chi tiết"

    // Constructor mặc định cần thiết cho một số cơ chế binding
    public ProductDTO() { }

    // Constructor chính để ánh xạ từ một Product và các dữ liệu liên quan
    // Chúng ta sẽ dùng Constructor này trong LINQ Select.
    public ProductDTO(
        int id,
        string name,
        int categoryId,
        string categoryName,
        int producerId,
        string producerName,
        int manufacturerId,
        string manufacturerName,
        IEnumerable<Product_Unit> productUnits, // Nhận IEnumerable<ProductUnit> (có thể là ICollection)
        string description,
        string imagePath
    // "Xem chi tiết" là một giá trị cố định, không cần truyền vào
    )
    {
        ProductId = id;
        ProductName = name;
        CategoryId = categoryId;
        CategoryName = categoryName;
        ProducerId = producerId;
        ProducerName = producerName;
        ManufacturerId = manufacturerId;
        ManufacturerName = manufacturerName;
        Description = description;
        ImagePath = imagePath;
        ViewDetail = "Xem chi tiết"; // Gán giá trị cố định

        // Ánh xạ ProductUnits sang UnitDTOs và tính toán các giá trị liên quan
        Units = productUnits?.GroupBy(pu => pu.Unit.Name)
                            .Where(pu => pu.First().Unit != null)
                            .Select(pu => new UnitDTO(pu.First().Unit.ID, pu.First().Unit.Name, pu.First().ID, false)) // Giả định ProductUnit
                            .ToList() ?? new List<UnitDTO>();

        // Lấy thông tin đơn vị được chọn hoặc đơn vị đầu tiên
        var selectedPu = productUnits?.FirstOrDefault( pu => Units.Where(o => o.IsSelected).Any( unit => pu.UnitID == unit.ID));
        if (selectedPu == null)
        {
            selectedPu = productUnits?.FirstOrDefault(); // Nếu không có cái nào IsSelected, chọn cái đầu tiên
        }

        UnitPrice = selectedPu?.UnitPrice ?? 0;
        InventoryId = selectedPu?.Inventory?.ID ?? 0;
        Quantity = selectedPu?.Inventory?.Quantity ?? 0;
        TotalQuantity = productUnits?.Sum(pu => pu.Inventory?.Quantity ?? 0) ?? 0;
    }

    // Bổ sung phương thức MatchesSearch nếu chưa có
    public bool MatchesSearch(string searchValue)
    {
        return ProductName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
               CategoryName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
               Description.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
               (Units != null && Units.Any(u => u.UnitName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)));
    }
}
