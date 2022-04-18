
using Discount.Grpc.Data;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly DiscountDbContext _context;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(DiscountDbContext context,  ILogger<DiscountService> logger)
        {
            _context =context;
            _logger = logger ;
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.ProductName ==request.ProductName);
            coupon ??= new Coupon { Amount = 0, ProductName = "No Discount", Description = "No Discount Desc" };
            _logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);
            return new CouponModel {
                ProductName=coupon.ProductName,
                Amount=coupon.Amount, 
                Description=coupon.Description,
                Id=coupon.Id
            };
        }
    }
}
