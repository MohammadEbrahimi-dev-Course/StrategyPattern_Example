using StrategyPattern_Example.Endpoints;
using StrategyPattern_Example.Services;

#region Configurations
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Bad_OrderService>();
//builder.Services.AddScoped<CustomerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#endregion

//Without Strategy Pattern 
app.MapWithoutStrategyEndPoints();



app.Run();
