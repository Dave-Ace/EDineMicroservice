namespace Catalog.API.Models;

public class Product : BaseEntity
{
    public Guid Id { set; get; }
    public string Name { get; set; }
    public string? Description { get; set;  }
    public decimal Price { get; set; }
    public List<string> Category { get; set; }
    public string? Image { get; set; }
}
