using CryptoBot.Domain.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<BitvavoOptions>(
        builder.Configuration.GetSection("BitvavoOptions"));

builder.Services.Configure<BotOptions>(
        builder.Configuration.GetSection("BotOptions"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
