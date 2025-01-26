using StrategyPattern_Example.Dto;
using StrategyPattern_Example.Entities;
using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Services.StrategyPattern;

namespace StrategyPattern_Example.Endpoints;

public static class EndPointsWithStrategyPattern
{
    public static WebApplication MapStrategyEndPoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/Strategy")
            .WithDescription("Check Payment Type With Strategy Pattern");

        _ = root.MapGet("/", Payments)
            .Produces<List<PaymentResult>>()
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("List of Payment Orders With Strategy")
            .WithDescription("\n    GET /withStrategy");

        _ = root.MapGet("/Better", BetterPayments)
            .Produces<List<PaymentResult>>()
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("List of Payment Orders With Better Strategy")
            .WithDescription("\n    GET /withBetterStrategy");

        return app;
    }

    public static async Task<IResult> Payments()
    {
        List<PaymentResult> Result = new List<PaymentResult>();
        var order1 = new Order { OrderId = 1, Amount = 100.0, OrderType = OrderType.CreditCard };
        var order2 = new Order { OrderId = 2, Amount = 200.0, OrderType = OrderType.Paypal };
        var order3 = new Order { OrderId = 3, Amount = 300.0, OrderType = OrderType.Bitcoin };

        var strategy1 = PaymenyStrategyFactory.GetPaymentStrategy(order1.OrderType);
        var context1 = new PaymentContext(strategy1);
        var paymentResultOrder1 = context1.ExecutePayment(order1);
        Result.Add(new PaymentResult(order1, paymentResultOrder1));

        var strategy2 = PaymenyStrategyFactory.GetPaymentStrategy(order2.OrderType);
        var context2 = new PaymentContext(strategy2);
        var paymentResultOrder2 = context2.ExecutePayment(order2);
        Result.Add(new PaymentResult(order2, paymentResultOrder2));

        var strategy3 = PaymenyStrategyFactory.GetPaymentStrategy(order3.OrderType);
        var context3 = new PaymentContext(strategy3);
        var paymentResultOrder3 = context3.ExecutePayment(order3);
        Result.Add(new PaymentResult(order3, paymentResultOrder3));


        // add new type? no problem :)

        var order4 = new Order { OrderId = 4, Amount = 400.0, OrderType = OrderType.Cash };
        var strategy4 = PaymenyStrategyFactory.GetPaymentStrategy(order4.OrderType);
        var context4 = new PaymentContext(strategy4);
        var paymentResultOrder4 = context4.ExecutePayment(order4);
        Result.Add(new PaymentResult(order4, paymentResultOrder4));


        return Results.Ok(Result);
    }

    public static async Task<IResult> BetterPayments()
    {
        //Register a new payment strategy dynamically
        PaymenyStrategyFactory.RegisterStrategy(OrderType.CreditCard, () => new BitcoinPayment());

        List<PaymentResult> Result = new List<PaymentResult>();

        var orders = new[]
        {
            new Order { OrderId = 1, Amount = 100.0, OrderType = OrderType.CreditCard },
            new Order { OrderId = 2, Amount = 200.0, OrderType = OrderType.Paypal },
            new Order { OrderId = 3, Amount = 300.0, OrderType = OrderType.Bitcoin },

            //new Type
            new Order { OrderId = 4, Amount = 400.0, OrderType = OrderType.Cash }
        };

       
        //Process payments for each Order
        foreach(var order in orders)
        {
            var strategy = PaymenyStrategyFactory.GetPaymentStrategy_Better(order.OrderType);
            var res = strategy.Pay(order);

            Result.Add(new PaymentResult(order, res));
        }

        return Results.Ok(Result);
    }
}
