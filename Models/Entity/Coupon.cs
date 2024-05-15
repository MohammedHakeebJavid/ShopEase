namespace ShopEase.Models.Entity
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int UsageLimit { get; set; }
        public int UsageCount { get; set; }
    }
}
