using Discount.API.Data;
using Discount.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountDbContext context;

        public DiscountController(DiscountDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var coupon = await context.Coupons.FirstOrDefaultAsync(c=>c.ProductName==productName);
            coupon ??= new Coupon { Amount = 0, ProductName = "No Discount", Description = "No Discount Desc" };
            return Ok(coupon);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            await context.Coupons.AddAsync(coupon);
            await context.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetDiscount), new { productName = coupon.ProductName }, coupon);
        }
        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateBasket([FromBody] Coupon coupon)
        {
            var entity=await context.Coupons.FindAsync(coupon.Id);
            if (entity == null)
            {
                return BadRequest();
            }
            entity.Amount = coupon.Amount;
            entity.Description = coupon.Description;
            entity.ProductName = coupon.ProductName;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            var entity = await context.Coupons.FirstOrDefaultAsync(c=>c.ProductName==productName);
            if (entity == null)
            {
                return BadRequest();
            }
            context.Coupons.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
