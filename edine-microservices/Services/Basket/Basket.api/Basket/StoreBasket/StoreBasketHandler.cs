
using Basket.api.Data;

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

public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {

        ShoppingCart cart = command.Cart;

        await repository.StoreBasket(cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }
}
