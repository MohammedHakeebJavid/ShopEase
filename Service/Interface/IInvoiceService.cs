using ShopEase.Models.Entity;

namespace ShopEase.Service.Interface
{
    public interface IInvoiceService
    {
        Task<Invoice> GenerateInvoice(Guid customerId, List<CartItem> cartItems, string paymentOption, string couponCode);
        Task<Invoice> GetInvoicesByCustomer(Guid customerId);
    }
}
