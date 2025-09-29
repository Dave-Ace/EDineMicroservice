using BuildingBlocks.Behaviours;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviours<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

var app = builder.Build();

//COnfigure the Http request pipeline
app.MapCarter();
app.Run();
