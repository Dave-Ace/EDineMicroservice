
namespace Basket.api.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommanValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommanValidator()
    {
        RuleFor(x => x.Cart).NotEmpty().WithMessage("Cart cannot be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {

        ShoppingCart cart = command.Cart;

        //todo: store basket in database and redis

        return new StoreBasketResult("Anony");
    }
}
