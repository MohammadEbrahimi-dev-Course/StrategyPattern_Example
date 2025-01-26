using StrategyPattern_Example.Entities;

namespace StrategyPattern_Example.Services.StrategyPattern;

public interface IPaymentStrategy
{
    string Pay(Order order);
}
