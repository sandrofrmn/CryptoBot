namespace CryptoBot.Domain.Models;

public record Trade
{
    public string TradeId { get; init; } = string.Empty;
    public string Market { get; init; } = string.Empty;
    public string Side { get; init;  } = string.Empty;
    public decimal Amount { get; init; }
    public decimal Price { get; init; }
    public decimal Fee { get; init; }
    public DateTime TimeStamp { get; init; }
}
