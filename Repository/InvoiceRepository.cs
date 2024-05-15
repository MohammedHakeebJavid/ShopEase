using ShopEase.Repository.Interface;

public class InvoiceRepository:IInvoiceRepository
{
    private static List<Invoice> _invoices = new List<Invoice>() { };

    public async Task<Invoice> GetnvoiceById(Guid id)
    {
        return await Task.FromResult(_invoices.FirstOrDefault(i => i.Id == id));
    }

    public async Task Addnvoice(Invoice entity)
    {
        entity.Id = Guid.NewGuid();
        _invoices.Add(entity);
        await Task.CompletedTask;
    }

    public async Task Updatenvoice(Invoice entity)
    {
        var existingInvoice = await GetnvoiceById(entity.Id);
        if (existingInvoice != null)
        {
            existingInvoice.CustomerId = entity.CustomerId;
            existingInvoice.Products = entity.Products;
            existingInvoice.TotalAmount = entity.TotalAmount;
            existingInvoice.PaymentOption = entity.PaymentOption;
            existingInvoice.Discount = entity.Discount;
        }
        await Task.CompletedTask;
    }

    public async Task Deletenvoice(Guid id)
    {
        var invoiceToRemove = await GetnvoiceById(id);
        if (invoiceToRemove != null)
        {
            _invoices.Remove(invoiceToRemove);
        }
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Invoice>> Search(Func<Invoice, bool> predicate)
    {
        return await Task.FromResult(_invoices.Where(predicate));
    }

    public async Task<Invoice> GetInvoicesByCustomer(Guid customerId)
    {
        return await Task.FromResult(_invoices.FirstOrDefault(i => i.CustomerId == customerId));
    }
}