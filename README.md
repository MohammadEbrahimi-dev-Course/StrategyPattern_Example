
# Strategy Design Pattern in C#

This project demonstrates the implementation of the **Strategy Design Pattern** in C#. The Strategy Pattern is used to define a family of algorithms, encapsulate each one, and make them interchangeable. This pattern lets the algorithm vary independently from the clients that use it.

---

## Project Structure

### **Entities**
- **`Order`**: Represents an order with properties such as `OrderId`, `Amount`, and `OrderType`.
- **`OrderType`**: Enum representing different payment types (e.g., `CreditCard`, `Paypal`, `Bitcoin`, and `Cash`).

### **Services**
- **Without Strategy**:
  - **`Bad_OrderService`**: Processes payments using a `switch` statement, violating the Open/Closed Principle. Adding new payment types requires modifying the existing code.
  - **Endpoints**: `/api/withoutStrategy` showcases the complexity of this approach.

- **With Strategy**:
  - **Strategy Interface**:
    - **`IPaymentStrategy`**: Defines the interface for all payment strategies.
  - **Concrete Strategies**:
    - **`CreditCardPayment`**, **`PayPalPayment`**, **`BitcoinPayment`**, and **`CashPayment`**: Implementations of different payment strategies.
  - **Factory**:
    - **`PaymenyStrategyFactory`**: Returns the appropriate payment strategy based on the `OrderType`.
  - **Context**:
    - **`PaymentContext`**: Encapsulates a payment strategy and delegates payment execution.
  - **Dynamic Registration**:
    - **`PaymentStrategyRegistery`**: Allows dynamic registration of new payment types.
  - **Endpoints**:
    - `/api/Strategy`: Demonstrates payment processing with the Strategy Pattern.
    - `/api/Strategy/Better`: Illustrates the enhanced approach with dynamic strategy registration.

---

## Features

### **Without Strategy**
- Payment processing is handled using a `switch` statement in `Bad_OrderService`.
- Adding new payment types requires modifying the service, increasing the risk of errors and maintenance challenges.

### **With Strategy**
- Payment processing logic is encapsulated in separate strategy classes.
- Adheres to the Open/Closed Principle:
  - Adding new payment types is as simple as creating a new class and registering it.
- Dynamic strategy registration allows runtime flexibility.

---

## Why Use the Strategy Pattern?

1. **Decoupling**: Separates the algorithm (payment processing) from the client (order service).
2. **Extensibility**: New payment types can be added without modifying existing code.
3. **Testability**: Each strategy can be independently tested.
4. **Flexibility**: Strategies can be registered dynamically at runtime.

---

## API Endpoints

### **Without Strategy**
- **GET /api/withoutStrategy**:  
  Fetches payment results processed using `Bad_OrderService`.

### **With Strategy**
- **GET /api/Strategy**:  
  Fetches payment results processed using the Strategy Pattern.
  
- **GET /api/Strategy/Better**:  
  Fetches payment results processed using dynamically registered strategies.

---

## Example Requests

### **Without Strategy**
**GET /api/withoutStrategy**  
**Response**:

```json
[
  {
    "orderId": 1,
    "amount": 100.0,
    "orderType": "CreditCard",
    "result": "Paid 100.0 using Credit Card for Order 1 ."
  }
]
````

### **With Strategy**

**GET /api/Strategy**\
**Response**:

```json
[
  {
    "orderId": 1,
    "amount": 100.0,
    "orderType": "CreditCard",
    "result": "Paid 100.0 using Credit Card for Order 1 ."
  },
  {
    "orderId": 4,
    "amount": 400.0,
    "orderType": "Cash",
    "result": "Paid 400.0 using cash for Order 4"
  }
]
```

**GET /api/Strategy/Better**\
**Response**:

```json
[
  {
    "orderId": 1,
    "amount": 100.0,
    "orderType": "CreditCard",
    "result": "Paid 100.0 using Bitcoin for Order 1 ." // Dynamically registered strategy.
  }
]
```

---

## How to Run the Project

### Prerequisites:

- .NET 8.0 or higher.
- Visual Studio or any C# IDE.

### Steps:

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Navigate to the project directory.
3. Run the application:
   ```bash
   dotnet run
   ```
4. Use Swagger UI to test the endpoints:
   - Access Swagger at: `https://localhost:<port>/swagger`.

---

## Technologies Used

- **C#**
- **ASP.NET Core Minimal API**
- **Swagger** for API documentation

---

## Resources

### Video Tutorials:
- [YouTube:بررسی Strategy Design Pattern و موارد استفاده از آن](https://youtu.be/M8yx6_1BhF0?si=msTaW_hHeFR2bjfs)

---

## Credits
Develop By [AliCharper](https://github.com/AliCharper)

Refactor by **Mohammad**.  
Feel free to reach out for feedback or collaboration!


