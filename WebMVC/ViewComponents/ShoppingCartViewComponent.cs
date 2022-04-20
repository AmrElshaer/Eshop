using Microsoft.AspNetCore.Mvc;
using WebMVC.IServices;

namespace WebMVC.ViewComponents
{
    public class ShoppingCartViewComponent:ViewComponent
    {
        private readonly IBasketService _basketService;

        public ShoppingCartViewComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           return View(await _basketService.GetBasket("amr")) ;
        }
    }
}
