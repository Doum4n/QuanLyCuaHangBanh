using Microsoft.EntityFrameworkCore.Query;
using QuanLyCuaHangBanh.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangBanh.DTO;

public class ProductDTO : ISearchable // Triển khai ISearchable
{
    // Các thuộc tính Public của DTO
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public int ProducerId { get; set; } // Giữ lại nếu cần cho backend, nhưng có thể ẩn trên UI
    public string ProducerName { get; set; }
    public int ManufactureId { get; set; } // Giữ lại nếu cần cho backend, nhưng có thể ẩn trên UI
    public string ManufactureName { get; set; }

    // Thuộc tính List<UnitDTO> (tập hợp các đơn vị tính của sản phẩm này)
    // Sẽ được ẩn trên PropertyGrid
    [Browsable(false)]
    public List<UnitDTO> Units { get; set; } = new List<UnitDTO>(); // Đổi tên thành Units cho rõ ràng hơn

    // Giá và số lượng hiển thị (có thể là giá/số lượng của đơn vị tính mặc định)
    // Nếu bạn muốn hiển thị giá/số lượng của ĐVT cụ thể trên UI, hãy xem xét lại cách lấy dữ liệu vào DTO này.
    public decimal Price { get; set; } // Giá của sản phẩm (theo đơn vị mặc định/chính)
    public int Quantity { get; set; } // Số lượng (tồn kho) theo đơn vị mặc định/chính

    // Các thuộc tính khác
    public int InventoryId { get; set; } // ID của bản ghi tồn kho tương ứng, có thể ẩn
    public int TotalQuantity { get; set; } // Tổng số lượng tồn kho (có thể quy đổi về đơn vị cơ bản)
    public string Description { get; set; }
    public string ImagePath { get; set; } // Đường dẫn ảnh, có thể ẩn
    public string ViewDetail { get; set; } // Đây là gì? Có thể là một flag hoặc URL cho trang chi tiết?

    // Constructor mặc định (tùy chọn, C# tự tạo nếu không có constructor nào)
    public ProductDTO() { }

    // Constructor có tham số (tùy chọn, để dễ dàng khởi tạo)
    public ProductDTO(
        int productId, string productName, int categoryId, string categoryName,
        int producerId, string producerName, int manufactureId, string manufactureName,
        List<UnitDTO> units, decimal price, int inventoryId, int quantity,
        int totalQuantity, string description, string imagePath, string viewDetail)
    {
        ProductId = productId;
        ProductName = productName;
        CategoryId = categoryId;
        CategoryName = categoryName;
        ProducerId = producerId;
        ProducerName = producerName;
        ManufactureId = manufactureId;
        ManufactureName = manufactureName;
        Units = units ?? new List<UnitDTO>(); // Đảm bảo không null
        Price = price;
        InventoryId = inventoryId;
        Quantity = quantity;
        TotalQuantity = totalQuantity;
        Description = description;
        ImagePath = imagePath;
        ViewDetail = viewDetail;
    }

    // Triển khai phương thức từ ISearchable
    public bool MatchesSearch(string searchValue)
    {
        if (string.IsNullOrEmpty(searchValue))
        {
            return true; // Không có giá trị tìm kiếm, coi là match tất cả
        }

        // Chuyển searchValue sang chữ thường để so sánh không phân biệt hoa thường
        string lowerSearchValue = searchValue.ToLower();

        // Kiểm tra các thuộc tính string mà bạn muốn tìm kiếm
        return (ProductName?.ToLower().Contains(lowerSearchValue) ?? false) ||
               (CategoryName?.ToLower().Contains(lowerSearchValue) ?? false) ||
               (ProducerName?.ToLower().Contains(lowerSearchValue) ?? false) ||
               (ManufactureName?.ToLower().Contains(lowerSearchValue) ?? false);
        // Bạn có thể thêm các thuộc tính khác vào đây nếu muốn tìm kiếm
        // ví dụ: (Description?.ToLower().Contains(lowerSearchValue) ?? false)
    }

    // Các thuộc tính chỉ dùng để ẩn trên UI nếu bạn muốn
    // Chúng không cần được khai báo lại như trong record ban đầu
    [Browsable(false)]
    public int CategoryId { get; set; } // Đặt lại sau khi bỏ khỏi positional params
}
