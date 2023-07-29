using System.Text.Json.Serialization;

namespace DotnetRPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rpg
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3

    }
}
