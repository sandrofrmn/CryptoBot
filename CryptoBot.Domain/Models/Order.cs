namespace CryptoBot.Domain.Models;

public record Order
{
    public string OrderId { get; init; } = string.Empty;
    public string Market { get; init; } = string.Empty;
    public string Side { get; init; } = string.Empty;
    public string OrderType { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public decimal? Price { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
