using CryptoBot.Domain.Enums;

namespace CryptoBot.Domain.Models;

public record Position
{
    public string Market { get; init; } = string.Empty;
    public PositionSide Side { get; init; }
    public decimal EntryPrice { get; init; }
    public decimal Amount { get; init; }
    public DateTime OpenedAt { get; init; }
}
