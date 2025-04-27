using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangBanh.DTO;

public class ProductDTO
{
    //public ProductDTO()
    //{
    //    Unit = new List<UnitDTO>();
    //}

    public ProductDTO(int id, string productName, string categoryName, string producerName, List<UnitDTO> unit,
        decimal price, int quantity, string description, Image image)
    {
        ID = id;
        ProductName = productName;
        CategoryName = categoryName;
        ProducerName = producerName;
        Unit = unit;
        Price = price;
        Quantity = quantity;
        Description = description;
        Image = image;
    }

    public int ID { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string ProducerName { get; set; }
    public List<UnitDTO> Unit { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public Image Image { get; set; }

    [NotMapped] public int? SelectedUnitId { get; set; } // ID của đơn vị được chọn trong ComboBox
}