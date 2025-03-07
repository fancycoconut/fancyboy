using Microsoft.Extensions.Configuration;

namespace Fancyboy;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        if (args.Length > 0)
        {
            Console.WriteLine($"Loaded {args[0]}...");
            //emulator.SetROM(args[0]);
        }
    }
}
