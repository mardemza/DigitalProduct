using DigitalProduct.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// -- Configure logs
builder.Logging.AddFile("App_Data/logs-{Date}.txt");

// -- Add Lazy Cache
builder.Services.AddLazyCache();

// -- Add services to the container.
builder.Services.AddDependency();

builder.Services.AddControllers();

// -- Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
