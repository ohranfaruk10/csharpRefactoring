using c__refactoring.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

public class Program
{
    //per microsoft documentation naming of enumerations should be in pascal case
    //https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations
    public enum PlayType
    {
        Tragedy,
        Comedy,
        None
    }

    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
          .AddTransient<ICaluculateService, CalculateService>()
          .AddTransient<IStatementService, StatementService>()
          .BuildServiceProvider();

        var statementService = serviceProvider.GetService<IStatementService>();
        var playsFile = File.ReadAllText("plays.json");
        var invoicesFile = File.ReadAllText("invoices.json");
        var plays = JObject.Parse(playsFile);
        var invoices = JArray.Parse(invoicesFile).FirstOrDefault();

        Console.WriteLine(statementService!.GetStatement(invoices, plays));
    }
}
