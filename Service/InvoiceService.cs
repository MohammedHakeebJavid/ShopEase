using ShopEase.Models.Entity;
using ShopEase.Repository.Interface;
using ShopEase.Service.Interface;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICouponService _couponService;

    public InvoiceService(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, ICouponService couponService)
    {
        _invoiceRepository = invoiceRepository;
        _customerRepository = customerRepository;
        _couponService = couponService;
    }
    public async Task<Invoice> GenerateInvoice(Guid customerId, List<CartItem> cartItems, string paymentOption, string couponCode)
    {

        // Retrieve customer details
        var customer = await _customerRepository.GetById(customerId);
        if(customer == null)
        {
            throw new ArgumentException("Customer does not exist");
        }

        // Calculate subtotal from cart items
        decimal subtotal = cartItems.Sum(item => item.Product.Price * item.Quantity);

        // Apply coupon discount if a valid coupon code is provided
        decimal discount = 0;
        if (!string.IsNullOrWhiteSpace(couponCode))
        {
            bool isValidCoupon = await _couponService.ValidateCoupon(couponCode);
            if (isValidCoupon)
            {
                // Get coupon details and apply discount
                var coupon = await _couponService.GetCouponByCode(couponCode);
                discount = coupon.DiscountAmount;

                // Update coupon usage count
                coupon.UsageCount++;
                await _couponService.UpdateCoupon(coupon);
            }
        }
        // Convert cart items to list of products
        var products = cartItems.Select(item => item.Product).ToList();

        // Calculate total amount after discount
        decimal totalAmount = subtotal - discount;

        // Create new invoice
        var invoice = new Invoice
        {
            CustomerId = customerId,
            Products = products,
            TotalAmount = totalAmount,
            PaymentOption = paymentOption,
            Discount = discount
        };

        await _invoiceRepository.Addnvoice(invoice);

        return invoice;
    }

    public async Task<Invoice> GetInvoicesByCustomer(Guid customerId)
    {
        return await _invoiceRepository.GetInvoicesByCustomer(customerId);
    }
}