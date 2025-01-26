namespace StrategyPattern_Example.Entities.Enum;

//The Way To Pay Order and The usage of Strategy pattern become in this enum.
public enum OrderType
{
    CreditCard,
    Paypal,
    Bitcoin,

    //Now if We add new Type we have problem with out Strategy pattern
    Cash
}


