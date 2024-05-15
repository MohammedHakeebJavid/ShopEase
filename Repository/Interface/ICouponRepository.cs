using ShopEase.Models.Entity;
using System.Threading.Tasks;

namespace ShopEase.Repository.Interface
{
    public interface ICouponRepository
    {
        Task<Coupon> GetCouponById(Guid Id);
        Task<Coupon> GetCouponByCode(string code);
        Task UpdateCoupon(Coupon coupon);
        Task AddCoupon(Coupon coupon);
    }
}
