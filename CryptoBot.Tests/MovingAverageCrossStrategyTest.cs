using CryptoBot.Domain.Enums;
using CryptoBot.Domain.Models;
using CryptoBot.Domain.Strategies;

namespace CryptoBot.Tests;

public class MovingAverageCrossStrategyTest
{
    [Fact]
    public void ShortSMACrossesAboveLongSMA()
    {
        var strategy = new MovingAverageCrossStrategy(3, 5);
        var candleList = new List<Candle>
        {
            new Candle { Close = 3m },
            new Candle { Close = 4m },
            new Candle { Close = 3m },
            new Candle { Close = 4m },
            new Candle { Close = 3m },
            new Candle { Close = 15m },
        };
        var signal = strategy.Evaluate(candleList);
        Assert.Equal(Signal.Buy, signal);
    }

    [Fact]
    public void ShortSMACrossesBelowLongSMA()
    {
        var strategy = new MovingAverageCrossStrategy(3, 5);
        var candleList = new List<Candle>
        {
            new Candle { Close = 4m },
            new Candle { Close = 3m },
            new Candle { Close = 15m },
            new Candle { Close = 3m },
            new Candle { Close = 4m },
            new Candle { Close = 3m },
        };
        var signal = strategy.Evaluate(candleList);
        Assert.Equal(Signal.Sell, signal);
    }

    [Fact]
    public void FewerCandlesThanLongPeriod()
    {
        var strategy = new MovingAverageCrossStrategy(3, 5);
        var candleList = new List<Candle>
        {
            new Candle { Close = 4m },
            new Candle { Close = 3m },
            new Candle { Close = 15m },
            new Candle { Close = 3m },
        };
        var signal = strategy.Evaluate(candleList);
        Assert.Equal(Signal.Hold, signal);
    }

    [Fact]
    public void EmptyListCandles()
    {
        var strategy = new MovingAverageCrossStrategy(3, 5);
        var candleList = new List<Candle>();
        var signal = strategy.Evaluate(candleList);
        Assert.Equal(Signal.Hold, signal);
    }
}
