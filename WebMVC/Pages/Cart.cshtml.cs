using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMVC.IServices;
using WebMVC.Models;

namespace WebMVC.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "amr";
            Cart = await _basketService.GetBasket(userName);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "amr";
            var basket = await _basketService.GetBasket(userName);
            var item = basket.Items.Single(x => x.ProductId == productId);
            basket.Items.Remove(item);
            _ = await _basketService.UpdateBasket(basket);
            return RedirectToPage();
        }
    }
}
