using CryptoBot.Domain.Models;

namespace CryptoBot.Domain.Interfaces;

public interface IBotStateService
{
    bool IsRunning { get; }
    void Start();
    void Stop();
    Position? GetCurrentPosition(string market);
    void SetPosition(string market, Position? position);
}
