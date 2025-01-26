using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

//Better Solution With Strategy
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
