namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, decimal Price, string? Description, string? Image)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
internal class CreateProductHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Image = command.Image,
            Price = command.Price
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
        
    }
}
