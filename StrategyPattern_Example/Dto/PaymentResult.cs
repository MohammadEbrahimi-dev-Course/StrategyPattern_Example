using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Dto;

public class PaymentResult
{
    public Order Order { get; set; }
    public string Result { get; set; }

    public PaymentResult(Order order, string result)
    {
        Order = order;
        Result = result;
    }
}
