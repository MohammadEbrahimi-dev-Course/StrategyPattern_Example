using Microsoft.AspNetCore.Mvc;
using StrategyPattern_Example.Services;
using StrategyPattern_Example.Entities;
using StrategyPattern_Example.Entities.Enum;
using StrategyPattern_Example.Dto;

namespace StrategyPattern_Example.Endpoints;

public static class EndPointsWithOutStrategyPattern
{
    public static WebApplication MapWithoutStrategyEndPoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/withoutStrategy")
            .WithDescription("Check Payment Type Without Strategy Pattern");

        _ = root.MapGet("/", Payments)
            .Produces<List<PaymentResult>>()
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("List of Payment Orders Without Strategy")
            .WithDescription("\n    GET /withoutStrategy");

        return app;
    }

    public static async Task<IResult> Payments([FromServices] Bad_OrderService orderService)
    {
        List<PaymentResult> Result = new List<PaymentResult> ();
        var order1 = new Order { OrderId = 1, Amount = 100.0, OrderType = OrderType.CreditCard };
        var order2 = new Order { OrderId = 2, Amount = 200.0, OrderType = OrderType.Paypal };
        var order3 = new Order { OrderId = 3, Amount = 300.0, OrderType = OrderType.Bitcoin };

        var paymentResultOrder1 = orderService.ProcessPayment(order1);
        Result.Add(new PaymentResult(order1, paymentResultOrder1));

        var paymentResultOrder2 = orderService.ProcessPayment(order2);
        Result.Add(new PaymentResult(order2, paymentResultOrder2));

        var paymentResultOrder3 = orderService.ProcessPayment(order3);
        Result.Add(new PaymentResult(order3, paymentResultOrder3));


        // add new type too:
        var order4 = new Order { OrderId = 4 , Amount = 400.0, OrderType = OrderType.Cash };

        var paymentResultOrder4 = orderService.ProcessPayment(order4);
        Result.Add(new PaymentResult(order4, paymentResultOrder3));


        return Results.Ok(Result);
    }
}
