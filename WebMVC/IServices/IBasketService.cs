using WebMVC.Models;

namespace WebMVC.IServices
{
    public interface IBasketService
    {
        Task CheckoutBasket(BasketCheckoutModel model);
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
    }
}
