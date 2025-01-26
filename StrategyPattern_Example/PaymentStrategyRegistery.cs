using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

/// <summary>
/// Registry for payment strategies. It allows dynamic registration and retrieval of strategies at runtime.
/// This eliminates the need to modify the factory or existing code when adding new payment types.
/// </summary>
public static class PaymentStrategyRegistery
{
    public static readonly Dictionary<OrderType, Func<IPaymentStrategy>> Strategies = new()
    {
        {OrderType.CreditCard, ()=> new CreditCardPayment() },
        {OrderType.Paypal, ()=> new PayPalPayment() },
        {OrderType.Bitcoin, ()=> new BitcoinPayment() },

        //New type
        {OrderType.Cash, ()=> new CashPayment() },
    };
}
