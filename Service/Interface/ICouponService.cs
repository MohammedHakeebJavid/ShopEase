using ShopEase.Models.Entity;

namespace ShopEase.Service.Interface
{
    public interface ICouponService
    {
        Task AddCoupon(Coupon coupon);
        Task<Coupon> GetCouponById(Guid coupon);
        Task<Coupon> GetCouponByCode(string code);
        Task<bool> ValidateCoupon(string code);
        Task UpdateCoupon(Coupon coupon);
    }
}
