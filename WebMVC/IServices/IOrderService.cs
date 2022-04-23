using WebMVC.Models;

namespace WebMVC.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
