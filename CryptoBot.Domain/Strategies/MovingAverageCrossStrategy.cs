using CryptoBot.Domain.Enums;
using CryptoBot.Domain.Interfaces;
using CryptoBot.Domain.Models;

namespace CryptoBot.Domain.Strategies;

public class MovingAverageCrossStrategy(int shortPeriod, int longPeriod) : IStrategy
{
    private readonly int _shortPeriod = shortPeriod;
    private readonly int _longPeriod = longPeriod;

    public Signal Evaluate(IReadOnlyList<Candle> candleList)
    {
        // CandleList == null, CandleList = empty, short SMA has a bigger number than long SMA, candle list doesn't have enough candles to detect crossovers
        if (candleList == null || candleList.Count == 0 || _shortPeriod > _longPeriod || candleList.Count < _longPeriod + 1) return Signal.Hold;

        var currentShortSMA = CalculateCurrentSma(candleList, _shortPeriod);
        var currentLongSMA = CalculateCurrentSma(candleList, _longPeriod);
        var previousShortSMA = CalculatePreviousSma(candleList, _shortPeriod);
        var previousLongSMA = CalculatePreviousSma(candleList, _longPeriod);

        // Current short SMA is above the current long SMA
        if (currentShortSMA > currentLongSMA)
        {
            // Detect flip (short SMA goes over the long SMA), so the short SMA was below the long SMA here.
            if (previousShortSMA < previousLongSMA)
                return Signal.Buy;
            else
                return Signal.Hold;
        }
        if (currentShortSMA < currentLongSMA)
        {
            // Detect flip (crossover). The short SMA was above the long SMA here.
            if (previousShortSMA > previousLongSMA)
                return Signal.Sell;
            else
                return Signal.Hold;
        }

        return Signal.Hold;
    }

    private decimal CalculateCurrentSma(IReadOnlyList<Candle> candles, int period)
    {
        return candles.TakeLast(period).Average(x => x.Close);
    }

    private decimal CalculatePreviousSma(IReadOnlyList<Candle> candles, int period)
    {
        return candles.TakeLast(period + 1).Take(period).Average(x => x.Close);
    }
}
