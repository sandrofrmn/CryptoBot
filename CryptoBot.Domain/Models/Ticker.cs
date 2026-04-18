namespace CryptoBot.Domain.Models;

public record Ticker
{
    public string Market { get; init; } = string.Empty;
    public decimal Bid { get; init; }
    public decimal Ask { get; init; }
    public decimal Last { get; init; }
    public DateTime TimeStamp { get; init; }
}
