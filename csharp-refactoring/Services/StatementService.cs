using c__refactoring.Extensions;
using Newtonsoft.Json.Linq;

namespace c__refactoring.Services
{
    public interface IStatementService
    {
        string GetStatement(JToken invoices, JToken plays);
    }

    public class StatementService : IStatementService
    {
        private readonly ICaluculateService caluculateService;

        public StatementService(ICaluculateService caluculateService)
        {
            this.caluculateService = caluculateService;
        }

        public string GetStatement(JToken invoices, JToken plays)
        {
            int totalAmount = 0;
            int volumeCredits = 0;
            var result = $"Statement for {invoices["customer"]} \n";
            var performances = invoices["performances"];

            if (performances != null)
            {
                foreach (var performance in performances)
                {
                    var play = plays[performance.GetJSONPropertyValue("playID")];
                    int audience = int.Parse(performance.GetJSONPropertyValue("audience"));
                    int playAmount = caluculateService.CalculateAmount(play, audience);
                    volumeCredits += caluculateService.CalculateVolumeCredits(play, audience);
                    result += $" {play["name"]}: $ {playAmount / 100} ({audience} seats) \n";
                    totalAmount += playAmount;
                }
            }

            return $"{result}Amount owed is $ {totalAmount / 100} \n" +
                   $"You earned {volumeCredits} credits \n";
        }
    }
}
