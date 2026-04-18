using CryptoBot.Bitvavo;

namespace CryptoBot.Tests;

public class BitvavoAuthTest
{
    [Fact]
    public void CreateHMACSignature()
    {
        var secret = "test-secret";

        // 1776532140000
        var timestamp = new DateTimeOffset(2026, 4, 18, 17, 9, 0, TimeSpan.Zero).ToUnixTimeMilliseconds();

        var method = "POST";
        var path = "test-path";
        var body = "thisisatest";

        var signature = BitvavoAuth.CreateSignature(secret, timestamp, method, path, body);
        Assert.Equal("5e75f7d6110def0ba3ff6915d57651694179ca2eaa82b2af13875ba1231ca909", signature);
    }
}
