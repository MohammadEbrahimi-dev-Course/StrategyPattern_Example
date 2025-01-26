using StrategyPattern_Example.Entities;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

/// <summary>
/// The PaymentContext encapsulates the chosen payment strategy and delegates payment execution.
/// It provides flexibility by decoupling the order from payment logic.
/// </summary>
public class PaymentContext
{
    private readonly IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Executes the payment using the chosen strategy.
    public string ExecutePayment(Order order)
    {
        return _paymentStrategy.Pay(order);
    }
}
