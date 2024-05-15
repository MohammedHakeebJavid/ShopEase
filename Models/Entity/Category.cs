using System.ComponentModel.DataAnnotations;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    public string Description { get; set; }
}