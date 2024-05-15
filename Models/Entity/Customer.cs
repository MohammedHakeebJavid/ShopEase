using System.ComponentModel.DataAnnotations;
public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    public string Address { get; set; }

    [Required(ErrorMessage = "ContactNumber is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string ContactNumber { get; set; }
}