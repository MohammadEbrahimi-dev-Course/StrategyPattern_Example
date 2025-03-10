﻿using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example;

// Factory to provide the appropriate payment strategy.
public class PaymenyStrategyFactory
{
    public static IPaymentStrategy GetPaymentStrategy(OrderType orderType)
    {
        return orderType switch
        {
            OrderType.CreditCard => new CreditCardPayment(),
            OrderType.Paypal => new PayPalPayment(),
            OrderType.Bitcoin => new BitcoinPayment(),

            //If add new type just add here and create class of it
            OrderType.Cash => new CashPayment(),

            _ => throw new NotSupportedException($"payment type  {orderType} is not supported.")
        };
    }


    #region  Better Solution With Strategy
    // Dynamically retrieves the strategy from the registry based on the OrderType.
    public static IPaymentStrategy GetPaymentStrategy_Better(OrderType orderType)
    {
        //It get dynamicly and don't need to add new case
        if (!PaymentStrategyRegistery.Strategies.ContainsKey(orderType))
        {
            throw new NotSupportedException($"payment type  {orderType} is not supported.");
        }

        return PaymentStrategyRegistery.Strategies[orderType]();
    }

    // Allows dynamic registration of new payment strategies without modifying this class.
    public static void RegisterStrategy(OrderType orderType, Func<IPaymentStrategy> strategy)
    {
        PaymentStrategyRegistery.Strategies[orderType] = strategy;
    }
    #endregion
}