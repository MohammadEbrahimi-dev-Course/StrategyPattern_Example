using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services.StrategyPattern;

public class BitcoinPayment : IPaymentStrategy
{
    public string Pay(Order order)
    {
        // Do Some Work and create a transaction to transfer btc 
        return $"Paid {order.Amount} using Bitcoin for Order {order.OrderId} .";
    }
}
