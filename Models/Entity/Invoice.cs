using System.ComponentModel.DataAnnotations;
public class Invoice
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "CustomerId is required")]
    public Guid CustomerId { get; set; }

    [Required(ErrorMessage = "Products is required")]
    public List<Product> Products { get; set; }

    [Required(ErrorMessage = "TotalAmount is required")]
    public decimal TotalAmount { get; set; }

    public string PaymentOption { get; set; }

    public decimal Discount { get; set; }
}