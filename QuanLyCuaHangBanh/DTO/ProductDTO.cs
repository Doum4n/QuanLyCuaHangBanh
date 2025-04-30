using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyCuaHangBanh.DTO;

public record ProductDTO(
    int ProductId,
    string ProductName,
    int CategoryId,
    string CategoryName,
    int ProducerId,
    string ProducerName,
    List<UnitDTO> Unit,
    decimal Price,
    int InventoryId,
    int Quantity,
    string Description,
    String ImagePath
)
{
    [Browsable(false)]
    public List<UnitDTO> Unit { get; set; } = Unit;
    [Browsable(false)]
    public int CategoryId { get; set; } = CategoryId;
    [Browsable(false)]
    public int ProducerId { get; set; } = ProducerId;
    [Browsable(false)]
    public int InventoryId { get; set; } = InventoryId;
    [Browsable(false)]
    public string ImagePath { get; set; } = ImagePath;

    public decimal Price { get; set; } = Price;
    public int Quantity { get; set; } = Quantity;
}