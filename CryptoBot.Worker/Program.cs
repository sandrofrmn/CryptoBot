using CryptoBot.Domain.Configuration;
using CryptoBot.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<BitvavoOptions>(
        builder.Configuration.GetSection("BitvavoOptions"));

builder.Services.Configure<BotOptions>(
        builder.Configuration.GetSection("BotOptions"));

var host = builder.Build();
host.Run();
