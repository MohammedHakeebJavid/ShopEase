using ShopEase.Models.Entity;
using ShopEase.Repository.Interface;
public class CouponRepository: ICouponRepository
{
    private static List<Coupon> _coupons = new List<Coupon>() { };

    public async Task<IEnumerable<Coupon>> GetAll()
    {
        return await Task.FromResult(_coupons);
    }

    public async Task<Coupon> GetCouponByCode(string Code) => _coupons.FirstOrDefault(c => c.Code == Code);

    public async Task<Coupon> GetCouponById(Guid Id) => _coupons.FirstOrDefault(c => c.Id == Id);
    public async Task AddCoupon(Coupon coupon)
    {
        coupon.Id = Guid.NewGuid();
        _coupons.Add(coupon);
        await Task.CompletedTask;
    }

    public async Task UpdateCoupon(Coupon entity)
    {
        var existingCoupon = _coupons.FirstOrDefault(c => c.Code== entity.Code);
        if (existingCoupon != null)
        {
            // Update the existing coupon properties
            existingCoupon.Code = entity.Code;
            existingCoupon.DiscountAmount = entity.DiscountAmount;
            existingCoupon.ValidFrom = entity.ValidFrom;
            existingCoupon.ValidTo = entity.ValidTo;
            existingCoupon.UsageLimit = entity.UsageLimit;
            existingCoupon.UsageCount = entity.UsageCount;
        }
    }
}
