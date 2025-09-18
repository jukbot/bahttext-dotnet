using DotNetBahtText;

Console.WriteLine("=== DotNet Baht Text Converter Sample ===");
Console.WriteLine();

// Sample currency conversions
var amounts = new decimal[] { 0, 1, 10, 25, 100, 1234.56m, -500.25m };

Console.WriteLine("Currency Conversions:");
foreach (var amount in amounts)
{
    var text = BahtTextConverter.Convert(amount);
    Console.WriteLine($"{amount:C} -> {text}");
}

Console.WriteLine();
Console.WriteLine("Number Conversions:");

// Sample number conversions
var numbers = new long[] { 0, 1, 10, 21, 100, 1234, -999 };

foreach (var number in numbers)
{
    var text = BahtTextConverter.ConvertNumber(number);
    Console.WriteLine($"{number} -> {text}");
}

Console.WriteLine();
Console.WriteLine("Interactive Mode - Enter amounts to convert (or 'exit' to quit):");

while (true)
{
    Console.Write("Enter amount: ");
    var input = Console.ReadLine();
    
    if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
        break;
    
    if (decimal.TryParse(input, out var amount))
    {
        var result = BahtTextConverter.Convert(amount);
        Console.WriteLine($"Result: {result}");
    }
    else
    {
        Console.WriteLine("Invalid number format. Please try again.");
    }
    
    Console.WriteLine();
}
