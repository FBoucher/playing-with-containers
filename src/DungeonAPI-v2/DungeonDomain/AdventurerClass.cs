using System.Text.Json.Serialization;

namespace DungeonDomain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdventurerClass
{
	Warrior,
	Mage,
	Thief,
	Archer
}