namespace CryptoBot.Domain.Models;

public record Balance
{
    public string Symbol { get; init; } = string.Empty;
    public decimal Available { get; init; }
    public decimal InOrder { get; init; }
}
