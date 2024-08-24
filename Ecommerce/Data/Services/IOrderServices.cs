using Ecommerce.Models;

namespace Ecommerce.Data.Services
{
    public interface IOrderServices
    {
        
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId);
        Task<List<Order>> GetOrderAndRoleByUserIdAsync(string userId, string role);
    }
}
