using System.Security.Cryptography;
using System.Text;

namespace CryptoBot.Bitvavo;

public class BitvavoAuth
{
    public static string CreateSignature(string secret, long timestamp, string method, string path, string body)
    {
        var concatenatedString = GetConcatenatedString(timestamp, method, path, body);

        var key = Encoding.UTF8.GetBytes(secret);
        var message = Encoding.UTF8.GetBytes(concatenatedString);

        using var hmac = new HMACSHA256(key);
        var hash = hmac.ComputeHash(message);

        // Convert to lowercase hex string
        var hexString = Convert.ToHexString(hash).ToLower();

        return hexString;
    }

    public static string GetConcatenatedString(long timestamp, string method,  string path, string? body)
        => string.Concat(timestamp, method, path, body);

    public static long GetTimeStamp() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();    
}
