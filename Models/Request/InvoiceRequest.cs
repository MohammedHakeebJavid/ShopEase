using ShopEase.Models.Entity;

namespace ShopEase.Models.Request
{
    public class InvoiceRequest
    {
        public Guid CustomerId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public string PaymentOption { get; set; }
        public string CouponCode { get; set; }
    }
}
