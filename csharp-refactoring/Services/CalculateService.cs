using c__refactoring.Extensions;
using Newtonsoft.Json.Linq;
using static Program;

namespace c__refactoring.Services
{
    public interface ICaluculateService
    {
        int CalculateAmount(JToken play, int audience);
        int CalculateVolumeCredits(JToken play, int audience);
    }

    public class CalculateService : ICaluculateService
    {
        public int CalculateAmount(JToken play, int audience)
        {
            int thisAmount;
            switch (play.GetPlayType())
            {
                case PlayType.Tragedy:
                    thisAmount = 40000;
                    if (audience > 30)
                    {
                        thisAmount += 1000 * (audience - 30);
                    }
                    break;
                case PlayType.Comedy:
                    thisAmount = 30000;
                    if (audience > 20)
                    {
                        thisAmount += 10000 + 500 * (audience - 20);
                    }
                    thisAmount += 300 * audience;
                    break;
                default:
                    throw new FormatException("Wrong play type provided");
            }

            return thisAmount;
        }

        public int CalculateVolumeCredits(JToken play, int audience)
        {
            int volumeCredits = Math.Max(audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if (play.GetPlayType() == PlayType.Comedy)
                volumeCredits += (int)Math.Floor(audience / 5.0d);

            return volumeCredits;
        }
    }

}

