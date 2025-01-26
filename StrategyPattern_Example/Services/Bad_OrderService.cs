using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services;

public class Bad_OrderService
{

    // Violates the Open/Closed Principle (OCP): adding a new payment type requires modifying this method.    // And Testing is hard too. 

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


            // And when add new Order Type this Class expand and going to larger and hard to develop 
            case Entities.Enum.OrderType.Cash:
                // Do Some Work and confirmation for cash
                return $"Paid {order.Amount} using cash for Order {order.OrderId}";

            default:
                throw new NotSupportedException($"Payment type {order.OrderType} is not supported.");
        }
    }
}