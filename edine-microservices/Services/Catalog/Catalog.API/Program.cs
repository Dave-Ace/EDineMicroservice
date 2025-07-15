using BuildingBlocks.Behaviours;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviours<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogConnection"));
    options.Schema.For<Product>().Index(x => x.Name);
    options.Schema.For<Product>().Index(x => x.Category);
}).UseLightweightSessions();

var app = builder.Build();

// COnfigure the Http request pipeline
app.MapCarter();

app.Run();
