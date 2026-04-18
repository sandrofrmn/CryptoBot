using CryptoBot.Domain.Models;

namespace CryptoBot.Domain.Interfaces;

public interface ITradeRepository
{
    Task SaveAsync(Trade trade);
    Task<IReadOnlyList<Trade>> GetAllAsync();
    Task<IReadOnlyList<Trade>> GetByMarketAsync(string market);
}
