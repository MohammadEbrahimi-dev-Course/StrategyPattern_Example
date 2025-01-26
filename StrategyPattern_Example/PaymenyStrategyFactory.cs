using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

public class PaymenyStrategyFactory
{
    public static IPaymentStrategy GetPaymentStrategy(OrderType orderType)
    {
        return orderType switch
        {
            OrderType.CreditCard => new CreditCardPayment(),
            OrderType.Paypal => new PayPalPayment(),
            OrderType.Bitcoin => new BitcoinPayment(),

            //If add new type just add here and create class of it
            OrderType.Cash => new CashPayment(),

            _ => throw new NotSupportedException($"payment type  {orderType} is not supported.")
        };
    }
}