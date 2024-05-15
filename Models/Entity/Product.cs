using System.ComponentModel.DataAnnotations;
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "CategoryId is required")]
    public Guid CategoryId { get; set; }
}