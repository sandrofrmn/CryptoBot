using CryptoBot.Domain.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoBot.Bitvavo.Converters;

public class CandleConverter(string market) : JsonConverter<Candle>
{
    public override bool HandleNull => base.HandleNull;

    // Example:
    // [
    //  "1538784000000",
    //  "4999",
    //  "5012",
    //  "4999",
    //  "5012",
    //  "0.45"
    //]
    public override Candle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Reader is currently at StartArray [
        reader.Read(); // Move to first element (Timestamp)

        var timestampMs = long.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);
        var timestampOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestampMs);
        var timestamp = timestampOffset.DateTime;

        reader.Read(); // Move to second element (Open)
        var open = decimal.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);

        reader.Read(); // High
        var high = decimal.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);

        reader.Read(); // Low
        var low = decimal.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);

        reader.Read(); // Close
        var close = decimal.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);

        reader.Read(); // Volume
        var volume = decimal.Parse(reader.GetString()!, System.Globalization.CultureInfo.InvariantCulture);

        reader.Read(); 

        return new Candle
        {
            Market = market,
            TimeStamp = timestamp,
            Open = open,
            High = high,
            Low = low,
            Close = close,
            Volume = volume,
        };
    }

    public override void Write(Utf8JsonWriter writer, Candle value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
