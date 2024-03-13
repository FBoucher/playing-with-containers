using Bogus;
using Bogus.DataSets;

namespace DungeonDomain;
public class DataGenerator
{
	private Faker<Adventurer> fSeller;

	public DataGenerator()
	{
		Randomizer.Seed = new Random(DateTime.Now.Millisecond);

		fSeller = new Faker<Adventurer>()
			.RuleFor(a => a.Name, f => f.Name.FullName())
			.RuleFor(a => a.Level, f => f.Random.Number(1, 20))
			.RuleFor(a => a.Class, f => f.PickRandom<AdventurerClass>())
			.RuleFor(a => a.HP, f => f.Random.Number(10, 100));
	
	}

	public IEnumerable<Adventurer> GenerateAdventurer(int n) {
		return fSeller.Generate(n);
	}
}