using StrategyPattern_Example.Entities;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

/// <summary>
/// Context For Strategy Pattern
/// </summary>
public class PaymentContext
{
    private readonly IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public string ExecutePayment(Order order)
    {
        return _paymentStrategy.Pay(order);
    }
}
