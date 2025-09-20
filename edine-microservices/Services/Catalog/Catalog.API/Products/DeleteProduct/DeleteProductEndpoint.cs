﻿
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductRequest(Guid Id);

public record class DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteProductCommand(id);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        })
          .WithName("DeleteProduct")
          .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Delete a Product")
          .WithDescription("Delete a Product");
    }
}
