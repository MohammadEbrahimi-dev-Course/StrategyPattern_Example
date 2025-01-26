using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services.StrategyPattern;

public class CreditCardPayment : IPaymentStrategy
{
    public string Pay(Order order)
    {
        //Do Some Work and Send Request to Bank
        return $"Paid {order.Amount} using Credit Card for Order {order.OrderId} .";
    }
}
