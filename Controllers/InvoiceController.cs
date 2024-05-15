using Microsoft.AspNetCore.Mvc;
using ShopEase.Models.Request;
using ShopEase.Service.Interface;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpPost("generate")]
    public async Task<ActionResult<Invoice>> GenerateInvoice(InvoiceRequest request)
    {
        var invoice = await _invoiceService.GenerateInvoice(request.CustomerId, request.CartItems, request.PaymentOption, request.CouponCode);
        return Ok(invoice);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<Invoice>> GetInvoicesByCustomer(Guid customerId)
    {
        var invoices = await _invoiceService.GetInvoicesByCustomer(customerId);
        if (invoices == null)
        {
            return NotFound();
        }
        return Ok(invoices);
    }
}