using StrategyPattern_Example.Entities.Enum;

namespace StrategyPattern_Example.Entities;

public class Order
{
    public int OrderId { get; set; }
    public double Amount { get; set; }
    public OrderType OrderType { get; set; }
}
