using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services;

public class Bad_OrderService
{
    public string ProcessPayment(Order order)
    {
        switch (order.OrderType)
        {
            case Entities.Enum.OrderType.CreditCard:
                //Do Some Work and Send Request to Bank
                return $"Paid {order.Amount} using Credit Card for Order {order.OrderId} .";

            case Entities.Enum.OrderType.Paypal:
                // Do Some Work and send Request to Paypal
                return $"Paid {order.Amount} using Paypal for Order {order.OrderId} .";

            case Entities.Enum.OrderType.Bitcoin:
                // Do Some Work and create a transaction to transfer btc 
                return $"Paid {order.Amount} using Bitcoin for Order {order.OrderId} .";

            default:
                throw new NotSupportedException($"Payment type {order.OrderType} is not supported.");
        }
    }
}