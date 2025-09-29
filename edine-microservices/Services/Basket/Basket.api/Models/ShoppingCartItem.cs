namespace Basket.api.Models;

public class ShoppingCartItem
{
    public int Quantity { get; set; }
    public string color { get; set; }
    public decimal price { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
}
