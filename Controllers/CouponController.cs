using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.Entity;
using ShopEase.Service.Interface;

namespace ShopEase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _coupenService;

        public CouponController(ICouponService customerService)
        {
            _coupenService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> AddCoupon(Coupon coupon)
        {
            await _coupenService.AddCoupon(coupon);
            return CreatedAtAction(nameof(GetCouponById), new { id = coupon.Id }, coupon);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupon>> GetCouponById(Guid id)
        {
            var product = await _coupenService.GetCouponById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{code}/Discount")]
        public async Task<ActionResult<Coupon>> GetCouponByCode(string code)
        {
            var product = await _coupenService.GetCouponByCode(code);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
