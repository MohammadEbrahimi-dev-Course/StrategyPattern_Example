using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services.StrategyPattern;

public class CashPayment : IPaymentStrategy
{
    public string Pay(Order order)
    {
        // Do Some Work and confirmation for cash
        return $"Paid {order.Amount} using cash for Order {order.OrderId}";
    }
}
