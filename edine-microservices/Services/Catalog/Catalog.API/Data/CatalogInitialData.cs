using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData :IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellationToken = default)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Name = "IPhone X",
            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            Image = "product-1.png",
            Price = 950.00M,
            Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
            Name = "Samsung 10",
            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            Image = "product-2.png",
            Price = 840.00M,
            Category = new List<string> {"Smart Phone" }
        },
        new Product()
        {
            Name = "Huawei Plus",
            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            Image = "product-3.png",
            Price = 650.00M,
            Category = new List<string> {"White Appliances" }
        },
        new Product()
        {
            Name = "Xiaomi Mi 9",
            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            Image = "product-4.png",
            Price = 470.00M,
            Category = new List<string> { "White Appliances" }
        },
        new Product()
        {
            Name = "HTC U11+ Plus",
            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            Image = "product-4.png",
            Price = 470.00M,
            Category = new List<string> { "White Appliances" }
        }
    };
}
