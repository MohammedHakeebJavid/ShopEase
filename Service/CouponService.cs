using ShopEase.Models.Entity;
using ShopEase.Repository.Interface;
using ShopEase.Service.Interface;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;

    public CouponService(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }
    public async Task<Coupon> GetCouponById(Guid id)
    {
        return await _couponRepository.GetCouponById(id);
    }
    public async Task<Coupon> GetCouponByCode(string code)
    {
        // Retrieve all coupons and find the one with the matching code
        var coupons = await _couponRepository.GetCouponByCode(code);
        return coupons;
    }

    public async Task<bool> ValidateCoupon(string code)
    {
        var coupon = await GetCouponByCode(code);
        if (coupon == null)
        {
            return false; // Coupon does not exist
        }

        if (DateTime.UtcNow < coupon.ValidFrom || DateTime.UtcNow > coupon.ValidTo)
        {
            return false; // Coupon is not valid yet or has expired
        }

        if (coupon.UsageLimit > 0 && coupon.UsageCount >= coupon.UsageLimit)
        {
            return false; // Coupon has reached its usage limit
        }

        return true; // Coupon is valid
    }

    public async Task UpdateCoupon(Coupon coupon)
    {
        await _couponRepository.UpdateCoupon(coupon);
    }
    public async Task AddCoupon(Coupon coupon)
    {
        // Validate category attributes before adding
        if (string.IsNullOrWhiteSpace(coupon.Code))
        {
            throw new ArgumentException("Coupon Code must not be empty.");
        }

        await _couponRepository.AddCoupon(coupon);
    }
}