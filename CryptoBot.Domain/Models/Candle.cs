namespace CryptoBot.Domain.Models;

public record Candle
{
    public string Market { get; init; } = string.Empty;
    public DateTime TimeStamp { get; init; }
    public decimal Open { get; init; }
    public decimal High { get; init; }
    public decimal Low { get; init; }
    public decimal Close { get; init; }
    public decimal Volume { get; init; }
}
