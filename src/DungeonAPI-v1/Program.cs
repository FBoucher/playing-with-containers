var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<DataGenerator>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("adventurer/", (DataGenerator dataGen) => {
	var adventurers = dataGen.GenerateAdventurer(5);
	return adventurers;
});

app.Run();
