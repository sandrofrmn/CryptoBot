using CryptoBot.Domain.Models;

namespace CryptoBot.Domain.Interfaces;

public interface IOrderRepository
{
    Task SaveAsync(Order order);
    Task<IReadOnlyList<Order>> GetOpenAsync(string market);
    Task<Order?> GetByIdAsync(string orderId);
}
