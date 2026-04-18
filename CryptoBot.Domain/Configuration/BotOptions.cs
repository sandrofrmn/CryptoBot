namespace CryptoBot.Domain.Configuration;

public class BotOptions
{
    public bool IsEnabled { get; set; } = false;
    public string[] AllowedPairs { get; set; } = ["XRP-EUR", "ADA-EUR"];
    public decimal MaxPositionEur { get; set; }
    public decimal DailyLossLimitEur { get; set; }
    public decimal StopLossPercent { get; set; }
    public int CandleIntervalSeconds { get; set; }
}
