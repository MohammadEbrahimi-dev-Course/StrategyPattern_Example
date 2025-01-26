using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services.StrategyPattern;

public class PayPalPayment : IPaymentStrategy
{
    public string Pay(Order order)
    {
        // Do Some Work and send Request to Paypal
        return $"Paid {order.Amount} using Paypal for Order {order.OrderId} .";
    }
}
