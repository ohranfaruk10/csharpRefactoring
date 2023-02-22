using Newtonsoft.Json.Linq;
using static Program;

namespace c__refactoring.Extensions
{
    public static class JTokenExtensions
    {
        public static PlayType GetPlayType(this JToken jToken)
        {
            string playType = jToken.GetJSONPropertyValue("type");
            return playType switch
            {
                "tragedy" => PlayType.Tragedy,
                "comedy" => PlayType.Comedy,
                _ => PlayType.None,
            };
        }

        public static string GetJSONPropertyValue(this JToken jToken, string parameter)
        {
            return jToken[parameter] != null
                ? jToken[parameter]!.ToString()
                : throw new FormatException("Non parsable JSON");
        }
    }
}
