namespace ShopEase.Repository.Interface
{
    public interface IInvoiceRepository
    {
        Task Addnvoice(Invoice invoice);
        Task<Invoice> GetInvoicesByCustomer(Guid customerId);
    }
}