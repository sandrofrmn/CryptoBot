using CryptoBot.Domain.Enums;
using CryptoBot.Domain.Models;

namespace CryptoBot.Domain.Interfaces;

public interface IStrategy
{
    Signal Evaluate(IReadOnlyList<Candle> candleList);
}
